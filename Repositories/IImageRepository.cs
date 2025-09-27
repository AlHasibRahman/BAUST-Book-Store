using System;
using BAUST_Book_Store.Models.Domain;

namespace BAUST_Book_Store.Repositories;

public interface IImageRepository
{
    Task<Image> UploadImageAsync(IFormFile file);
}
