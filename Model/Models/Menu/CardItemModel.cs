using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Menu
{
    public class CardItemModel : TabMenuItemModel
    {
        public string Description { get; set; }

        public int Likes { get; set; }

        public string ImagesSource { get; set; }

        public string Cost { get; set; } // temp for food menu

        private bool _IsSoldOut;
        public bool IsSoldOut { get => _IsSoldOut; set { _IsSoldOut = value; OnPropertyChanged(); } }

    }
}
