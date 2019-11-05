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
    }
}
