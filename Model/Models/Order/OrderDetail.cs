using Model.Models.Menu;
using Model.Models.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Order
{

    public class Restaurant
    {
        public string address { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int restaurantId { get; set; }
    }

    public class Role
    {
        public string code { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int roleId { get; set; }
    }

    public class UserInfo
    {
        public string address { get; set; }
        public string avatarUrl { get; set; }
        public string displayName { get; set; }
        //public DateTime dob { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        //public role { get; set; }
        public string status { get; set; }
        public int userId { get; set; }
    }

    public class Pic
    {
        public string code { get; set; }
        public string description { get; set; }
        public int employeeId { get; set; }
        public string password { get; set; }
        public Restaurant restaurant { get; set; }
        public Role role { get; set; }
        public string status { get; set; }
        public UserInfo userInfo { get; set; }
        public string userName { get; set; }
    }

    public class OrderDetail
    {
        public string description { get; set; }
        public Food dish { get; set; }
        public int orderDetailId { get; set; }
        public Pic pic { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
    }


    public class Order
    {
        public string code { get; set; }
        public Customer customer { get; set; }

        private DateTime _DateCheck;

        public DateTime DateCheck
        {
            get { return _DateCheck; }
            set { _DateCheck = value; dateCheckin = _DateCheck.ToString("yyyy-MM-dd HH:mm:ss"); timeCheckin = _DateCheck.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public string dateCheckin { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public List<OrderDetail> orderDetail { get; set; }
        public int orderId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public List<TableModel> tables { get; set; }
        public string timeCheckin { get; set; }
        public string type { get; set; }
    }

    public class FoodOrder
    {

        public FoodOrder(Food item)
        {
            dishId = item.Id;
            note = item.Note;
            quantity = item.OrderQuantity;
        }

        public int dishId { get; set; }

        public string note { get; set; }

        public int quantity { get; set; }
    }
    public class PutOrder : BaseModel
    {
       public List<FoodOrder> dishes { get; set; }

        public PutOrder()
        {
            dishes = new List<FoodOrder>();
        }
    }
}
