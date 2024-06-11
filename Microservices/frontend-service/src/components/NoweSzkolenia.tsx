import React, { useState } from "react";

const containerStyle: React.CSSProperties = {
  backgroundColor: "#F9F6F6",
  boxShadow: "0px 4px 4px 0px #00000040",
  padding: "20px",
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
  gap: "23px", // Odstęp między etykietami
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
  marginBottom: "10px", // Odstęp poniżej nagłówka
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
  margin: "10px",
  fontSize: "18px",
  boxShadow: "0px 4px 4px 0px #00000040",
  padding: "10px 20px",
  color: "white",
  cursor: "pointer",
  borderRadius: "5px",
};

function NoweSzkolenia() {
  const [formData, setFormData] = useState({
    nazwa: "",
    dataRozpoczecia: "",
    dataZakonczenia: "",
    typ: "",
    dlugosc: "",
  });
  const [showModal, setShowModal] = useState(false);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  const handleFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setShowModal(true);
  };

  const closeModal = () => {
    setShowModal(false);
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={headerStyle}> WNIOSEK O SZKOLENIE</div>
        <div style={containerStyle}>
          <form style={formStyle} onSubmit={handleFormSubmit}>
            <div style={labelColumnStyle}>
              <label htmlFor="nazwa">NAZWA SZKOLENIA</label>
              <label htmlFor="dataRozpoczecia">DATA ROZPOCZĘCIA</label>
              <label htmlFor="dataZakonczenia">DATA ZAKOŃCZENIA</label>
              <label htmlFor="typ">TYP</label>
              <label htmlFor="dlugosc">DŁUGOŚĆ</label>
            </div>
            <div style={inputColumnStyle}>
              <input
                type="text"
                id="nazwa"
                className="form-control"
                value={formData.nazwa}
                onChange={handleInputChange}
              />
              <input
                type="date"
                id="dataRozpoczecia"
                className="form-control"
                value={formData.dataRozpoczecia}
                onChange={handleInputChange}
              />
              <input
                type="date"
                id="dataZakonczenia"
                className="form-control"
                value={formData.dataZakonczenia}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="typ"
                className="form-control"
                value={formData.typ}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="dlugosc"
                className="form-control"
                value={formData.dlugosc}
                onChange={handleInputChange}
              />
            </div>
            <div>
              <button type="submit" style={buttonStyle}>
                Złóż wniosek
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}

export default NoweSzkolenia;
