import React from "react";
import "../Styles/HomePage.css";
import Navbar from "../Components/Navbar";

const HomePage: React.FC = () => {
  return (
    <>
      <Navbar/>
      <div className="home-container">
        <header className="hero-section">
          <h1>Welcome To Your Book Archive</h1>
          <p>Manage your book collection with ease.</p>
          <button className="cta-button">Get Started</button>
        </header>

        <section className="features">
          <div className="feature-card">
            <h2>Create</h2>
            <p>Add new books to your collection effortlessly.</p>
          </div>
          <div className="feature-card">
            <h2>Read</h2>
            <p>View details and descriptions of your books.</p>
          </div>
          <div className="feature-card">
            <h2>Update</h2>
            <p>Edit book details to keep your collection accurate.</p>
          </div>
          <div className="feature-card">
            <h2>Delete</h2>
            <p>Remove books you no longer need.</p>
          </div>
        </section>
      </div>
    </>
  )
}

export default HomePage;