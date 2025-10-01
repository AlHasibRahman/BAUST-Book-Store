export interface UpdateBookDto {
    book_Name : string,
    author_Name : string,
    edition : string,
    description : string | undefined,
    img_Url : string,
    condition : string,
    bookPrice : number,
    rentPrice : number | undefined,
    isAvilable : boolean

}