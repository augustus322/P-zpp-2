function FormularzRekrutacji() {
  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "30px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "auto", // centrowanie formularza
  };

  const formStyle: React.CSSProperties = {
    display: "flex",
    justifyContent: "center",
    alignItems: "flex-start",
    gap: "50px", // odstępy między kolumnami
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: "18px",
  };

  const labelColumnStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "column",
    gap: "17px", // odstęp między etykietami
    textAlign: "left",
  };

  const inputColumnStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "column",
    gap: "20px", // odstęp między polami
  };

  const textAreaStyle: React.CSSProperties = {
    height: "100px",
    resize: "none",
    marginBottom: "60px",
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

  const pElementStyle: React.CSSProperties = {
    fontSize: "14px",
    color: "#353535",
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={headerStyle}>FORMULARZ KANDYDATÓW</div>
        <div style={containerStyle}>
          <div style={formStyle}>
            <div style={labelColumnStyle}>
              <label htmlFor="inputName" className="col-form-label">
                IMIĘ
              </label>
              <label htmlFor="inputSurname" className="col-form-label">
                NAZWISKO
              </label>
              <label htmlFor="inputPhone" className="col-form-label">
                TELEFON
              </label>
              <label htmlFor="inputLocation" className="col-form-label">
                LOKALIZACJA
              </label>
              <label htmlFor="inputEmail" className="col-form-label">
                E-MAIL
              </label>
              <label htmlFor="inputCV" className="col-form-label">
                CV
              </label>
              <label htmlFor="inputLinkedIn" className="col-form-label">
                LINKEDIN
              </label>
            </div>

            <div style={inputColumnStyle}>
              <input type="text" id="inputName" className="form-control" />
              <input type="text" id="inputSurname" className="form-control" />
              <input type="text" id="inputPhone" className="form-control" />
              <input type="text" id="inputLocation" className="form-control" />
              <input type="email" id="inputEmail" className="form-control" />
              <input type="file" id="inputCV" className="form-control" />
              <input type="text" id="inputLinkedIn" className="form-control" />
            </div>

            <div style={inputColumnStyle}>
              <label htmlFor="inputStartDate" className="col-form-label">
                KIEDY MOŻESZ ZACZĄĆ PRACOWAĆ?
              </label>
              <input type="date" id="inputStartDate" className="form-control" />

              <label htmlFor="inputSource" className="col-form-label">
                SKĄD WIESZ O NASZEJ OFERCIE?
              </label>
              <input type="text" id="inputSource" className="form-control" />

              <label htmlFor="inputSalary" className="col-form-label">
                JAKIE SĄ TWOJE OCZEKIWANIA FINANSOWE?
              </label>
              <input type="text" id="inputSalary" className="form-control" />

              <label htmlFor="inputExperience" className="col-form-label">
                JAKIE JEST TWOJE DOŚWIADCZENIE ZAWODOWE?
              </label>
              <textarea
                id="inputExperience"
                className="form-control"
                style={textAreaStyle}
              ></textarea>
            </div>
          </div>
          <p style={pElementStyle}>
            "Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb
            niezbędnych do realizacji procesu tej rekrutacji zgodnie z ustawą z
            dnia 10 maja 2018 roku o ochronie danych osobowych (Dz. Ustaw z
            2018, poz. 1000) oraz zgodnie z Rozporządzeniem Parlamentu
            Europejskiego i Rady (UE) 2016/679 z dnia 27 kwietnia 2016 r. w
            sprawie ochrony osób fizycznych w związku z przetwarzaniem danych
            osobowych i w sprawie swobodnego przepływu takich danych oraz
            uchylenia dyrektywy 95/46/WE (ogólne rozporządzenie o ochronie
            danych).”
          </p>

          <button
            className="btn btn-primary"
            type="submit"
            style={{
              background: "#5B40FF",
              fontFamily: "Aksara Bali Galang, sans-serif",
              border: "none",
              margin: "10px",
              fontSize: "25px",
              boxShadow: "0px 4px 4px 0px #00000040",
              display: "flex",
              justifyContent: "center",
            }}
          >
            Zatwierdź
          </button>
        </div>
      </div>
    </>
  );
}

export default FormularzRekrutacji;
