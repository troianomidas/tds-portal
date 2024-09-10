namespace WebApp.Models.Stores;

public class PaymentMethodModel
{
    public PaymentMethodModel()
    {
        PaymentMethods = new List<StorePaymentMethodModel>();
        AllPaymentMethods = new List<PaymentMethodItemModel>();
    }
    
    public List<PaymentMethodItemModel> AllPaymentMethods { get; set; }
    public List<StorePaymentMethodModel> PaymentMethods { get; set; }
    
    public class PaymentMethodItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsOnline { get; set; }
        public string? ImgUrl { get; set; }
    }

    public class StorePaymentMethodModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int PaymentMethodId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

