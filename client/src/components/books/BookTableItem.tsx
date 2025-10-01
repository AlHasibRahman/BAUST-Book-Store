import { Button } from "semantic-ui-react"
import type { BookDto } from "../../models/BookDto"
import ApiConnector from "../../api/ApiConnector"
import { NavLink } from "react-router-dom"

interface Props {
    book: BookDto
}
export default function BookTableItem({ book }: Props) {
    return (
        <>
            <tr className="center aligned">
                <td data-label="Id">{book.id}</td>
                <td data-label="Book-Name">{book.book_Name}</td>
                <td data-label="Author-Name">{book.author_Name}</td>
                <td data-label="Edition">{book.edition}</td>
                <td data-label="Description">{book.description}</td>
                <td data-label="Condition">{book.condition}</td>
                <td data-label="Book-Price">{book.bookPrice}</td>
                <td data-label="Rent-Price">{book.rentPrice}</td>
                <td data-label="Avilable">{book.isAvilable ? "Yes" : "No"}</td>
                <td data-label="OwnerId">{book.ownerId}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`editBook/${book.id}`} color="yellow" type="submit">
                        Edit
                    </Button>
                    <Button color="red" type="button" negative onClick={async () => {
                        await ApiConnector.deleteBook(book.id!);
                        window.location.reload();
                    }}>
                        Delete
                    </Button>
                </td>
            </tr>
        </>
    )
}
