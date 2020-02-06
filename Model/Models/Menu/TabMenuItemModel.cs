using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Menu
{
    public class TabMenuItemModel: BaseModel
    {
        private bool _IsActived = false;

        public bool IsActived { get => _IsActived; set { _IsActived = value; OnPropertyChanged(); } }

        private string _IconFont;
        public string IconFont { get => _IconFont; set { _IconFont = value; OnPropertyChanged(); } }

        private string _LabName;
        public string LabName { get => _LabName; set { _LabName = value; OnPropertyChanged(); } }

        public object Tag { get; set; }

        private bool _IsSelected;
        public bool IsSelected { get => _IsSelected; set { _IsSelected = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private int _IntStatus;
        public int IntStatus { get => _IntStatus; set { _IntStatus = value; OnPropertyChanged(); } }

        private int _Number;
        public int Number { get => _Number; set { _Number = value; OnPropertyChanged(); } }
        
        public string Name { get { return "Bàn " + Number;} }

    }
}
