using System;


namespace BAUST_Book_Store.Models.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsRent { get; set; }
    public DateTime? RentStartDate { get; set; }
    public DateTime? RentEndDate { get; set; }
    public BookDto Book { get; set; }
    public UserProfileDto Buyer { get; set; }
    public long SellerId { get; set; }
}
