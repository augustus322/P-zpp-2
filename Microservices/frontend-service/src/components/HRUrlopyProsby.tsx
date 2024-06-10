import React from "react";
import NavBar from "../components/NavBar";

const containerStyle: React.CSSProperties = {
  backgroundColor: "#F9F6F6",
  boxShadow: "0px 4px 4px 0px #00000040",
  padding: "15px",
  borderRadius: "10px",
  maxWidth: "1000px",
  margin: "20px auto", // Wyśrodkowanie poziome
};

const formStyle: React.CSSProperties = {
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  fontFamily: "Aksara Bali Galang, sans-serif",
  fontSize: "18px",
  gap: "20px", // Odstępy między kolumnami
  marginBottom: "20px", // Odstęp między formularzami
};

const labelColumnStyle: React.CSSProperties = {
  display: "flex",
  flexDirection: "column",
  gap: "5px", // Odstęp między etykietami
  textAlign: "left",
  width: "120px", // Szerokość kolumny etykiet
};

const inputColumnStyle: React.CSSProperties = {
  display: "flex",
  flexDirection: "column",
  gap: "10px", // Odstęp między polami
};

const headerStyle: React.CSSProperties = {
  fontFamily: "Aksara Bali Galang, sans-serif",
  fontSize: "20px",
  textAlign: "left", // Wyśrodkowanie tekstu
  marginBottom: "20px", // Odstęp poniżej nagłówka
};

const wrapperStyle: React.CSSProperties = {
  maxWidth: "1000px",
  margin: "50px auto", // Wyśrodkowanie kontenera i odstęp od góry
  padding: "20px",
};

const buttonStyle: React.CSSProperties = {
  background: "#5B40FF",
  fontFamily: "Aksara Bali Galang, sans-serif",
  border: "none",
  fontSize: "16px",
  padding: "8px 15px",
  color: "white",
  cursor: "pointer",
  borderRadius: "5px",
};

// Example list of requests
const requests = [
  {
    id: 1,
    employee: "Jan Kowalski",
    startDate: "2024-07-01",
    endDate: "2024-07-05",
    type: "Urlop wypoczynkowy",
    status: "Oczekujący",
  },
  {
    id: 2,
    employee: "Anna Nowak",
    startDate: "2024-07-10",
    endDate: "2024-07-15",
    type: "Urlop zdrowotny",
    status: "Zaakceptowany",
  },
  // Add more request objects here
];

function HRUrlopyProsby() {
  const handleApprove = (id: number) => {
    // Implementacja logiki zatwierdzania wniosku
    console.log(`Zatwierdzono wniosek o ID: ${id}`);
  };

  const handleReject = (id: number) => {
    // Implementacja logiki odrzucania wniosku
    console.log(`Odrzucono wniosek o ID: ${id}`);
  };

  return (
    <>
      <NavBar />
      <div style={wrapperStyle}>
        <div style={headerStyle}>WNIOSKI O URLOP</div>
        {requests.map((request) => (
          <div key={request.id} style={containerStyle}>
            <div style={formStyle}>
              <div style={labelColumnStyle}>
                <label className="col-form-label">PRACOWNIK</label>
                <label className="col-form-label">DATA ROZPOCZĘCIA</label>
                <label className="col-form-label">DATA ZAKOŃCZENIA</label>
                <label className="col-form-label">TYP</label>
                <label className="col-form-label">STATUS</label>
              </div>

              <div style={inputColumnStyle}>
                <span className="form-control">{request.employee}</span>
                <span className="form-control">{request.startDate}</span>
                <span className="form-control">{request.endDate}</span>
                <span className="form-control">{request.type}</span>
                <span className="form-control">{request.status}</span>
              </div>
              <div>
                <button
                  style={{ ...buttonStyle, backgroundColor: "#2ecc71" }}
                  onClick={() => handleApprove(request.id)}
                >
                  Zatwierdź
                </button>
                <button
                  style={{ ...buttonStyle, backgroundColor: "#e74c3c" }}
                  onClick={() => handleReject(request.id)}
                >
                  Odrzuć
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default HRUrlopyProsby;
