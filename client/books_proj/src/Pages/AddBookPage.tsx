import "../Styles/AddBookPage.css";
import toast from "react-hot-toast";
import React, { useState } from "react";
import ApiService from "../Services/BookService";
import { BookProps } from "../Interfaces/BookProps";

const AddBookPage: React.FC = () => {
    const [book, setBook] = useState<BookProps>({
      title: "",
      author: "",
      summary: "",
      isbn: "",
      publishedOn: "",
    });
    
    // State to control modal visibility
    const [isModalOpen, setIsModalOpen] = useState(false);
  
    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
      setBook({ ...book, [e.target.name]: e.target.value });
    };
  
    const handleSubmit = async (e: React.FormEvent) => {
      e.preventDefault();
      try {
        await ApiService.addBook(book);
        toast.success("Book added successfully!");
        setBook({
          title: "",
          author: "",
          summary: "",
          isbn: "",
          publishedOn: "",
        });
        setIsModalOpen(false); // Close the modal on success
      } 
      catch (error) {
        console.error("Error adding book:", error);
      }
    };
  
    // Open the modal
    const openModal = () => {
      setIsModalOpen(true);
      // Prevent background scrolling
      document.body.style.overflow = 'hidden';
    };
  
    // Close the modal
    const closeModal = () => {
      setIsModalOpen(false);
      // Re-enable background scrolling
      document.body.style.overflow = '';
    };
  
    return (
      <div className="container">
        <button className="btn-open-modal" onClick={openModal}>Add New Book</button>
        
        {/* Modal Overlay */}
        <div className={`modal-overlay ${isModalOpen ? 'open' : ''}`}>
          <div className="modal-content">
            <div className="modal-header">
              <h2>Add a New Book</h2>
              <button className="modal-close" onClick={closeModal}>&times;</button>
            </div>
            
            <div className="modal-body">
              <form onSubmit={handleSubmit}>
                <div className="form-group">
                  <label htmlFor="title">Title:</label>
                  <input
                    type="text"
                    id="title"
                    name="title"
                    value={book.title}
                    onChange={handleChange}
                    required
                  />
                </div>
                
                <div className="form-group">
                  <label htmlFor="author">Author:</label>
                  <input
                    type="text"
                    id="author"
                    name="author"
                    value={book.author}
                    onChange={handleChange}
                    required
                  />
                </div>
                
                <div className="form-group">
                  <label htmlFor="summary">Summary:</label>
                  <textarea
                    id="summary"
                    name="summary"
                    value={book.summary}
                    onChange={handleChange}
                    required
                    rows={4}
                  />
                </div>
                
                <div className="form-group">
                  <label htmlFor="isbn">ISBN:</label>
                  <input
                    type="text"
                    id="isbn"
                    name="isbn"
                    value={book.isbn}
                    onChange={handleChange}
                    required
                    minLength={8}
                  />
                </div>
                
                <div className="form-group">
                  <label htmlFor="publishedOn">Published On:</label>
                  <input
                    type="date"
                    id="publishedOn"
                    name="publishedOn"
                    value={book.publishedOn}
                    onChange={handleChange}
                    required
                  />
                </div>
                
                <div className="modal-footer">
                  <button type="button" className="btn-cancel" onClick={closeModal}>Cancel</button>
                  <button type="submit" className="btn-submit">Add Book</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  };
  
  export default AddBookPage;