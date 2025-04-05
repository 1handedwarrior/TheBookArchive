import Navbar from "./Navbar";
import { useAuthContext } from "../Context/AuthContext";
import { useNavigate } from "react-router-dom";
import toast from "react-hot-toast";

const DashboardHeader: React.FC = () => {
  const { user, logout } = useAuthContext();
  const navigate         = useNavigate();
  
  const handleLogout = () => {
    logout();
    navigate("/");
    toast.success("Successfully logged out");
  }
  return (
    <>
    <Navbar/>
    <div>
      <h2 className="dashboard-header">
        Welcome {user?.username}
      </h2>
      <button
        className="logout-btn" 
        onClick={() => handleLogout()}>
        Logout
      </button>
    </div>
    </>
  )
}

export default DashboardHeader;