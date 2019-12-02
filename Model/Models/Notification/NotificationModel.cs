using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Notification
{
    public class NotificationModel: BaseModel
    {
        private string _Lable;

        public string Lable
        {
            get { return _Lable; }
            set { _Lable = value; OnPropertyChanged(); }
        }

        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; OnPropertyChanged(); }
        }

    }
}
