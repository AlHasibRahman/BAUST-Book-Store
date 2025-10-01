import { createBrowserRouter, type RouteObject } from "react-router-dom";
import App from "../App";
import BookForm from "../components/books/BookForm";
import BookTable from "../components/books/BookTable";

export const routes : RouteObject[] = [
    {
        path : '/',
        element : <App/>,
        children : [
            {path: 'createBook', element: <BookForm key={'create'}/>},
            {path: 'editBook/:id', element: <BookForm key={'edit'}/>},
            {path: '*', element: <BookTable />}
        ]
    }
]

export const router = createBrowserRouter(routes);