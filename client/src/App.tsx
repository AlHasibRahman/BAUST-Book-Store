import { Outlet, useLocation } from "react-router-dom";
import BookTable from "./components/books/BookTable";
import { Container } from "semantic-ui-react";

export default function App() {
  const location = useLocation();

  return (
    <>
      {location.pathname === '/' ? <BookTable /> :(
        <Container className="container-style">
          <Outlet/>
        </Container>
      )}
    </>
  )
}
