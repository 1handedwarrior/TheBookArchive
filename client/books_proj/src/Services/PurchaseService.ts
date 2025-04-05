import axios from "axios";
import { PurchaseProps } from "../Interfaces/PurchaseProps";

const api = axios.create({
    baseURL: "http://localhost:5030/api/purchases"
});

api.interceptors.request.use(config => {
    config.headers["Content-Type"] = "application/json"
    return config;
});



const PurchaseApiService = {
    getPurchases: async () => {
        try {
            const response = await api.get("/");
            return response.data;
        }
        catch (err) {
            console.error("Error fetching books..", err);
            throw err;
        }
    },
    getPurchase: async (id: number) => {
        try {
            const response = await api.get(`/${id}`);
            return response.data;
        }
        catch (err) {
            console.error(`Error fetching book with id: ${id}`, err);
            throw err;
        }
    },
    addPurchase: async (purchase: PurchaseProps) => {
        try {
            const response = await api.post("/", purchase);
            return response.data;
        }
        catch (err) {
            console.error(err);
            throw err;
        }
    },
    updatePurchase: async (id: number, purchase: PurchaseProps) => {
        try {
            const response = await api.put(`/${id}`, purchase);
            return response.data;
        }
        catch (err) {
            console.error(`Error updating purchase with id: ${id}`, err);
            throw err;
        }
    },
    deletePurchase: async (id: number) => {
        try {
            const response = await api.delete(`/${id}`);
            return response.data;
        }
        catch (err) {
            console.error(`Error deleting purchase with id: ${id}`, err);
            throw err;
        }
    }
}

export default PurchaseApiService;