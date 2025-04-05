import './App.css';
import { lazy, Suspense } from 'react';
import { Route, Routes } from 'react-router-dom';

import HomePage from './Pages/HomePage';
const LoginPage     = lazy(() => import("./Pages/LoginPage"));
const RegisterPage  = lazy(() => import("./Pages/RegisterPage"));
const BooksPage     = lazy(() => import("./Pages/BooksPage"));
const PurchasesPage = lazy(() => import("./Pages/PurchasesPage"));
const DashboardPage = lazy(() => import("./Pages/DashboardPage"));

function App() {
  return (
    <Suspense fallback={<div>Loading...</div>}>
      <Routes>
        <Route path="/"          element={<HomePage />}/>
        <Route path="/books"     element={<BooksPage />}/>
        <Route path="/purchases" element={<PurchasesPage />}/>
        <Route path="/login"     element={<LoginPage />}/>
        <Route path="/register"  element={<RegisterPage />}/>
        <Route path="/dashboard" element={<DashboardPage/>}/>
      </Routes>
    </Suspense>
  );
}

export default App;