namespace TinhLuongGrossNet.Common
{
    public static class Helper
    {
        public static double TienThue(double luongChiuThue)
        {
            if (luongChiuThue == 0)
            {
                return 0;
            }
            var tienThue = PhantranThue(luongChiuThue) * luongChiuThue / 100;
            return tienThue;
        }
        public static double PhantranThue(double luongChiuThue)
        {
            var result = 0;
            if (0 < luongChiuThue && luongChiuThue <= 5000000)
            {
                result = 5;
            }
            else if (5000000 < luongChiuThue && luongChiuThue <= 10000000)
            {
                result = 10;
            }
            else if (10000000 < luongChiuThue && luongChiuThue <= 18000000)
            {
                result = 15;
            }
            else if (18000000 < luongChiuThue && luongChiuThue <= 32000000)
            {
                result = 20;
            }
            else if (32000000 < luongChiuThue && luongChiuThue <= 52000000)
            {
                result = 25;
            }
            else if (52000000 < luongChiuThue && luongChiuThue < 80000000)
            {
                result = 30;
            }
            else
            {
                result = 35;
            }
            return result;
        }
    }
}
