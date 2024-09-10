namespace WebApp.Constants;

public struct Orders
{
    public const string StoreActive = "store-subscription-active";
}

public struct OrderStatusConst
{
    public const int Pending = 1;
    public const int Confirmed = 2;
    public const int Preparation = 3;
    public const int Delivery = 4;
    public const int Finished = 5;
    public const int Canceled = 9;
}

public struct OrderDeliveryTypeConst
{
    public const int Delivery = 1;
    public const int Withdraw = 2;
    public const int Counter =3;
}

public struct OrderDiscountTypeConst
{
    public const int None = 1;
    public const int Percentage = 2;
    public const int Value =3;
}