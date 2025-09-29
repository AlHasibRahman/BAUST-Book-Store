using System;

namespace BAUST_Book_Store.Models.Domain;

public class Transaction
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsRent { get; set; }
    public DateTime? RentStartDate { get; set; }
    public DateTime? RentEndDate { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public long BuyerId { get; set; }
    public UserProfile Buyer { get; set; }

    public long SellerId { get; set; }
    // public UserProfile Seller { get; set; }  // No need..
                                                //Ef can not identify, cause Buyer & Seller belong same entity... 
}
