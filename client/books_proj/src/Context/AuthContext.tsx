import { useState, useEffect, useContext, createContext } from "react";
import { AuthContextProps, AuthContextProviderProps, User } from "../Interfaces/AuthProps";
import AuthApiService from "../Services/AuthService";



const AuthContext = createContext<AuthContextProps | null>(null);

const AuthContextProvider: React.FC<AuthContextProviderProps> = ({ children }) => {
    const [user, setUser] = useState<User | null>(null);

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (token) {
            AuthApiService.setAuthToken(token);
        }
    }, []);


    const login = async (username: string, password: string) => {
        const response = await AuthApiService.loginUser(username, password);
        
        const token = localStorage.getItem("token");
        if (token) {
            AuthApiService.setAuthToken(token);
        }

        setUser(response.data);
    }

    const register = async (username: string, email: string, password: string) => {
        await AuthApiService.registerUser(username, email, password);
        await login(username, password);
    }

    const logout = () => {
        setUser(null);
        localStorage.removeItem("token");
        AuthApiService.setAuthToken(null);
    }

    return (
        <AuthContext.Provider value={{user, login, logout, register}}>
            {children}
        </AuthContext.Provider>
    )
}


export const useAuthContext = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error ("useAuthContext must be used within the AuthContextProvider");
    }
    return context;
}


export default AuthContextProvider;