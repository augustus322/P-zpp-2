import React from "react";

function Urlopy() {
  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F3F3F3",
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

  const handleApplyForLeave = () => {
    window.location.href = "/wniosek-o-urlop";
  };

  const employeeData = [
    {
      startDate: "2023-02-01",
      endDate: "2023-02-02",
      type: "Urlop wypoczynkowy",
      duration: "2 dni",
      status: "Zatwierdzony",
    },
    {
      startDate: "2023-03-15",
      endDate: "2023-03-17",
      type: "Urlop macierzyński",
      duration: "3 dni",
      status: "Zatwierdzony",
    },
    {
      startDate: "2023-07-10",
      endDate: "2023-07-14",
      type: "Urlop wypoczynkowy",
      duration: "5 dni",
      status: "Zatwierdzony",
    },
  ];

  return (
    <>
      <div style={wrapperStyle}>
        <div style={titleStyle}>URLOPY</div>
        <div style={headerRowStyle}>
          <div style={headerCellStyle}>DATA POCZĄTKU</div>
          <div style={headerCellStyle}>DATA ZAKOŃCZENIA</div>
          <div style={headerCellStyle}>TYP</div>
          <div style={headerCellStyle}>DŁUGOŚĆ</div>
          <div style={headerCellStyle}>STATUS</div>
        </div>
        <div style={spacerStyle}></div> {/* Ramka w kolorze #F3F3F3 */}
        <div style={containerStyle}>
          <div style={columnsWrapperStyle}>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>2023-03-15</div>
              <div style={cellStyle}>2023-03-15</div>
              <div style={cellStyle}>2023-03-15</div>
              <div style={cellStyle}>2023-03-15</div>

              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>2023-03-1</div>
              <div style={cellStyle}>2023-03-1</div>
              <div style={cellStyle}>2023-03-1</div>
              <div style={cellStyle}>2023-03-1</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>WYPOCZYNKOWY</div>
              <div style={cellStyle}>ZDROWOTNY</div>
              <div style={cellStyle}>WYPOCZYNKOWY</div>
              <div style={cellStyle}>WYPOCZYNKOWY</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>
            <div style={columnContainerStyle}>
              <div style={cellStyle}>3 DNI </div>
              <div style={cellStyle}>3 DNI </div>
              <div style={cellStyle}>3 DNI</div>
              <div style={cellStyle}>3 DNI</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>

            <div style={columnContainerStyle}>
              <div style={cellStyle}>ZATWIERDZONO</div>
              <div style={cellStyle}>ZAKOŃCZONO</div>
              <div style={cellStyle}>ODRZUCONO</div>
              <div style={cellStyle}>ZATWIERDZONO</div>
              {/* Dodaj więcej wierszy tutaj */}
            </div>
          </div>
        </div>
        <button
          className="btn btn-primary"
          onClick={handleApplyForLeave}
          style={{
            background: "#5B40FF",
            fontFamily: "Aksara Bali Galang, sans-serif",
            border: "none",
            margin: "10px",
            marginTop: "20px",
            fontSize: "25px",
            boxShadow: "0px 4px 4px 0px #00000040",
            display: "flex",
          }}
        >
          Złóż wniosek o urlop
        </button>
      </div>
    </>
  );
}

export default Urlopy;
