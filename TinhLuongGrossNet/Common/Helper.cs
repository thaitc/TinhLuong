using TinhLuongGrossNet.Common.Constant;

namespace TinhLuongGrossNet.Common
{
    public static class Helper
    {
        public static double LuongDongBHXH_BHYTToiDa(double luongBaoHiem)
        {
            var luongCoSo = ConfigConstant.LuongCoSo * 20;
            if (luongBaoHiem > luongCoSo)
            {
                luongBaoHiem = luongCoSo;
            }
            return luongBaoHiem;
        }
        public static double LuongDongBaoHiemThatNghiepToiDa(int vung, double luongBaoHiem)
        {
            var v1 = ConfigConstant.BHTN_V1;
            var v2 = ConfigConstant.BHTN_V2;
            var v3 = ConfigConstant.BHTN_V3;
            var v4 = ConfigConstant.BHTN_V4;
            var bhtn = vung switch
            {
                1 => luongBaoHiem > v1 ? v1 : luongBaoHiem,
                2 => luongBaoHiem > v1 ? v2 : luongBaoHiem,
                3 => luongBaoHiem > v1 ? v3 : luongBaoHiem,
                4 => luongBaoHiem > v1 ? v4 : luongBaoHiem,
                _ => 0
            };
            return bhtn;
        }
        public static double TrongKhoang(double so, double dauKhoang, double cuoiKhoang)
        {
            if (so <= dauKhoang) return 0;
            if (so > cuoiKhoang) return cuoiKhoang - dauKhoang;
            return so - dauKhoang;
        }
        public static double TienThue(double luongChiuThue)
        {
            var thue1 = 5 * TrongKhoang(luongChiuThue, 0, 5000000) / 100;
            var thue2 = 10 * TrongKhoang(luongChiuThue, 5000000, 10000000) / 100;
            var thue3 = 15 * TrongKhoang(luongChiuThue, 10000000, 18000000) / 100;
            var thue4 = 20 * TrongKhoang(luongChiuThue, 18000000, 32000000) / 100;
            var thue5 = 25 * TrongKhoang(luongChiuThue, 32000000, 52000000) / 100;
            var thue6 = 30 * TrongKhoang(luongChiuThue, 52000000, 80000000) / 100;
            var thue7 = luongChiuThue > 80000000 ? 35 * (luongChiuThue - 80000000) / 100 : 0;
            return thue1 + thue2 + thue3 + thue4 + thue5 + thue6 + thue7;
        }
    }
}
