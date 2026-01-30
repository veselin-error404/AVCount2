public class InvoiceItem
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPriceEUR { get; set; }

    public decimal TotalEUR => Quantity * UnitPriceEUR;
}
