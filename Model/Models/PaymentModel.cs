using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class PaymentModel: BaseModel
    {
        private int _Total;
        public int Total { get => _Total; set { _Total = value; OnPropertyChanged(); OnPropertyChanged("SFinal"); } }

        private int _VAT = 10;
        public int VAT { get => _VAT; set { _VAT = value; OnPropertyChanged(); OnPropertyChanged("SFinal"); } }

        private int _KM = 0;
        public int KM { get => _KM; set { _KM = value; OnPropertyChanged(); OnPropertyChanged("SFinal"); } }

        private int _Tip = 0;
        public int Tip { get => _Tip; set { _Tip = value; OnPropertyChanged(); OnPropertyChanged("SFinal"); } }

        public int FinalTotal { get { return Total + Total * VAT / 100 + KM + Tip; } }

        public string STotal { get { return Total.ToString("C").Remove(Total.ToString("C").Length - 2, 2); } }

        private string _SVAT;
        public string SVAT { get { return VAT.ToString(); } }

        private string _SKM;
        public string SKM { get => _SKM; set { _SKM = value; OnPropertyChanged(); } }

        private string _STip;
        public string STip { get => _STip; set { _STip = value; OnPropertyChanged(); } }


        private string _SFinal;
        public string SFinal { get { { return FinalTotal.ToString("C").Remove(FinalTotal.ToString("C").Length - 2, 2); } } }

        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged(); } }
    }

    public class SenderObject
    {

        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("promotion")]
        public string Promotion { get; set; }

        [JsonProperty("tip")]
        public int Tip { get; set; }

        public SenderObject(PaymentModel model)
        {
            PaymentType = model.Type != "Momo" ? "tiền mặt": "thẻ";
            Promotion = model.SKM;
            Tip = model.Total;
        }
    }

}
