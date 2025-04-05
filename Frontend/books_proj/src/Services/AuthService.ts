import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5030/api/auth"
});

api.interceptors.request.use(config => {
    config.headers["Content-Type"] = "application/json";
    return config;
});

const AuthApiService = {
    loginUser: async (username: string, password: string) => {
        try {
            const response = await api.post("/login", { username, password });
            return response;
        }
        catch (err) {
            console.error("Error loggin in: ", err);
            throw err;
        }
    },
    registerUser: async (username: string, email: string, password: string) => {
        try {
            const response = await api.post("/register", { username, email, password });
            
            const user = response.data;
            
            if (!user || !user.token) {
                throw new Error("Invalid response from server");
            }
            localStorage.setItem("token", user.token);
            
            return response.data;
        }
        catch (err) {
            console.error("Error registering user: ", err);
            throw err;
        }
    },
    setAuthToken: (token: string | null) => {
        if (token) {
            axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
        }
        else {
            delete axios.defaults.headers.common["Authorization"];
        }
    }
}


export default AuthApiService;