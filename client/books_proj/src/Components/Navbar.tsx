import React from "react";
import StyledLink from "./StyledLink";
import "../Styles/Navbar.css";
import { useAuthContext } from "../Context/AuthContext";




const Navbar: React.FC = () => {
    const { user } = useAuthContext();

    return (
        <div className="navbar">
            <StyledLink route="/" to="">
                Home
            </StyledLink>

            <StyledLink route="/books" to="">
                Books
            </StyledLink>
            
            <StyledLink route={user ? "/dashboard" : "/login"} to="">
                {user ? user.username : "Login | Register"}
            </StyledLink>
        </div>
    );
}

export default Navbar
