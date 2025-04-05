import React from "react";
import "../Styles/PurchasePage.css";
import Navbar from '../Components/Navbar';
import PurchasesTable from '../Components/PuchasesTable';

const PurchasesPage: React.FC = () => {
  return (
    <>
      <Navbar/>
      <h1 className="page-title">Purchases</h1>
      <hr className="purchase-hr" color="black"/>
      <PurchasesTable />
    </>
  )
}

export default PurchasesPage;