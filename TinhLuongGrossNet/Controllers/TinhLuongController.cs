using Microsoft.AspNetCore.Mvc;
using TinhLuongGrossNet.Common;
using TinhLuongGrossNet.Common.Constant;
using TinhLuongGrossNet.Models.Response;

namespace TinhLuongGrossNet.Controllers
{
    public class TinhLuongController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GrossToNet(IFormCollection formcollection)
        {
            var luongThuNhap = double.Parse(formcollection["thuNhap"]);
            var luongDongBaoHiem = double.Parse(formcollection["luongDongBaoHiem"]);
            var soNguoiPhuThuoc = double.Parse(formcollection["soNguoiPhuThuoc"]);
            var vung = int.Parse(formcollection["vung"]);
            var tienBaoHiem = Helper.TienBaoHiem(vung, luongDongBaoHiem);

            var thuNhapTruocThue = luongThuNhap - tienBaoHiem;
            var giaCanhBanThan = ConfigConstant.GiaCanhBanThan;
            var giamTruPhuThuoc = soNguoiPhuThuoc * ConfigConstant.NguoiPhuThuoc;

            var chiuThue = thuNhapTruocThue - giaCanhBanThan - giamTruPhuThuoc;
            var thuNhapChiuThue = chiuThue < 0 ? 0 : chiuThue;
            var thueThuNhapCaNhan = Helper.TienThue(thuNhapChiuThue);

            var luongNet = thuNhapTruocThue - thueThuNhapCaNhan;

            SalaryDto salary = new SalaryDto();
            salary.BHXH = Helper.TienBHXH(luongDongBaoHiem);
            salary.BHYT = Helper.TienBHYT(luongDongBaoHiem);
            salary.BHTN = Helper.TienBHTN(vung, luongDongBaoHiem);
            salary.ThuNhapTruocThue = thuNhapTruocThue;
            salary.GiamTruGiaCanh = giaCanhBanThan;
            salary.GiamTruPhuThuoc = giamTruPhuThuoc;
            salary.ThuNhapChiuThue = thuNhapChiuThue;
            salary.ThueThuNhapCaNhan = thueThuNhapCaNhan;
            salary.SalaryNet = luongNet;
            salary.SalaryGross = luongThuNhap;
            salary.TongBaoHiem = tienBaoHiem;

            JsonResponseViewModel model = new JsonResponseViewModel();
            if (salary != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = salary;
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = null;
            }
            return Json(model);
        }
        public JsonResult NetToGross(IFormCollection formcollection)
        {
            var luongThuNhap = double.Parse(formcollection["thuNhap"]);
            var luongDongBaoHiem = double.Parse(formcollection["luongDongBaoHiem"]);
            var soNguoiPhuThuoc = double.Parse(formcollection["soNguoiPhuThuoc"]);
            var vung = int.Parse(formcollection["vung"]);

            var tienBaoHiem = Helper.TienBaoHiem(vung, luongDongBaoHiem);

            var giaCanhBanThan = ConfigConstant.GiaCanhBanThan;
            var giamTruPhuThuoc = soNguoiPhuThuoc * ConfigConstant.NguoiPhuThuoc;
            var thuNhapDaTruPhuThuoc = luongThuNhap - giaCanhBanThan - giamTruPhuThuoc;

            var thuNhapChiuThue = Math.Round(Helper.ThuNhapChiuThue(thuNhapDaTruPhuThuoc));
            var thuNhapTruocThue = thuNhapChiuThue + giaCanhBanThan + giamTruPhuThuoc;
            var thueThuNhapCaNhan = Math.Round(Helper.TienThue(thuNhapChiuThue));

            var luongGross = thuNhapTruocThue + tienBaoHiem;

            SalaryDto salary = new SalaryDto();
            salary.BHXH = Helper.TienBHXH(luongDongBaoHiem);
            salary.BHYT = Helper.TienBHYT(luongDongBaoHiem);
            salary.BHTN = Helper.TienBHTN(vung, luongDongBaoHiem);
            salary.ThuNhapTruocThue = thuNhapTruocThue;
            salary.GiamTruGiaCanh = giaCanhBanThan;
            salary.GiamTruPhuThuoc = giamTruPhuThuoc;
            salary.ThuNhapChiuThue = thuNhapChiuThue;
            salary.ThueThuNhapCaNhan = thueThuNhapCaNhan;
            salary.SalaryNet = luongThuNhap;
            salary.SalaryGross = luongGross;
            salary.TongBaoHiem = tienBaoHiem;

            JsonResponseViewModel model = new JsonResponseViewModel();
            if (salary != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = salary;
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = null;
            }
            return Json(model);
        }

    }
}
