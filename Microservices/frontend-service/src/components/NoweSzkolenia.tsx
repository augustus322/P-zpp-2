import React, { useState } from "react";

const containerStyle: React.CSSProperties = {
  backgroundColor: "#F9F6F6",
  boxShadow: "0px 4px 4px 0px #00000040",
  padding: "20px",
  borderRadius: "10px",
  maxWidth: "1000px",
  margin: "20px auto",
};

const formStyle: React.CSSProperties = {
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  fontFamily: "Aksara Bali Galang, sans-serif",
  fontSize: "18px",
  gap: "20px",
  marginBottom: "20px",
};

const labelColumnStyle: React.CSSProperties = {
  display: "flex",
  flexDirection: "column",
  gap: "23px",
  textAlign: "left",
};

const inputColumnStyle: React.CSSProperties = {
  display: "flex",
  flexDirection: "column",
  gap: "10px",
};

const headerStyle: React.CSSProperties = {
  fontFamily: "Aksara Bali Galang, sans-serif",
  fontSize: "20px",
  textAlign: "left",
  marginBottom: "10px",
};
const wrapperStyle: React.CSSProperties = {
  maxWidth: "1000px",
  margin: "50px auto",
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
    status: "planowane", // Default value
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  const handleFormSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await fetch("http://localhost:5173/szkolenia/courses", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          title: formData.nazwa,
          description: formData.status,
          startDate: new Date().toISOString(), // Example value, replace with actual date
          endDate: new Date().toISOString(), // Example value, replace with actual date
        }),
      });

      if (!response.ok) {
        throw new Error("Something went wrong");
      }

      console.log("Dodawanie nowego szkolenia:", formData);
      setFormData({ nazwa: "", status: "planowane" }); // Reset form after successful submission
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={headerStyle}>Dodaj nowe szkolenie</div>
        <div style={containerStyle}>
          <form style={formStyle} onSubmit={handleFormSubmit}>
            <div style={labelColumnStyle}>
              <label htmlFor="nazwa">Nazwa szkolenia</label>
              <label htmlFor="status">Status</label>
            </div>
            <div style={inputColumnStyle}>
              <input
                type="text"
                id="nazwa"
                className="form-control"
                value={formData.nazwa}
                onChange={handleInputChange}
              />
              <select
                id="status"
                className="form-control"
                value={formData.status}
                onChange={handleInputChange}
              >
                <option value="planowane">Planowane</option>
                <option value="rozpoczęte">Rozpoczęte</option>
                <option value="zakończone">Zakończone</option>
              </select>
            </div>
            <div>
              <button type="submit" style={buttonStyle}>
                Dodaj szkolenie
              </button>
            </div>
          </form>
        </div>
      </div>
    </>
  );
}

export default NoweSzkolenia;
