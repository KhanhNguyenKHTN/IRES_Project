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
    }
}
