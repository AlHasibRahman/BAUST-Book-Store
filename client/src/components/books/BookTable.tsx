import { useEffect, useState } from "react"

import ApiConnector from "../../api/ApiConnector";
import type { BookDto } from "../../models/BookDto";
import { Button, Container } from "semantic-ui-react";
import BookTableItem from "./BookTableItem";
import { NavLink } from "react-router-dom";


export default function BookTable() {
    const [Books, setBooks] = useState<BookDto[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const fetchedBooks = await ApiConnector.getBooks(); // already typed
        setBooks(fetchedBooks);
      } catch (error) {
        console.error("Failed to fetch books:", error);
      }
    };

    fetchData();
  }, []);


    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style={{ textAlign: "center" }}>
                        <tr>
                            <th>ID</th>
                            <th>Book-Name</th>
                            <th>Author-Name</th>
                            <th>Edition</th>
                            <th>Description</th>
                            <th>Condition</th>
                            <th>Book-Price</th>
                            <th>Rent-Price</th>
                            <th>Avilable</th>
                            <th>OwnerId</th>
                        </tr>
                    </thead>
                    <tbody>
                        {Books.length !== 0 &&
                            Books.map((book, index) => (
                                <BookTableItem key={index} book={book} />
                            ))
                        }
                    </tbody>
                </table>
                <Button as={NavLink} to={`createBook`} floated="right" type="button" content="Create Book" positive />

            </Container >
        </>
    )
}
