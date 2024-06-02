import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/css/bootstrap.css";

function StronaStartowa() {
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

  return (
    <div style={containerStyle}>
      <h1 style={headerStyle}>HR360</h1>
      <h2 style={subHeaderStyle}>LOGOWANIE</h2>
      <input
        type="text"
        placeholder="login"
        style={inputStyle}
        onFocus={(e) => (e.target.placeholder = "")}
        onBlur={(e) => (e.target.placeholder = "login")}
      />
      <input
        type="password"
        placeholder="hasło"
        style={inputStyle}
        onFocus={(e) => (e.target.placeholder = "")}
        onBlur={(e) => (e.target.placeholder = "hasło")}
      />
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
      >
        Log in
      </button>
    </div>
  );
}

export default StronaStartowa;
