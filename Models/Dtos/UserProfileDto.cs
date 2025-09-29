using System;

namespace BAUST_Book_Store.Models.Dtos;

public class UserProfileDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
