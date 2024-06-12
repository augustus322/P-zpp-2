import React, { useState } from "react";
import { useCurrentUser } from "../contexts/CurrentUserContext";
import NavBar from "../components/NavBar";

const USER_API_DOMAIN = "http://localhost:5116";

function FormularzOsobowy() {
  const { currentUser } = useCurrentUser();

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
  const [userEmail, setUserEmail] = useState(currentUser?.email || "");
  const [userPhone, setUserPhone] = useState(currentUser?.phone || "");

  // Handlers for editing mode and saving changes
  const handleEditClick = () => setIsEditing(true);
  const handleSaveClick = () => {
    console.log({ currentUser });
    if (!currentUser?.id) {
      return;
    }

    setIsEditing(false);
    const newUserData = { ...currentUser, email: userEmail, phone: userPhone };
    console.log({ newUserData });

    // TODO: trzeba dopisac endpoint             👇🏿 tutaj
    const updateUserEndpoint = USER_API_DOMAIN + "/" + currentUser.id;
    // TODO: trzeba dopisac endpoint             🖕🏾 tutaj
    if (currentUser) {
      fetch(updateUserEndpoint, {
        method: "PUT",
        body: JSON.stringify(newUserData),
      });
    }
  };

  return (
    <>
      <NavBar />
      <div style={wrapperStyle}>
        <div style={headerStyle}>TWOJE DANE OSOBOWE</div>
        <div style={containerStyle}>
          <div style={formStyle}>
            <div style={labelColumnStyle}>
              <label htmlFor="firstName" className="col-form-label">
                IMIĘ/IMIONA
              </label>
              <label htmlFor="lastName" className="col-form-label">
                NAZWISKO
              </label>
              <label htmlFor="email" className="col-form-label">
                E-MAIL
              </label>
              <label htmlFor="phone" className="col-form-label">
                NR TELEFONU
              </label>
              <label htmlFor="id" className="col-form-label">
                NR OSOBOWY
              </label>
              <label htmlFor="position" className="col-form-label">
                STANOWISKO
              </label>
            </div>

            <div style={inputColumnStyle}>
              <span id="firstName" className="form-control">
                {currentUser?.firstName}
              </span>
              <span id="lastName" className="form-control">
                {currentUser?.lastName}
              </span>
              {isEditing ? (
                <input
                  id="email"
                  type="email"
                  className="form-control"
                  value={userEmail}
                  onChange={(e) => setUserEmail(e.target.value)}
                />
              ) : (
                <span id="email" className="form-control">
                  {userEmail}
                </span>
              )}
              {isEditing ? (
                <input
                  id="phone"
                  type="tel"
                  className="form-control"
                  value={userPhone}
                  onChange={(e) => setUserPhone(e.target.value)}
                />
              ) : (
                <span id="phone" className="form-control">
                  {userPhone}
                </span>
              )}
              <span id="id" className="form-control">
                {currentUser?.id}
              </span>
              <span id="position" className="form-control">
                {currentUser?.position}
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
