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
            SalaryDto salary = new SalaryDto();
            string formThuNhap = formcollection["thuNhap"];
            var formLuongDongBaoHiem = formcollection["luongDongBaoHiem"];
            var formVung = formcollection["vung"];
            var formSoNguoiPhuThuoc = formcollection["soNguoiPhuThuoc"];

            var luongThuNhap = double.Parse(formThuNhap);
            var luongDongBaoHiem = double.Parse(formLuongDongBaoHiem);
            var soNguoiPhuThuoc = double.Parse(formSoNguoiPhuThuoc);
            var vung = int.Parse(formVung);

            var bhxh = Helper.LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHXH;
            var bhyt = Helper.LuongDongBHXH_BHYTToiDa(luongDongBaoHiem) * ConfigConstant.BHYT;
            var bhtn = Helper.LuongDongBaoHiemThatNghiepToiDa(vung, luongDongBaoHiem) * ConfigConstant.BHTN;

            var tienBaoHiem = bhxh + bhyt + bhtn;
            //
            var thuNhapTruocThue = luongThuNhap - tienBaoHiem;
            //
            var giaCanhBanThan = ConfigConstant.GiaCanhBanThan;
            //
            var giamTruPhuThuoc = soNguoiPhuThuoc * ConfigConstant.NguoiPhuThuoc;
            //
            var chiuThue = thuNhapTruocThue - giaCanhBanThan - giamTruPhuThuoc;
            var thuNhapChiuThue = chiuThue < 0 ? 0 : chiuThue;
            var thueThuNhapCaNhan = Helper.TienThue(thuNhapChiuThue);
            var net = thuNhapTruocThue - thueThuNhapCaNhan;




            salary.BHXH = bhxh;
            salary.BHYT = bhyt;
            salary.BHTN = bhtn;
            salary.ThuNhapTruocThue = thuNhapTruocThue;
            salary.GiamTruGiaCanh = giaCanhBanThan;
            salary.GiamTruPhuThuoc = giamTruPhuThuoc;
            salary.ThuNhapChiuThue = thuNhapChiuThue;
            salary.ThueThuNhapCaNhan = thueThuNhapCaNhan;
            salary.SalaryNet = net;
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
                model.ResponseMessage = null;// "No record available";
            }
            return Json(model);
        }

    }
}
