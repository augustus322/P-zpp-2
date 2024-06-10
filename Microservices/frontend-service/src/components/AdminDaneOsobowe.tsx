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
  marginBottom: "2px", // Odstęp poniżej nagłówka
};

const wrapperStyle: React.CSSProperties = {
  maxWidth: "1000px",
  margin: "50px auto", // Wyśrodkowanie kontenera i odstęp od góry
  padding: "20px",
};

// Example list of employees
const employees = [
  {
    name: "Jan",
    surname: "Kowalski",
    email: "jan.kowalski@example.com",
    phoneNumber: "+48 123 456 789",
    personalNumber: "1234567890",
    position: "Developer",
  },
  {
    name: "Anna",
    surname: "Nowak",
    email: "anna.nowak@example.com",
    phoneNumber: "+48 987 654 321",
    personalNumber: "0987654321",
    position: "Designer",
  },
  // Add more employee objects here
];

function AdminDaneOsobowe() {
  return (
    <>
      <NavBar />
      <div style={wrapperStyle}>
        <div style={headerStyle}>DANE OSOBOWE PRACOWNIKÓW</div>
        {employees.map((employee, index) => (
          <div key={index} style={containerStyle}>
            <div style={formStyle}>
              <div style={labelColumnStyle}>
                <label className="col-form-label">IMIĘ/IMIONA</label>
                <label className="col-form-label">NAZWISKO</label>
                <label className="col-form-label">E-MAIL</label>
                <label className="col-form-label">NR TELEFONU</label>
                <label className="col-form-label">NR OSOBOWY</label>
                <label className="col-form-label">STANOWISKO</label>
              </div>

              <div style={inputColumnStyle}>
                <span className="form-control">{employee.name}</span>
                <span className="form-control">{employee.surname}</span>
                <span className="form-control">{employee.email}</span>
                <span className="form-control">{employee.phoneNumber}</span>
                <span className="form-control">{employee.personalNumber}</span>
                <span className="form-control">{employee.position}</span>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default AdminDaneOsobowe;
