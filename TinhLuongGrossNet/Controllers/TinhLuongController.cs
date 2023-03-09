using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            var bhxh = Helper.LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHXH;
            var bhyt = Helper.LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHYT;
            var bhtn = Helper.LuongDongBaoHiemThatNghiepToiDa(vung, luongDongBaoHiem) * ConfigConstant.BHTN;
            var tienBaoHiem = bhxh + bhyt + bhtn;

            var thuNhapTruocThue = luongThuNhap - tienBaoHiem;
            var giaCanhBanThan = ConfigConstant.GiaCanhBanThan;
            var giamTruPhuThuoc = soNguoiPhuThuoc * ConfigConstant.NguoiPhuThuoc;

            var chiuThue = thuNhapTruocThue - giaCanhBanThan - giamTruPhuThuoc;
            var thuNhapChiuThue = chiuThue < 0 ? 0 : chiuThue;
            var thueThuNhapCaNhan = Helper.TienThueGross(thuNhapChiuThue);

            var luongNet = thuNhapTruocThue - thueThuNhapCaNhan;

            SalaryDto salary = new SalaryDto();
            salary.BHXH = bhxh;
            salary.BHYT = bhyt;
            salary.BHTN = bhtn;
            salary.ThuNhapTruocThue = thuNhapTruocThue;
            salary.GiamTruGiaCanh = giaCanhBanThan;
            salary.GiamTruPhuThuoc = giamTruPhuThuoc;
            salary.ThuNhapChiuThue = thuNhapChiuThue;
            salary.ThueThuNhapCaNhan = thueThuNhapCaNhan;
            salary.SalaryNet = luongNet;
            salary.SalaryGross = luongThuNhap;  

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
