namespace Model.Models.Order
{
    public class Customer
    {
        public int customerId { get; set; }
        public UserInfo userInfo { get; set; }
        public string code { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string level { get; set; }
        public int point { get; set; }
        public string status { get; set; }  
    }
}