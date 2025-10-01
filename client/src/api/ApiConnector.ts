import type { AxiosResponse } from "axios";
import axios from "axios";
import { API_BASE_URL } from "./config";
import type { BookDto } from "../models/BookDto";
import type { CreateBookDto } from "../models/CreateBookDto";
import type { UpdateBookDto } from "../models/UpdateBookDto";


const ApiConnector = {
    getBooks: async (): Promise<BookDto[]> => {
        try {
            const response: AxiosResponse<BookDto[]> =
                await axios.get(`${API_BASE_URL}/api/Book`);
            return response.data;
        } catch (error) {
            console.error("Error fetching Books:", error);
            throw error;
        }
    },

    getBookById: async (id: string): Promise<BookDto> => {
        try {
            const response: AxiosResponse<BookDto> =
                await axios.get(`${API_BASE_URL}/api/Book/${id}`);
            return response.data;
        } catch (error) {
            console.error("Error fetching Book:", error);
            throw error;
        }
    },

    createBook: async (book: CreateBookDto): Promise<BookDto> => {
        try {
            const response: AxiosResponse<BookDto> =
                await axios.post(`${API_BASE_URL}/api/Book`, book);
            return response.data;
        } catch (error) {
            console.error("Error Create Book:", error);
            throw error;
        }
    },

    updateBook: async (id: string, book: UpdateBookDto): Promise<BookDto> => {
        try {
            const response: AxiosResponse<BookDto> =
                await axios.put(`${API_BASE_URL}/api/Book/${id}`, book);
            return response.data;
        } catch (error) {
            console.error("Error update Book:", error);
            throw error;
        }
    },

    deleteBook: async (id: number): Promise<void> => {
        try {
            await axios.delete(`${API_BASE_URL}/api/Book/${id}`);
        } catch (error) {
            console.log("Error delete Book: ", error);
            throw error;
        }
    },

    uploadImage: async (file: File): Promise<string> => {
        const formData = new FormData();
        formData.append("File", file);

        const response = await axios.post(
            `${API_BASE_URL}/api/image/upload`,
            formData,
            { headers: { "Content-Type": "multipart/form-data" } }
        );

        return response.data.url;
    }


};

export default ApiConnector;
