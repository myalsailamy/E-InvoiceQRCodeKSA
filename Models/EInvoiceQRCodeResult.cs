using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace E_InvoiceQRCodeKSA.Models
{
    /// <summary>
    /// نتيجة توليد الباركود الذي سيتم اضافته للفاتورة
    /// </summary>
    public class EInvoiceQRCodeResult
    {
        /// <summary>
        /// صورة الباركود
        /// </summary>
        public Image QRCodeImage { get; set; }
        /// <summary>
        /// صورة الباركود بصيغة Base64
        /// </summary>
        public string Base64Image { get; set; }
        /// <summary>
        /// نص الفاتورة بصيغة Base64
        /// </summary>
        public string Base64Text { get; set; }
        /// <summary>
        /// النص بعد اعادة فكه
        /// </summary>
        public string DecodedText { get; set; }
    }
}
