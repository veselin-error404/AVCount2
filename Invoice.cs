using AVCount;
using System;
using System.Collections.Generic;
public enum PaymentMethod
{
    Cash,
    Bank
}

public class Invoice
{
    public string InvoiceNumber { get; set; }
    public DateTime Date { get; set; }

    public string SellerName { get; set; }
    public string SellerEIK { get; set; }
    public string SellerVAT { get; set; }
    public string SellerCity { get; set; }
    public string SellerMOL { get; set; }
    public string SellerPhone { get; set; }
    public string SellerAddress { get; set; }

    public string BuyerName { get; set; }
    public string BuyerEIK { get; set; }
    public string BuyerVAT { get; set; }
    public string BuyerCity { get; set; }
    public string BuyerMOL { get; set; }
    public string BuyerPhone { get; set; }
    public string BuyerAddress { get; set; }

    public List<InvoiceItem> Items { get; set; }
    public bool ShowBothCurrencies { get; set; }

    public PaymentMethod PaymentMethod { get; set; } // <-- Add this
    public string BankName { get; set; }
    public string IBAN { get; set; }
    public string BIC { get; set; }
}
