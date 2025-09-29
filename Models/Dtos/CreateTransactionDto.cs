using System;

namespace BAUST_Book_Store.Models.Dtos;

public class CreateTransactionDto
{
    public bool IsRent { get; set; }
    public DateTime? RentStartDate { get; set; }
    public DateTime? RentEndDate { get; set; }

    public long BookId { get; set; }

    public long BuyerId { get; set; }

    public long SellerId { get; set; }
}
