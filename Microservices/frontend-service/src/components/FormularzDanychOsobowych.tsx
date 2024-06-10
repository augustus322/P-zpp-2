import React, { useState } from "react";
import NavBar from "../components/NavBar";

function FormularzOsobowy() {
  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "20px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "0 auto", // Wyśrodkowanie poziome
  };

  const formStyle: React.CSSProperties = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: "18px",
    gap: "70px", // Odstępy między kolumnami
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

  const imageStyle: React.CSSProperties = {
    width: "200px",
    height: "200px",
    objectFit: "cover",
    borderRadius: "50%",
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
    fontSize: "20px",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "10px 20px",
    color: "white",
    cursor: "pointer",
    borderRadius: "5px",
  };

  const buttonContainerStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    gap: "10px",
  };

  // State to manage the form data and edit mode
  const [isEditing, setIsEditing] = useState(false);
  const [userData, setUserData] = useState({
    name: "Jan",
    surname: "Kowalski",
    email: "jan.kowalski@example.com",
    phoneNumber: "+48 123 456 789",
    personalNumber: "1234567890",
    position: "Developer",
  });

  // Handlers for editing mode and saving changes
  const handleEditClick = () => setIsEditing(true);
  const handleSaveClick = () => setIsEditing(false);
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { id, value } = e.target;
    setUserData((prevState) => ({ ...prevState, [id]: value }));
  };

  return (
    <>
      <NavBar />
      <div style={wrapperStyle}>
        <div style={headerStyle}>TWOJE DANE OSOBOWE</div>
        <div style={containerStyle}>
          <div style={formStyle}>
            <div style={labelColumnStyle}>
              <label htmlFor="inputName" className="col-form-label">
                IMIĘ/IMIONA
              </label>
              <label htmlFor="inputSurname" className="col-form-label">
                NAZWISKO
              </label>
              <label htmlFor="inputEmail" className="col-form-label">
                E-MAIL
              </label>
              <label htmlFor="inputNrTel" className="col-form-label">
                NR TELEFONU
              </label>
              <label htmlFor="inputNrOsobowy" className="col-form-label">
                NR OSOBOWY
              </label>
              <label htmlFor="inputStanowisko" className="col-form-label">
                STANOWISKO
              </label>
            </div>

            <div style={inputColumnStyle}>
              <span id="inputName" className="form-control">
                {userData.name}
              </span>
              <span id="inputSurname" className="form-control">
                {userData.surname}
              </span>
              {isEditing ? (
                <input
                  id="email"
                  type="email"
                  className="form-control"
                  value={userData.email}
                  onChange={handleInputChange}
                />
              ) : (
                <span id="inputEmail" className="form-control">
                  {userData.email}
                </span>
              )}
              {isEditing ? (
                <input
                  id="phoneNumber"
                  type="tel"
                  className="form-control"
                  value={userData.phoneNumber}
                  onChange={handleInputChange}
                />
              ) : (
                <span id="inputNrTel" className="form-control">
                  {userData.phoneNumber}
                </span>
              )}
              <span id="inputNrOsobowy" className="form-control">
                {userData.personalNumber}
              </span>
              <span id="inputStanowisko" className="form-control">
                {userData.position}
              </span>
            </div>

            <div style={buttonContainerStyle}>
              <img
                src="https://i.pinimg.com/originals/c0/27/be/c027bec07c2dc08b9df60921dfd539bd.webp"
                alt="profile placeholder"
                style={imageStyle}
              />
              {isEditing ? (
                <button style={buttonStyle} onClick={handleSaveClick}>
                  Zatwierdź
                </button>
              ) : (
                <button style={buttonStyle} onClick={handleEditClick}>
                  Edytuj
                </button>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default FormularzOsobowy;
