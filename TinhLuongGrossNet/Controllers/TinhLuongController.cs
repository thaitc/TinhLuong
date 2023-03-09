using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TinhLuongGrossNet.Common;
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
            salary.SalaryNet = formcollection["name"];

            var luongThuNhap = int.Parse(formThuNhap);
            var luongDongBaoHiem = int.Parse(formLuongDongBaoHiem);
            var soNguoiPhuThuoc = int.Parse(formSoNguoiPhuThuoc);



            var bhxh = luongDongBaoHiem * 0.08;
            var bhyt = luongDongBaoHiem * 0.015;
            var bhtn = luongDongBaoHiem * 0.01;



            //
            var thuNhapTruocThue = luongThuNhap - bhxh - bhyt - bhtn;
            //
            var giaCanhBanThan = 11000000;
            //
            var giamTruPhuThuoc = soNguoiPhuThuoc * 4400000;
            //
            var chiuThue = thuNhapTruocThue - giaCanhBanThan - giamTruPhuThuoc;
            var thuNhapChiuThue = chiuThue < 0 ? 0 : chiuThue;

            var thueThuNhapCaNhan = Helper.TienThue(thuNhapChiuThue);

            var net = thuNhapTruocThue - thueThuNhapCaNhan;




            /*salary.BHXH = thuNhap * 0.08;
            salary.BHYT = formcollection["name"];
            salary.BHTN = formcollection["name"];
            salary.TNTT = formcollection["name"];
            salary.GiamTruGiaCanh = formcollection["name"];
            salary.GiamTruPhuThuoc = formcollection["name"];
            salary.ThuNhapChiuThue = formcollection["name"];
            salary.ThueThuNhapCaNhan = formcollection["name"];*/

            JsonResponseViewModel model = new JsonResponseViewModel();
            if (salary != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(salary);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

    }
}
