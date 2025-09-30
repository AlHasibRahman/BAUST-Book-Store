using System;
using System.ComponentModel.DataAnnotations;

namespace BAUST_Book_Store.Models.Dtos;

public class CreateBookDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Book name max legth should be 30 character")]
    [MinLength(3, ErrorMessage = "Book name minimum legth should be 3 character")]
    public string book_Name { get; set; }
    [Required]
    [MaxLength(30, ErrorMessage = "Book name max legth should be 30 character")]
    [MinLength(3, ErrorMessage = "Book name minimum legth should be 3 character")]
    public string author_Name { get; set; }
    [Required]
    [MaxLength(10, ErrorMessage = "Book name max legth should be 10 character")]
    [MinLength(3, ErrorMessage = "Book name minimum legth should be 3 character")]
    public string edition { get; set; }
    [MaxLength(100, ErrorMessage = "Book name max legth should be 100 character")]
    public string? Description { get; set; }
    [Required]
    public string img_Url { get; set; }
    [Required]
    [MaxLength(10, ErrorMessage = "Book name max legth should be 10 character")]
    [MinLength(3, ErrorMessage = "Book name minimum legth should be 3 character")]
    public string condition { get; set; }
    [Required]
    public decimal bookPrice { get; set; }
    public decimal? rentPrice { get; set; }
    [Required]
    public bool isAvilable { get; set; }
    [Required]
    public long OwnerId { get; set; }

}
