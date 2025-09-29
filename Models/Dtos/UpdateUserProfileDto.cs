using System;
using System.ComponentModel.DataAnnotations;

namespace BAUST_Book_Store.Models.Dtos;

public class UpdateUserProfileDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Book name max legth should be 30 character")]
    [MinLength(3, ErrorMessage = "Book name minimum legth should be 3 character")]
    public string FullName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    //[Phone]
    [RegularExpression(@"^(?:\+88)?01[3-9]\d{8}$",
    ErrorMessage = "Phone number must be a valid Bangladeshi number.")]
    public string PhoneNumber { get; set; }
}
