import React, { useState, ChangeEvent, FormEvent } from "react";
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

const contentStyle: React.CSSProperties = {
  top: "50%",
  left: "50%",
  right: "auto",
  bottom: "auto",
  marginRight: "-50%",
  transform: "translate(-50%, -50%)",
  width: "400px",
  padding: "20px",
  border: "none",
  borderRadius: "10px",
  backgroundColor: "#FFF",
  boxShadow: "0px 4px 4px 0px #00000040",
  fontFamily: "Aksara Bali Galang, sans-serif",
};

const overlayStyle: React.CSSProperties = {
  backgroundColor: "rgba(0, 0, 0, 0.5)",
};

const modalStyle = {
  content: contentStyle,
  overlay: overlayStyle,
};

function AdminWynagrodzenia() {
  const [formData, setFormData] = useState({
    name: "",
    surname: "",
    personalNumber: "",
    type: "",
    salaryAmount: "",
  });
  const [showModal, setShowModal] = useState(false);

  const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  const handleFormSubmit = (e: FormEvent) => {
    e.preventDefault();
    setShowModal(true);
  };

  const closeModal = () => {
    setShowModal(false);
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={headerStyle}>WYNAGRODZENIE PRACOWNIKÓW</div>
        <div style={containerStyle}>
          <form style={formStyle} onSubmit={handleFormSubmit}>
            <div style={labelColumnStyle}>
              <label htmlFor="name" className="col-form-label">
                IMIĘ/IMIONA
              </label>
              <label htmlFor="surname" className="col-form-label">
                NAZWISKO
              </label>
              <label htmlFor="personalNumber" className="col-form-label">
                NR OSOBOWY
              </label>
              <label htmlFor="type" className="col-form-label">
                TYP
              </label>
              <label htmlFor="salaryAmount" className="col-form-label">
                WYSOKOŚĆ WYNAGRODZENIA
              </label>
            </div>
            <div style={inputColumnStyle}>
              <input
                type="text"
                id="name"
                className="form-control"
                value={formData.name}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="surname"
                className="form-control"
                value={formData.surname}
                onChange={handleInputChange}
              />
              <input
                type="text"
                id="personalNumber"
                className="form-control"
                value={formData.personalNumber}
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
                id="salaryAmount"
                className="form-control"
                value={formData.salaryAmount}
                onChange={handleInputChange}
              />
            </div>
            <div>
              <button type="submit" style={buttonStyle}>
                Zrealizuj
              </button>
            </div>
          </form>
          <Modal
            isOpen={showModal}
            onRequestClose={closeModal}
            style={modalStyle}
          >
            <h2>Czy dane są poprawne?</h2>
            <p>IMIĘ/IMIONA: {formData.name}</p>
            <p>NAZWISKO: {formData.surname}</p>
            <p>NR OSOBOWY: {formData.personalNumber}</p>
            <p>TYP: {formData.type}</p>
            <p>WYSOKOŚĆ WYNAGRODZENIA: {formData.salaryAmount}</p>
            <button style={buttonStyle} onClick={closeModal}>
              Zatwierdź
            </button>
          </Modal>
        </div>
      </div>
    </>
  );
}

export default AdminWynagrodzenia;
