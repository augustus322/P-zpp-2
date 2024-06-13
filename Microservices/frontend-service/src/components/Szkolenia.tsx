import React from "react";

function Szkolenia() {
  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F3F3F3",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "15px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "10px auto 0", // Wyśrodkowanie poziome i dodatkowy margines z góry
    display: "flex",
    flexDirection: "column",
    gap: "10px", // Odstęp między wierszami
  };

  const headerRowStyle: React.CSSProperties = {
    backgroundColor: "#F3F3F3",
    boxShadow: "0px 4px 4px 0px #00000040",
    borderRadius: "10px",
    padding: "10px",
    display: "flex",
    justifyContent: "space-between",
    textAlign: "center",
  };

  const headerCellStyle: React.CSSProperties = {
    flex: 1,
  };

  const titleStyle: React.CSSProperties = {
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: "20px",
    textAlign: "left",
    marginBottom: "10px", // Odstęp poniżej tytułu
  };

  const columnContainerStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "row",
    gap: "10px",
    backgroundColor: "#FBFBFB",
    boxShadow: "0px 4px 4px 0px #00000040",
    borderRadius: "10px",
    padding: "10px",
    flex: 1,
    alignItems: "center",
  };

  const cellStyle: React.CSSProperties = {
    textAlign: "center",
    flex: 1,
  };

  const wrapperStyle: React.CSSProperties = {
    maxWidth: "1000px",
    margin: "50px auto", // Wyśrodkowanie kontenera i odstęp od góry
    padding: "20px",
  };

  const handleApplyForLeave = () => {
    window.location.href = "http://localhost:8080/nowe-szkolenia";
  };

  const szkolenia = [
    {
      temat: "Szkolenie z zakresu zarządzania",
      adres: "online",
      data: "2024-06-11T14:28:59.322Z",
    },
    {
      temat: "Szkolenie z obsługi oprogramowania",
      adres: "online",
      data: "2024-06-11T14:28:59.322Z",
    },
    {
      temat: "Szkolenie z negocjacji",
      adres: "online",
      data: "2024-06-11T14:28:59.322Z",
    },
    {
      temat: "Szkolenie z zarządzania czasem",
      adres: "online",
      data: "2024-06-11T14:28:59.322Z",
    },
  ];

  return (
    <div style={wrapperStyle}>
      <div style={titleStyle}>SZKOLENIA</div>
      <div style={headerRowStyle}>
        <div style={headerCellStyle}>TEMAT</div>
        <div style={headerCellStyle}>ADRES</div>
        <div style={headerCellStyle}>DATA</div>
      </div>
      <div style={containerStyle}>
        {szkolenia.map((szkolenie, index) => (
          <div style={columnContainerStyle} key={index}>
            <div style={cellStyle}>{szkolenie.temat}</div>
            <div style={cellStyle}>{szkolenie.adres}</div>
            <div style={cellStyle}>{szkolenie.data}</div>
          </div>
        ))}
      </div>
      <button
        className="btn btn-primary"
        onClick={handleApplyForLeave}
        style={{
          background: "#5B40FF",
          fontFamily: "Aksara Bali Galang, sans-serif",
          border: "none",
          margin: "10px auto", // Wyśrodkowanie buttona
          fontSize: "25px",
          boxShadow: "0px 4px 4px 0px #00000040",
          display: "flex",
          maxWidth: "fit-content", // Dopasowanie do zawartości
          cursor: "pointer",
        }}
      >
        Dodaj nowe szkolenie
      </button>
    </div>
  );
}

export default Szkolenia;
