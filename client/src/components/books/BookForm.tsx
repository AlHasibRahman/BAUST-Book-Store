import { useEffect, useState, type ChangeEvent, type FormEvent } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import { Button, Form, Segment } from "semantic-ui-react";
import type { BookDto } from "../../models/BookDto";
import ApiConnector from "../../api/ApiConnector";
import type { CreateBookDto } from "../../models/CreateBookDto";
import type { UpdateBookDto } from "../../models/UpdateBookDto";

export default function BookForm() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [book, setBook] = useState<BookDto>({
    id: undefined,
    book_Name: "",
    author_Name: "",
    edition: "",
    description: "",
    img_Url: "",
    condition: "",
    bookPrice: 0,
    rentPrice: 0,
    isAvilable: true, // renamed from isAvilable
    ownerId: 0
  });

  const [selectedFile, setSelectedFile] = useState<File | null>(null);

  // Load existing book for edit
  useEffect(() => {
    if (id) {
      ApiConnector.getBookById(id).then((b) => b && setBook(b));
    }
  }, [id]);

  // Handle form field changes
  function handleChanges(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) {
    const { name, value, type } = event.target;

    setBook((prev) => ({
      ...prev,
      [name]:
      name === "isAvilable" // convert string to boolean
        ? value === "true"
        : type === "number"
        ? Number(value)
        : value
    }));
  }

  // Handle file selection
  function handleFileChange(event: ChangeEvent<HTMLInputElement>) {
    if (event.target.files && event.target.files.length > 0) {
      setSelectedFile(event.target.files[0]);
    }
  }

  // Handle submit
  async function handleSubmit(event: FormEvent) {
    event.preventDefault();

    let imageUrl = book.img_Url;

    if (selectedFile) {
      // Upload new image and get URL
      imageUrl = await ApiConnector.uploadImage(selectedFile);
    }

    if (!book.id) {
      // Create new book
      const createBookDto: CreateBookDto = {
        book_Name: book.book_Name,
        author_Name: book.author_Name,
        edition: book.edition,
        description: book.description || undefined,
        img_Url: imageUrl,
        condition: book.condition,
        bookPrice: book.bookPrice,
        rentPrice: book.rentPrice,
        isAvilable: book.isAvilable,
        OwnerId: book.ownerId
      };

      await ApiConnector.createBook(createBookDto);
      navigate("/");
    } else {
      // Update existing book
      const updateBookDto: UpdateBookDto = {
        book_Name: book.book_Name,
        author_Name: book.author_Name,
        edition: book.edition,
        description: book.description || undefined,
        img_Url: imageUrl,
        condition: book.condition,
        bookPrice: book.bookPrice,
        rentPrice: book.rentPrice,
        isAvilable: book.isAvilable
      };

      await ApiConnector.updateBook(id!, updateBookDto);
      navigate("/");
    }
  }

  return (
    <Segment clearing inverted>
      <Form onSubmit={handleSubmit} autoComplete="off" className="ui inverted form">
        <Form.Field>
          <label>Book Name</label>
          <input name="book_Name" value={book.book_Name} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Author Name</label>
          <input name="author_Name" value={book.author_Name} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Edition</label>
          <input name="edition" value={book.edition} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Description</label>
          <textarea name="description" value={book.description} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Book Image</label>
          <input type="file" accept="image/*" onChange={handleFileChange} />
          {book.img_Url && !selectedFile && (
            <img src={book.img_Url} alt="Book" style={{ width: "120px", marginTop: "5px" }} />
          )}
          {selectedFile && (
            <p style={{ marginTop: "5px" }}>{selectedFile.name} selected</p>
          )}
        </Form.Field>

        <Form.Field>
          <label>Condition</label>
          <input name="condition" value={book.condition} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Book Price</label>
          <input type="number" name="bookPrice" value={book.bookPrice} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Rent Price</label>
          <input type="number" name="rentPrice" value={book.rentPrice} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Owner ID</label>
          <input type="number" name="ownerId" value={book.ownerId} onChange={handleChanges} />
        </Form.Field>

        <Form.Field>
          <label>Is Available</label>
          <select name="isAvilable" value={book.isAvilable.toString()} onChange={handleChanges}>
            <option value="true">Yes</option>
            <option value="false">No</option>
          </select>
        </Form.Field>

        <Button floated="right" positive type="submit">
          Submit
        </Button>
        <Button as={NavLink} to="/" floated="right" type="button">
          Cancel
        </Button>
      </Form>
    </Segment>
  );
}
