import React from "react";

function Wynagrodzenia() {
  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "15px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "0 auto", // Wyśrodkowanie poziome
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
    flexDirection: "column",
    gap: "10px",
    backgroundColor: "#FBFBFB",
    boxShadow: "0px 4px 4px 0px #00000040",
    borderRadius: "10px",
    padding: "10px",
    flex: 1,
  };

  const cellStyle: React.CSSProperties = {
    textAlign: "center",
  };

  const columnsWrapperStyle: React.CSSProperties = {
    display: "flex",
    gap: "14px", // Odstęp między kolumnami
  };

  const spacerStyle: React.CSSProperties = {
    height: "7px",
    marginTop: "15px",
  };

  const wrapperStyle: React.CSSProperties = {
    maxWidth: "1000px",
    margin: "50px auto", // Wyśrodkowanie kontenera i odstęp od góry
    padding: "20px",
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={titleStyle}>WYNAGRODZENIA</div>
        <div style={headerRowStyle}>
          <div style={headerCellStyle}>LP</div>
          <div style={headerCellStyle}>PRACOWNIK</div>
          <div style={headerCellStyle}>TYP</div>
          <div style={headerCellStyle}>STATUS</div>
        </div>
        <div style={spacerStyle}></div> {/* Ramka w kolorze #F3F3F3 */}
        <div style={containerStyle}>
          <div style={columnsWrapperStyle}>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>1</div>
              <div style={cellStyle}>2</div>
              <div style={cellStyle}>3</div>
              <div style={cellStyle}>4</div>

              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>KAROLINA MĄKA</div>
              <div style={cellStyle}>WIKTORIA MRÓZEK</div>
              <div style={cellStyle}>DAWID MACHAJ</div>
              <div style={cellStyle}>MIESZKO NIEZGODA</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>WYPŁATA</div>
              <div style={cellStyle}>WYPŁATA</div>
              <div style={cellStyle}>WYPŁATA</div>
              <div style={cellStyle}>WYPŁATA</div>

              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>ROZPOCZĘTE </div>
              <div style={cellStyle}>ZAKOŃCZONE </div>
              <div style={cellStyle}>ZAKOŃCZONE</div>
              <div style={cellStyle}>ZAKOŃCZONE</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Wynagrodzenia;
