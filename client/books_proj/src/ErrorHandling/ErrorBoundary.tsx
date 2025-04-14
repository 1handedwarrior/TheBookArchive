import "../ErrorHandling/ErrorBoundary.css";

interface ErrorFallbackProps {
    error: Error | any;
    resetErrorBoundary: () => void;
}


const ErrorFallback: React.FC<ErrorFallbackProps> = ({ error, resetErrorBoundary }) => {
    return (
        <div role="alert" className="error-container">
            <h2> Oops! Something went wrong </h2>
            
            <div className="error-message">
                {/* {error.message} */}
                Error in string literal form
            </div>
            
            <button className="error-button" onClick={resetErrorBoundary}>
                Try again
            </button>
        </div>
    )
};

export default ErrorFallback;