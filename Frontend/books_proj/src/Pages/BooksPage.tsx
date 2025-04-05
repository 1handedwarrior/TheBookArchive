import React, { useState, useEffect } from "react";
import "../Styles/BookPage.css";
import Navbar from '../Components/Navbar';
import BookApiService from '../Services/BookService';
import { BookProps } from "../Interfaces/BookProps";
import AddBookPage from "./AddBookPage";
import AuthApiService from "../Services/AuthService";
import toast from "react-hot-toast";



const BooksPage: React.FC = React.memo(() => {
  const [books, setBooks] = useState<BookProps[]>([]);

  const fetchBooks = async () => {
    try {
      const books = await BookApiService.getBooks();
  
      const booksWithImages = await Promise.all(
        books.map(async (book: { isbn: string }) => {
          const imageUrl = await BookApiService.getImage(book.isbn);
          return { ...book, image: imageUrl };
        })
      );

      // books.map((b: BookProps) => {
      //   console.log(b.id)
      // });
  
      setBooks(booksWithImages);
    } 
    catch (err) {
      console.error("Error fetching books:", err);
    }
  };

  const deleteBook = async (id?: number) => {
    const deletion = await BookApiService.deleteBook(id);
    if (deletion !== 204) {
      toast.error("Error deleting book");
    }
    
    const book = books.filter(b => b.id === id);
    toast.success(`${book[0].title} deleted successfully`);
    setBooks(books => books.filter(b => b.id !== id));
  } 

  useEffect(() => {
    fetchBooks();
  }, []);

  return (
    <>
    <Navbar />
    <div className="books-container">
      <h1 className="bookpage-title">Book Collection</h1>

      <hr color=""/>
      <div className="books-grid">
        {books.map((book) => (
          <div key={book.id} className="book-card">
            <img src={book.image} alt={book.title} className="book-image" />
            <div className="book-info">
              <h2 className="book-title">{book.title}
              <button onClick={() => deleteBook(book.id)}>🗑️</button>
              </h2>
              <h4 className="book-author">Author: {book.author}</h4>
              <p className="book-summary">{book.summary}</p>
              <p className="book-date"><strong>Published:</strong> {book.publishedOn}</p>
            </div>
          </div>
        ))}
      </div>
      <AddBookPage/>
    </div>
  </>
  )
})

export default BooksPage;