import "../Styles/RegisterForm.css";
import { useState } from "react";
import { RegisterProps } from "../Interfaces/AuthProps";
import { EyeOff, Eye } from "lucide-react";
import { useAuthContext } from "../Context/AuthContext";
import { useNavigate } from "react-router-dom";
import StyledLink from "./StyledLink";
import toast, { Renderable, Toast, ValueFunction } from "react-hot-toast";
import { AxiosError } from "axios";


const RegisterForm: React.FC = () => {
  const navigate                          = useNavigate();
  const { register }                      = useAuthContext();
  const [showPassword, setShowPassword]   = useState(false);
  const [registerCreds, setRegisterCreds] = useState<RegisterProps>({
      username: "",
      email: "",
      password: ""
    });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setRegisterCreds({...registerCreds, [e.target.name]: [e.target.value]});
  }

  const handleRegister = async (e: React.FormEvent) => {
    try {
      e.preventDefault();
        await register(
          registerCreds.username[0],
          registerCreds.email[0],
          registerCreds.password[0]
        );
  
        toast.success("Login successful");
        navigate("/"); 
    }
    catch (err: any) {
      toast.error(err.response.data[0]);
    }
  }

  return (
      <div className="register-container">
        <form onSubmit={handleRegister}>
        <h2>Register</h2>
          <div className="input-container">
            <input
              required
              type="text"
              name="username"
              id="username"
              placeholder="Username"
              onChange={handleChange}
              />
              
            <input
              required
              type="text"
              name="email"
              id="email"
              placeholder="Email"
              onChange={handleChange}
              />

            <div className="password-wrapper">
                <input
                  required
                  type={showPassword ? "text" : "password"}
                  name="password"
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
          
          <button type="submit" className="submit-btn">
            Register
          </button>
          <h5>Already have an account ?  
                <StyledLink to="" route="/login">
                    Login here!
                </StyledLink>
            </h5>
        </form>
      </div>
  )
}

export default RegisterForm;