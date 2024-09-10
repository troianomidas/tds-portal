using WebApp.Constants;
using WebApp.Models.Collaborators;
using WebApp.Models.Customers;
using WebApp.Models.Stores;
using WebApp.Utils;

namespace WebApp.Models.Order;

public class OrderModel
{
    public int Id { get; set; }
    public long TrackId { get; set; }
    public int Number { get; set; }
    public int? PaymentMethodId { get; set; }
    public string? TableReference { get; set; }
    public int DeliveryTypeId { get; set; }
    public string? Obs { get; set; }
    public decimal TotalValue { get; set; }
    public decimal ItemsValue { get; set; }
    public decimal DeliveryValue { get; set; }
    public decimal DiscountValue { get; set; }
    public int DiscountType { get; set; }
    public DateTime DeliveryEstimateBeginAt { get; set; }
    public DateTime DeliveryEstimateEndAt { get; set; }
    public bool IsScheduled { get; set; }
    public bool IsOnlineMenu { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Status { get; set; }
    public int? CollaboratorId { get; set; }
    
    public bool IsSelected { get; set; }
    public bool IsLoading { get; set; }

    public List<OrderItemModel> Items { get; set; } = new();
    public PaymentMethodModel.PaymentMethodItemModel? PaymentMethod { get; set; }
    public ShippingAddressModel? ShippingAddress { get; set; }
    public CustomerModel? Customer { get; set; }
    public CollaboratorModal? Collaborator { get; set; }
    
    public decimal  GetTotalItemValue(Guid itemExternalId)
    {
        decimal totalItemValue = 0;

        foreach (var item in Items!.Where(x=> x.ExternalId == itemExternalId))
        {
            if (item.ExternalParentId != null)
                continue;
            
            totalItemValue = item.UnitValue * item.Amount;

            foreach (OrderItemModel extra in Items!.Where(x=> x.ExternalParentId == item.ExternalId))
            {
                var extraValue = extra.UnitValue * extra.Amount;
                totalItemValue += extraValue * item.Amount;
            }
        }

        return totalItemValue;
    }
    
    public void CalculateTotalValue()
    {
        ItemsValue = 0;
        TotalValue = 0;

        foreach (var item in Items)
        {
            if (item.ExternalParentId != null)
                continue;
            
            var value = item.UnitValue * item.Amount;

            foreach (var extra in Items.Where(x=> x.ExternalParentId == item.ExternalId))
            {
                decimal extraValue = extra.UnitValue * extra.Amount;
                value += extraValue * item.Amount;
            }

            ItemsValue += value;
        }

        TotalValue += ItemsValue;
        TotalValue += DeliveryValue;
        
        if (DiscountValue > 0 && DiscountType == OrderDiscountTypeConst.Percentage)
            TotalValue -= (DiscountValue * TotalValue) / 100;
        if (DiscountValue > 0 && DiscountType == OrderDiscountTypeConst.Value)
            TotalValue -= DiscountValue;
    }
    public string GetDeliveryType()
    {
        return DeliveryTypeId switch
        {
            OrderDeliveryTypeConst.Counter => "Balcão",
            OrderDeliveryTypeConst.Delivery => "Entrega",
            _ => "Retirada"
        };
    }
    public string GetDeliveryValue()
    {
        if (DeliveryTypeId != OrderDeliveryTypeConst.Delivery)
            return "-";
        
        return DeliveryValue == 0 ? "Grátis" : CurrencyUtils.MoneyFormat(DeliveryValue);
    }
}

public class OrderItemModel
{
    public Guid ExternalId { get; set; }
    public Guid? ExternalParentId { get; set; }
    public int ProductId { get; set; }
    public string? Item { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public decimal UnitValue { get; set; }
}