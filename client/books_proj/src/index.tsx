import './index.css';
import App                 from './App';
import React               from 'react';
import ReactDOM            from 'react-dom/client';
import { Toaster }         from 'react-hot-toast';
import reportWebVitals     from './reportWebVitals';
import { BrowserRouter }   from "react-router-dom";
import { ErrorBoundary }   from 'react-error-boundary';
import AuthContextProvider from './Context/AuthContext';
import ErrorFallback       from "./ErrorHandling/ErrorBoundary";

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
    <Toaster />
    <ErrorBoundary 
      FallbackComponent={ErrorFallback}
      onError={(error, info) => {
        console.error("Global error: ", error);
        console.error("Component Stack: ", info.componentStack);
      }}>
      <BrowserRouter>
        <AuthContextProvider>
          <App />
        </AuthContextProvider>
      </BrowserRouter>
    </ErrorBoundary>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
