import React from "react";

const Kalendarz: React.FC = () => {
  const handleAddEvent = () => {
    console.log("Button clicked");
    const title = encodeURIComponent("Moje Wydarzenie");
    const details = encodeURIComponent("Szczegóły wydarzenia");
    const location = encodeURIComponent("Lokalizacja wydarzenia");
    const startDate = encodeURIComponent("20230530T090000Z"); // format: YYYYMMDDTHHmmssZ
    const endDate = encodeURIComponent("20230530T100000Z"); // format: YYYYMMDDTHHmmssZ
    const calendarUrl = `https://www.google.com/calendar/render?action=TEMPLATE&text=${title}&details=${details}&location=${location}&dates=${startDate}/${endDate}`;

    window.open(calendarUrl, "_blank");
  };

  const buttonStyle: React.CSSProperties = {
    marginBottom: "20px",

    padding: "10px 20px",
    backgroundColor: "#5B40FF", // Główny kolor przycisku
    color: "#FBFBFB", // Kolor tekstu przycisku
    border: "none",
    borderRadius: "5px",
    cursor: "pointer",
    fontSize: "16px",
    boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
    transition: "background-color 0.3s",
  };

  const handleMouseEnter = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.currentTarget.style.backgroundColor = "#4a34cc"; // Kolor przycisku po najechaniu
  };

  const handleMouseLeave = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.currentTarget.style.backgroundColor = "#5B40FF"; // Powrót do głównego koloru przycisku
  };

  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "15px",
    borderRadius: "10px",
    maxWidth: "1000px",
    marginTop: "100px",
    margin: "20px auto", // Wyśrodkowanie poziome
  };

  return (
    <div style={containerStyle}>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          height: "100vh",
        }}
      >
        <button
          onClick={handleAddEvent}
          style={buttonStyle}
          onMouseEnter={handleMouseEnter}
          onMouseLeave={handleMouseLeave}
        >
          Dodaj do Kalendarza Google
        </button>
        <iframe
          src="https://calendar.google.com/calendar/embed?height=800&wkst=2&ctz=Europe%2FWarsaw&bgcolor=%238E24AA&showTz=0&title&showTitle=0&src=eW91cnR5cGljYWx3b3JraW5nZW1haWxAZ21haWwuY29t&src=YWRkcmVzc2Jvb2sjY29udGFjdHNAZ3JvdXAudi5jYWxlbmRhci5nb29nbGUuY29t&src=ZW4ucG9saXNoI2hvbGlkYXlAZ3JvdXAudi5jYWxlbmRhci5nb29nbGUuY29t&color=%23039BE5&color=%2333B679&color=%230B8043"
          style={{ border: "solid 1px #777", zIndex: 0 }}
          width="100%"
          height="100%"
          frameBorder="0"
          scrolling="no"
        ></iframe>
      </div>
    </div>
  );
};

export default Kalendarz;
