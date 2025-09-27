using System;
using BAUST_Book_Store.Data;
using BAUST_Book_Store.Models.Domain;

namespace BAUST_Book_Store.Repositories;

public class LocalImageRepository : IImageRepository
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly BookExchangeDbContext dbContext;
    public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, BookExchangeDbContext dbContext)
    {
        this.webHostEnvironment = webHostEnvironment;
        this.httpContextAccessor = httpContextAccessor;
        this.dbContext = dbContext;
    }
    public async Task<Image> UploadImageAsync(IFormFile file)
    {
        // Ensure Images folder exists
        var imagesFolder = Path.Combine(webHostEnvironment.ContentRootPath, "Images");
        if (!Directory.Exists(imagesFolder))
            Directory.CreateDirectory(imagesFolder);

        // Generate unique file name (to avoid overwrites)
        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePathOnDisk = Path.Combine(imagesFolder, uniqueFileName);

        // Save file to disk
        using (var fileStream = new FileStream(filePathOnDisk, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // Build absolute URL for client access
        var request = httpContextAccessor.HttpContext.Request;
        var fileUrl = $"{request.Scheme}://{request.Host}{request.PathBase}/Images/{uniqueFileName}";

        // Create Image entity
        var newImage = new Image
        {
            FileName = Path.GetFileNameWithoutExtension(file.FileName),
            FileExtension = Path.GetExtension(file.FileName),
            FileSizeInBytes = file.Length,
            FilePath = fileUrl
        };

        // Save to DB
        await dbContext.Images.AddAsync(newImage);
        await dbContext.SaveChangesAsync();

        return newImage;
    }



}
