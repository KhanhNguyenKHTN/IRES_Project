using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Model.Models.Table
{
    public class TableModel: BaseModel
    {
      //  "tableId": 5,
      //"code": "TABLE-05",
      //"number": 5,
      //"position": "Tầng 1",
      //"status": "CÒN TRỐNG",
      //"description": "Bàn 5 Tầng 1"
        private int _Number;
        [JsonProperty("number")]
        public int Number { get => _Number; set { _Number = value; OnPropertyChanged(); } }

        private string _Code;
        [JsonProperty("code")]
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged(); } }

        private string _Position;
        [JsonProperty("position")]
        public string Position { get => _Position; set { _Position = value; OnPropertyChanged(); } }

        private string _Status;
        [JsonProperty("status")]
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string _Description;
        [JsonProperty("description")]
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }

        private int _Id;
        [JsonProperty("tableId")]
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }


        private string _Name;
        public string Name { get { return "Bàn " + Number; } }

        private bool _IsActived;
        public bool IsActived { get => _IsActived; set { _IsActived = value; OnPropertyChanged(); } }

        

    }
}
