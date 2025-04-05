import "../Styles/PurchasePage.css";
import { useState, useEffect } from "react";
import { PurchaseProps } from "../Interfaces/PurchaseProps";
import PurchaseApiService from "../Services/PurchaseService";


const PurchasesTable: React.FC = () => {
    const [purchases, setPurchases] = useState<PurchaseProps[]>([]);

    const fetchPurchases = async () => {
        try {
            const purchases = await PurchaseApiService.getPurchases();
            setPurchases(purchases);
        }
        catch (err) {
            console.error(err);
            throw err;
        }
    }
    
    useEffect(() => {
        fetchPurchases();
    }, []);
    

    return (
        <div className="purchasesTable">
        <table>
            <thead>
                <tr>
                    <th>Books</th>
                    <th>Total</th>
                    <th>Date Purchased</th>
                </tr>
            </thead>
            <tbody>
                {purchases.map((purchase) => (
                    <tr key={purchase.id}>
                        <td data-label="Books">
                                {purchase.books.map((b) => (
                                <div key={b.id}> {b.title} </div>
                            ))}
                        </td>
                        <td data-label="Total">$ {purchase.total}</td>
                        <td data-label="Date Purchased">
                            {purchase.purchasedOn.substring(0, 10)}
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
    )
}

export default PurchasesTable;