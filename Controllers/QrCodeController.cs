using Microsoft.AspNetCore.Mvc;
using QRCode.Controls;

namespace QRCode.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpPost("qrcode")]
        public IActionResult GetQrCode(string text)
        {
            if (text is not null)
            {
                var imageT = QrCodeGenerator.GenerateByteArray(text);
                return File(imageT, "image/jpeg"); ;
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
