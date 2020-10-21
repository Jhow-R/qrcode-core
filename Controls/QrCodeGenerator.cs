using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRCode.Controls
{
    public static class QrCodeGenerator
    {
        public static byte[] GenerateByteArray(string text)
        {
            var image = GenerateImage(text);
            return ImageToByte(image);
        }

        private static Bitmap GenerateImage(string text)
        {
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

        private static byte[] ImageToByte(Image image)
        {
            using var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
            
            return stream.ToArray();
        }
    }
}
