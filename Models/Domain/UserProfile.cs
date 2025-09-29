using System;

namespace BAUST_Book_Store.Models.Domain;

public class UserProfile
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    // Navigation
    public List<Book> Books { get; set; }   // Books owned by this student
    public List<Transaction> Transactions { get; set; } // Books rented/bought
}
