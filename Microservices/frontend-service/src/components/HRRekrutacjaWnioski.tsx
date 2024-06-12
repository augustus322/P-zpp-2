import React from "react";
import NavBar from "../components/NavBar";

const containerStyle: React.CSSProperties = {
  backgroundColor: "#",
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
  width: "180px", // Szerokość kolumny etykiet
};

const inputColumnStyle: React.CSSProperties = {
  display: "flex",
  flexDirection: "column",
  gap: "28px", // Odstęp między polami
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

// Example list of recruitment applications
const applications = [
  {
    id: 1,
    name: "Jan",
    surname: "Kowalski",
    phone: "+48 123 456 789",
    location: "Warsaw, Poland",
    email: "jan.kowalski@example.com",
    startDate: "2024-07-01",
    source: "LinkedIn",
    expectations: "5000 PLN/month",
    experience: "5 years as a Software Developer",
    linkedin: "https://www.linkedin.com/in/jankowalski",
  },
  {
    id: 2,
    name: "Anna",
    surname: "Nowak",
    phone: "+48 987 654 321",
    location: "Krakow, Poland",
    email: "anna.nowak@example.com",
    startDate: "2024-07-10",
    source: "Company Website",
    expectations: "6000 PLN/month",
    experience: "3 years as a UX Designer",
    linkedin: "https://www.linkedin.com/in/annanowak",
  },
  // Add more application objects here
];

function HRRekrutacjaWnioski() {
  return (
    <>
      <NavBar />
      <div style={wrapperStyle}>
        <div style={headerStyle}>WNIOSEK REKRUTACYJNY</div>
        {applications.map((application) => (
          <div key={application.id} style={containerStyle}>
            <div style={formStyle}>
              <div style={labelColumnStyle}>
                <label className="col-form-label">IMIĘ</label>
                <label className="col-form-label">NAZWISKO</label>
                <label className="col-form-label">TELEFON</label>
                <label className="col-form-label">LOKALIZACJA</label>
                <label className="col-form-label">EMAIL</label>
                <label className="col-form-label">
                  KIEDY MOŻESZ ZACZĄĆ PRACOWAĆ
                </label>
                <label className="col-form-label">
                  SKĄD WIESZ O NASZEJ OFERCIE
                </label>
                <label className="col-form-label">
                  JAKIE SĄ TWOJE OCZEKIWANIA FINANSOWE
                </label>
                <label className="col-form-label">
                  JAKIE JEST TWOJE DOŚWIADCZENIE ZAWODOWE
                </label>
                <label className="col-form-label">LINKEDIN</label>
              </div>

              <div style={inputColumnStyle}>
                <span className="form-control">{application.name}</span>
                <span className="form-control">{application.surname}</span>
                <span className="form-control">{application.phone}</span>
                <span className="form-control">{application.location}</span>
                <span className="form-control">{application.email}</span>
                <span className="form-control">{application.startDate}</span>
                <span className="form-control">{application.source}</span>
                <span className="form-control">{application.expectations}</span>
                <span className="form-control">{application.experience}</span>
                <span className="form-control">
                  <a
                    href={application.linkedin}
                    target="_blank"
                    rel="noopener noreferrer"
                  >
                    LinkedIn Profile
                  </a>
                </span>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default HRRekrutacjaWnioski;
