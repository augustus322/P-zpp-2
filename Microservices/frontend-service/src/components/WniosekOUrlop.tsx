import React, { useState } from "react";
import Modal from "react-modal";

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

function WniosekOUrlop() {
  const [formData, setFormData] = useState({
    personalNumber: "",
    startDate: "",
    endDate: "",
    type: "",
    duration: "",
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
        <div style={headerStyle}> WNIOSEK O URLOP</div>
        <div style={containerStyle}>
          <form style={formStyle} onSubmit={handleFormSubmit}>
            <div style={labelColumnStyle}>
              <label htmlFor="personalNumber">NR OSOBOWY</label>
              <label htmlFor="startDate">DATA ROZPOCZĘCIA</label>
              <label htmlFor="endDate">DATA ZAKOŃCZENIA</label>
              <label htmlFor="type">TYP</label>
              <label htmlFor="duration">DŁUGOŚĆ</label>
            </div>
            <div style={inputColumnStyle}>
              <input
                type="text"
                id="personalNumber"
                className="form-control"
                value={formData.personalNumber}
                onChange={handleInputChange}
              />
              <input
                type="date"
                id="startDate"
                className="form-control"
                value={formData.startDate}
                onChange={handleInputChange}
              />
              <input
                type="date"
                id="endDate"
                className="form-control"
                value={formData.endDate}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="type"
                className="form-control"
                value={formData.type}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="duration"
                className="form-control"
                value={formData.duration}
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

export default WniosekOUrlop;
