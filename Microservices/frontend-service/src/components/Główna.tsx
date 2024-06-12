import React from "react";

const Glowna = () => {
  const commonTextStyle: React.CSSProperties = {
    fontFamily: "Aksara Bali Galang, sans-serif",
    color: "#000000",
    cursor: "pointer", // Zmieniamy kursor na wskaźnik, aby pokazać, że element jest klikalny
  };

  const handleApplyForLeave = () => {
    window.location.href = "http://localhost:5173/Urlopy";
  };

  const handleNavigateToTrainings = () => {
    window.location.href = "http://localhost:5173/Szkolenia";
  };

  const handleNavigateToCalendar = () => {
    window.location.href = "http://localhost:5173/Kalendarz";
  };

  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "15px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "100px auto", // Wyśrodkowanie poziome i dodatkowy margines z góry
  };

  const gridContainerStyle: React.CSSProperties = {
    display: "grid",
    gridTemplateColumns: "repeat(2, 1fr)", // Dwie kolumny
    gap: "20px",
    alignItems: "center",
  };

  const wideGridItemStyle: React.CSSProperties = {
    gridColumn: "span 2", // Rozciągnięcie na dwie kolumny
    background: "#FBFBFB",
    boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
    borderRadius: "10px",
    overflow: "hidden",
    padding: "20px",
    textAlign: "center",
  };

  const gridItemStyle: React.CSSProperties = {
    background: "#FBFBFB",
    boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
    borderRadius: "10px",
    overflow: "hidden",
    height: "366px",
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  };

  return (
    <div style={containerStyle}>
      <div style={gridContainerStyle}>
        <div
          style={{
            ...wideGridItemStyle,
            cursor: "pointer",
          }}
          onClick={handleNavigateToTrainings}
        >
          <div
            style={{
              fontSize: "30px",
              color: "#4B398D",
              marginBottom: "10px",
            }}
          >
            TWOJE AKTYWNE SZKOLENIA
          </div>
          <div style={{ fontSize: "20px", color: "#000000" }}>
            SZKOLENIE Z BEZPIECZEŃSTWA I HIGIENY PRACY
          </div>
        </div>
        <div style={gridItemStyle}>
          <img
            src="https://i.pinimg.com/736x/90/4c/39/904c39c4ba8b6775957f1dab81b87de4.jpg"
            alt="Kalendarz"
            style={{
              width: "100%",
              height: "100%",
              objectFit: "cover",
              cursor: "pointer",
            }}
            onClick={handleNavigateToCalendar}
          />
        </div>
        <div style={gridItemStyle}>
          <div
            style={{
              ...commonTextStyle,
              fontSize: "25px",
              lineHeight: "45px",
              color: "#4B398D",
              textAlign: "center",
            }}
            onClick={handleApplyForLeave}
          >
            URLOPY
            <div
              style={{
                fontSize: "20px",
                color: "#000000",
                marginTop: "20px",
              }}
            >
              POZOSTAŁO CI 19/21 DNI URLOPU
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Glowna;
