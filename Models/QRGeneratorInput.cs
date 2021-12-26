using System;
using System.Collections.Generic;
using System.Text;

namespace E_InvoiceQRCodeKSA.Models
{
    public class QRGeneratorInput
    {
        /// <summary>
        /// اسم البائع
        /// أقصى عدد حروف لاسم البائع 12 حرف
        /// متضمنه للأحرف والفراغات
        /// </summary>
        public string SellerName { get; set; }
        /// <summary>
        /// الرقم الضريبي
        /// طول العدد ثابت 15 ارقام
        /// </summary>
        public string VATNumber { get; set; }
        /// <summary>
        /// التوقيت
        /// طوله لا يتعدى 19 خانه
        /// مثال:
        /// 2021-11-17 08:30:00
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// اجمالي مبلغ الفاتورة مع الضريبة
        /// طوله لا يتعدى 6 خانات
        /// </summary>
        public double InvoiceTotal { get; set; }
        /// <summary>
        /// اجمالي مبلغ الضريبة
        /// طوله لا يتعدى 5 خانات
        /// </summary>
        public double VATTotal { get; set; }
    }
}
