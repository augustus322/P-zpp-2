import React, { useState, useEffect } from "react";

const mockedPaymentsData = [
  {
    id: "1",
    name: "KAROLINA MĄKA",
    type: "WYPŁATA",
    status: "ROZPOCZĘTE",
  },
  {
    id: "2",
    name: "WIKTORIA MRÓZEK",
    type: "WYPŁATA",
    status: "ZAKOŃCZONE",
  },
  {
    id: "3",
    name: "DAWID MACHAJ",
    type: "WYPŁATA",
    status: "ZAKOŃCZONE",
  },
  {
    id: "4",
    name: "MIESZKO NIEZGODA",
    type: "WYPŁATA",
    status: "ZAKOŃCZONE",
  },
];

function Wynagrodzenia() {
  const [paymentsData, setPaymentsData] = useState(mockedPaymentsData);
  useEffect(() => {
    fetch("").then((response) => response.json());
  }, []);

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
              {paymentsData.map((data) => (
                <div style={cellStyle}>{data.id}</div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div style={cellStyle}>{data.name}</div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div style={cellStyle}>{data.type}</div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div style={cellStyle}>{data.status}</div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Wynagrodzenia;
