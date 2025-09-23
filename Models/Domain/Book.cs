using System;

namespace BAUST_Book_Store.Models.Domain;

public class Book
{
    public int Id { get; set; }
    public string book_Name { get; set; }
    public string author_Name { get; set; }
    public string edition { get; set; }
    public string Description { get; set; }
    public string img_Url { get; set; }
    public string condition { get; set; }
    public double bookPrice { get; set; }
    public double rentPrice { get; set; }
    public bool isAvilable { get; set; }

}
