using TinhLuongGrossNet.Common.Constant;

namespace TinhLuongGrossNet.Common
{
    public static class Helper
    {
        private static double LuongDongBHXH_BHYTToiDa(double luongBaoHiem)
        {
            var luongCoSo = ConfigConstant.LuongCoSo * 20;
            if (luongBaoHiem > luongCoSo)
            {
                luongBaoHiem = luongCoSo;
            }
            return luongBaoHiem;
        }
        private static double LuongDongBaoHiemThatNghiepToiDa(int vung, double luongBaoHiem)
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
        private static double TrongKhoang(double so, double dauKhoang, double cuoiKhoang)
        {
            if (so <= dauKhoang) return 0;
            if (so > cuoiKhoang) return cuoiKhoang - dauKhoang;
            return Math.Round(so - dauKhoang);
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
        public static double ThuNhapChiuThue(double thuNhapDaTruPT)
        {
            bool quyDoi1 = 0 < thuNhapDaTruPT && thuNhapDaTruPT <= 4750000;
            bool quyDoi2 = 4750000 < thuNhapDaTruPT && thuNhapDaTruPT <= 9250000;
            bool quyDoi3 = 9250000 < thuNhapDaTruPT && thuNhapDaTruPT <= 16500000;
            bool quyDoi4 = 16500000 < thuNhapDaTruPT && thuNhapDaTruPT <= 27250000;
            bool quyDoi5 = 27250000 < thuNhapDaTruPT && thuNhapDaTruPT <= 42250000;
            bool quyDoi6 = 42250000 < thuNhapDaTruPT && thuNhapDaTruPT <= 61850000;
            bool quyDoi7 = thuNhapDaTruPT > 61850000;
            if (quyDoi1)
            {
                return thuNhapDaTruPT / 0.95;
            }
            else if (quyDoi2)
            {
                return (thuNhapDaTruPT - 250000) / 0.9;
            }
            else if (quyDoi3)
            {
                return (thuNhapDaTruPT - 750000) / 0.85;
            }
            else if (quyDoi4)
            {
                return (thuNhapDaTruPT - 1650000) / 0.8;
            }
            else if (quyDoi5)
            {
                return (thuNhapDaTruPT - 3250000) / 0.75;
            }
            else if (quyDoi6)
            {
                return (thuNhapDaTruPT - 5850000) / 0.7;
            }
            else if (quyDoi7)
            {
                return (thuNhapDaTruPT - 9850000) / 0.65;
            }
            return 0;
        }
        public static double TienBaoHiem(int vung, double luongDongBaoHiem)
        {
            var bhxh = TienBHXH(luongDongBaoHiem);
            var bhyt = TienBHYT(luongDongBaoHiem);
            var bhtn = TienBHTN(vung, luongDongBaoHiem);
            return bhxh + bhyt + bhtn;
        }
        public static double TienBHXH(double luongDongBaoHiem)
        {
            var bhxh = LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHXH;
            return bhxh;
        }
        public static double TienBHYT(double luongDongBaoHiem)
        {
            var bhyt = LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHYT;
            return bhyt;
        }
        public static double TienBHTN(int vung, double luongDongBaoHiem)
        {
            var bhtn = LuongDongBaoHiemThatNghiepToiDa(vung, luongDongBaoHiem) * ConfigConstant.BHTN;
            return bhtn;
        }
    }
}
