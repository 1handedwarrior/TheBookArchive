import React from 'react';
import "../Styles/Navbar.css";
import { Link, LinkProps } from 'react-router-dom';

interface StyledLinkProps extends LinkProps {
    route: string
}


const StyledLink: React.FC<StyledLinkProps> = ({ children, route }) => {
  return (
    <Link className="StyledLink" to={route}>
      {children}
    </Link>
  )
}

export default StyledLink
