using System;
using System.ComponentModel.DataAnnotations;

namespace BAUST_Book_Store.Models.Dtos;

public class UploadImageRequestDto
{
    [Required]
    public IFormFile File { get; set; }
}
