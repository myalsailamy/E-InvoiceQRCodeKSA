using E_InvoiceQRCodeKSA.ExtensionsMethods;
using E_InvoiceQRCodeKSA.Helpers;
using E_InvoiceQRCodeKSA.Models;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace E_InvoiceQRCodeKSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataTest = new QRGeneratorInput() { SellerName = "محمد الصيلمي", VATNumber = "300007417400003", TimeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ssZ"), InvoiceTotal = 115, VATTotal = 15 };
           
            Console.WriteLine("First Way (1) -------------------------------------- ");
            var result = GetQRCodeWithTag(dataTest);
            Console.WriteLine("E-Invoice");
            //Console.WriteLine($"Base64Image: \n{result.Base64Image}");
            Console.WriteLine($"Base64Text: \n{result.Base64Text}");
            Console.WriteLine($"DecodedText: \n{result.DecodedText}");
            Console.WriteLine("(1) Done -------------------------------------- ");

            //Console.WriteLine("second Way (2) -------------------------------------- ");
            //string textCode = Base64Helper.Encode(Base64Helper.ConvertHex("01") + Base64Helper.ConvertHex(Base64Helper.ToHex(dataTest.SellerName.Length)) + dataTest.SellerName +
            //                    Base64Helper.ConvertHex("02") + Base64Helper.ConvertHex(Base64Helper.ToHex(dataTest.VATNumber.Length)) + dataTest.VATNumber + 
            //                    Base64Helper.ConvertHex("03") + Base64Helper.ConvertHex("14") + dataTest.TimeStamp + 
            //                    Base64Helper.ConvertHex("04") + Base64Helper.ConvertHex(Base64Helper.ToHex(dataTest.InvoiceTotal.ToString().Length)) + dataTest.InvoiceTotal.ToString() + 
            //                    Base64Helper.ConvertHex("05") + Base64Helper.ConvertHex(Base64Helper.ToHex(dataTest.VATTotal.ToString().Length)) + dataTest.VATTotal.ToString());
            //Console.WriteLine($"E-Invoice Result: \n {textCode}");
            //Console.WriteLine("(2) Done -------------------------------------- ");
            Console.ReadKey();
        }

        static public EInvoiceQRCodeResult GetQRCodeWithTag(QRGeneratorInput input)
        {
            string base64Image = "";

            string base64Text;

            MemoryStream stream = new MemoryStream();
            stream.Append(1);
            var sellerNameBytes = Encoding.UTF8.GetBytes(input.SellerName);
            stream.Append(Convert.ToByte(sellerNameBytes.Length));
            stream.Append(sellerNameBytes);

            stream.Append(2);
            var vatNoBytes = Encoding.UTF8.GetBytes(input.VATNumber);
            stream.Append(Convert.ToByte(vatNoBytes.Length));
            stream.Append(vatNoBytes);

            stream.Append(3);
            var timestampBytes = Encoding.UTF8.GetBytes(input.TimeStamp);
            stream.Append(Convert.ToByte(timestampBytes.Length));
            stream.Append(timestampBytes);

            stream.Append(4);
            var invoiceTotalBytes = Encoding.UTF8.GetBytes(input.InvoiceTotal.ToString());
            stream.Append(Convert.ToByte(invoiceTotalBytes.Length));
            stream.Append(invoiceTotalBytes);

            stream.Append(5);
            var vatTotalBytes = Encoding.UTF8.GetBytes(input.VATTotal.ToString());
            stream.Append(Convert.ToByte(vatTotalBytes.Length));
            stream.Append(vatTotalBytes);

            var byteArr = stream.ToArray();
            base64Text = Convert.ToBase64String(byteArr);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(base64Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bImage = qrCode.GetGraphic(3);
            using (var ms = new MemoryStream())
            {
                bImage.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                base64Image = Convert.ToBase64String(byteImage);
            }
            return new EInvoiceQRCodeResult() { QRCodeImage = bImage, Base64Image = base64Image, Base64Text = base64Text, DecodedText = Base64Helper.Decode(base64Text) }; ;
        }
    }
}
