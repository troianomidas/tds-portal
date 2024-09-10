using WebApp.Models.Financials.Charts;

namespace WebApp.Models.Financials;

public class DashboardFinancialModel
{
    public int TotalOrders { get; set; }
    public decimal GrossValue { get; set; }
    // public decimal NetValue { get; set; }
    // public decimal OnlineValue { get; set; }
    // public decimal StoreValue { get; set; }
    public List<decimal> HistoryProfitsPerDate { get; set; } = new();
    public List<string> HistoryDates { get; set; } = new();
    
    // public List<PineChartValuesModel> PineChartValueModels { get; set; } = new();
}