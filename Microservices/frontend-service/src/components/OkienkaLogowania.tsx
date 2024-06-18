import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/css/bootstrap.css";
import { useCurrentUser } from "../contexts/CurrentUserContext";
import authConnector from "../api/authConnector";
import UserCredentials from "../api/dtos/auth/userCredentials";
import jwtVerificator from "../auth/jwtVerificator";
import databaseConnector from "../api/databaseConnector";

const AUTH_API_DOMAIN = "http://localhost:5098";

function StronaStartowa() {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const { setCurrentUser } = useCurrentUser();

  const containerStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    backgroundColor: "#FBFBFB",
    paddingTop: "10em",
  };

  const headerStyle: React.CSSProperties = {
    fontFamily: "Advent Pro, sans-serif",
    color: "#5B40FF",
    fontSize: "100px",
    textAlign: "center",
    textDecoration: "underline",
    textDecorationThickness: "4px",
    textDecorationColor: "#2D2D2D",
  };

  const subHeaderStyle: React.CSSProperties = {
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: "25px",
    textAlign: "center",
    margin: "20px 0",
  };

  const inputStyle: React.CSSProperties = {
    width: "300px",
    height: "40px",
    margin: "10px 0",
    padding: "10px",
    fontSize: "16px",
    borderRadius: "10px",
    border: "1px solid #000",
    boxShadow: "0px 4px 4px 0px #00000040",
    outline: "none",
    color: "#6A6A6A",
  };

  const handleLoginClick = async () => {
    var credentials: UserCredentials = {
      email: login,
      passwordHash: password,
    };

    var result = await authConnector.loginUser(credentials);

    console.log("auth result", result);

    if (result !== undefined) {
      try {
        var tokenPayload = jwtVerificator.verify(result.token);

        if (tokenPayload !== undefined) {
          console.log("user info", tokenPayload);

          var employee = await databaseConnector.getEmployeeById(
            tokenPayload.sub
          );

          console.log("employee info", employee);
        }
      } catch (error) {
        console.error("token verify error", error);
      }
    }
  };

  // const handleLoginClick = () => {
  //   const auth_endpoint = AUTH_API_DOMAIN + "/api/Auth";

  //   const userCredentials = {
  //     email: login,
  //     passwordHash: password,
  //   };

  //   const body = JSON.stringify({ login: login, password: password });

  //   const content = JSON.stringify(userCredentials);

  //   // console.log({ auth_endpoint, body });

  //   console.log("auth_endpoint", auth_endpoint, "body", content);

  //   // fetch(auth_endpoint, { method: "POST", body })

  //   // const request =

  //   fetch(auth_endpoint, {
  //     method: "POST",
  //     body: content,
  //     headers: new Headers({
  //       "content-type": "application/json",
  //     }),
  //   })
  //     .then((response) => {
  //       console.log({ response });
  //       // TODO: trzeba dopisac endpoint do pobrania danych zalogowanego usera
  //       // const user_endpoint = "";
  //       // fetch(user_endpoint).then((response) => {
  //       //   const parsedUser = response.json();
  //       //   setCurrentUser(parsedUser);
  //       // });
  //     })
  //     .catch((err) => {
  //       console.error("fetch error:", err);
  //     });
  // };

  const handleRegisterClick = () => {
    window.location.href = "http://localhost:8080/rejestracja";
  };

  return (
    <div style={containerStyle}>
      <h1 style={headerStyle}>HR360</h1>
      <h2 style={subHeaderStyle}>LOGOWANIE</h2>
      <input
        type="text"
        placeholder="login"
        style={inputStyle}
        onChange={(e) => setLogin(e.target.value)}
        onFocus={(e) => (e.target.placeholder = "")}
        onBlur={(e) => (e.target.placeholder = "login")}
      />
      <input
        type="password"
        placeholder="hasło"
        style={inputStyle}
        onChange={(e) => setPassword(e.target.value)}
        onFocus={(e) => (e.target.placeholder = "")}
        onBlur={(e) => (e.target.placeholder = "hasło")}
      />
      <div style={{ display: "flex", gap: "10px" }}>
        <button
          className="btn btn-primary"
          type="submit"
          style={{
            background: "#5B40FF",
            fontFamily: "Aksara Bali Galang, sans-serif",
            border: "none",
            margin: "10px",
            fontSize: "25px",
            boxShadow: "0px 4px 4px 0px #00000040",
          }}
          onClick={handleLoginClick}
        >
          Log in
        </button>
        <button
          className="btn btn-secondary"
          type="button"
          style={{
            background: "#5B40FF",
            fontFamily: "Aksara Bali Galang, sans-serif",
            border: "none",
            margin: "10px",
            fontSize: "25px",
            boxShadow: "0px 4px 4px 0px #00000040",
          }}
          onClick={handleRegisterClick}
        >
          Register
        </button>
      </div>
    </div>
  );
}

export default StronaStartowa;
