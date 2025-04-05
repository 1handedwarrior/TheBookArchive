import axios from "axios";
import { BookProps } from "../Interfaces/BookProps";

const BOOK_IMAGE_API = "https://www.googleapis.com/books/v1/volumes?q=isbn:";

const api = axios.create({
    baseURL: "http://localhost:5030/api/books"
});

api.interceptors.request.use(config => {
    config.headers["Content-Type"] = "application/json";
    return config;
});

const BookApiService = {
    getBooks: async () => {
        try {
            const response = await api.get("/");
            return response.data;
        }
        catch (err) {
            console.error("Error fetching books: ", err);
            throw err;
        }
    },
    getBook: async (id: number) => {
        try {
            const response = await api.get(`/${id}`);
            return response.data;
        }
        catch (err) {
            console.error(`Error fetching book with id: ${id}`, err);
            throw err;
        }
    },
    addBook: async (book: BookProps) => {
        try {
            const response = await api.post("/", book);
            return response.data;
        }
        catch (err) {
            console.error("Error adding book: ", err);
            throw err;
        }
    },
    updateBook: async (id: number, book: BookProps) => {
        try {
            const response = await api.put(`/${id}`, book);
            return response.data;
        }
        catch (err) {
            console.error(`Error updating book with id: ${id}`, err);
            throw err;
        }
    },
    deleteBook: async (id?: number) => {
        try {
            const response = await api.delete(`/${id}`);
            return response.status;
        }
        catch (err) {
            console.error(`Error deleting book with id: ${id}`, err);
            throw err;
        }
    },
    getImage: async (isbn: string) => {
        try {
            const response = await axios.get(`${BOOK_IMAGE_API}${isbn}`);
            return response.data.items[0].volumeInfo.imageLinks.thumbnail;
        } 
        catch (err) {
            console.error("Error fetching book image:", err);
            throw err;
        }
    },
}


export default BookApiService;