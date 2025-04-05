import "../Styles/LoginForm.css";
import StyledLink from "./StyledLink";
import React, { useState } from "react";
import { Eye, EyeOff } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { LoginProps } from "../Interfaces/AuthProps";
import { useAuthContext } from "../Context/AuthContext";
import toast from "react-hot-toast";

const LoginForm: React.FC = () => {
    const { user, login }                       = useAuthContext();
    const navigate                        = useNavigate();
    const [showPassword, setShowPassword] = useState<boolean>(false);
    const [loginCreds, setLoginCreds]     = useState<LoginProps>({
        username: "",
        password: ""
    });

    const handleLogin = async (e: React.FormEvent) => {
        try {
            e.preventDefault();
            await login(loginCreds.username, loginCreds.password);
            
            toast.success("Login Successful");
            navigate("/");
        }
        catch (err: any) {
            toast.error(err.response.data);
            setLoginCreds({
                username: "",
                password: ""
            });
            console.log(loginCreds);
            
        }
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
          setLoginCreds(prev => ({ ...prev, [e.target.name]: [e.target.value] }));
        };

  return (
    <div className="loginForm-container">
        <form onSubmit={handleLogin}>
            <h2>Login</h2>
            <div className="input-container">
                <input
                    required
                    type="text"
                    name="username"
                    id="username"
                    placeholder="Username"
                    onChange={handleChange}
                />

                <div className="password-wrapper">
                    <input
                        required
                        type={showPassword ? "text" : "password"}
                        name="password"
                        id="password"
                        placeholder="Password"
                        onChange={handleChange}
                    />
                    <button
                        type="button"
                        className="visibility-btn"
                        onClick={() => setShowPassword(!showPassword)}
                    >
                        {showPassword ? <EyeOff  /> : <Eye  />}
                    </button>
                </div>
            </div>

            <button type="submit" className="login-btn">
                Login
            </button>

            <h5>Don't have an account ?  
                <StyledLink to="" route="/register">
                    Register here!
                </StyledLink>
            </h5>
        </form>
    </div>
  )
}

export default LoginForm;