import React from 'react';


const Glowna = () => {
  const commonTextStyle: React.CSSProperties = {
    fontFamily: 'Aksara Bali Galang, sans-serif',
    color: '#000000',
    cursor: 'pointer', // Zmieniamy kursor na wskaźnik, aby pokazać, że element jest klikalny
  };

  const handleApplyForLeave = () => {
    window.location.href = "http://localhost:5173/Urlopy";
  };

  const handleNavigateToTrainings = () => {
    // Dodaj kod przenoszący użytkownika do sekcji szkoleń
    window.location.href = "http://localhost:5173/Szkolenia";
  };

  const handleNavigateToCalendar = () => {
    // Dodaj kod przenoszący użytkownika do sekcji szkoleń
    window.location.href = "http://localhost:5173/Kalendarz";
  };

  return (
    <div>
      {/* KAFELKI NA LEWEJ STRONIE */}
      {/* Kafelek 1 */}
      <div
        style={{
          position: 'absolute',
          width: '510px',
          height: '366px',
          left: '267px',
          top: '470px',
          background: '#FBFBFB',
          boxShadow: '0px 4px 4px rgba(0, 0, 0, 0.25)',
          borderRadius: '10px',
          overflow: 'hidden', // Zapewnia, że obrazek nie wychodzi poza ramy kafelka
        }}
      >
        {/* Obrazek kalendarza */}
        <img
          src="https://i.pinimg.com/736x/90/4c/39/904c39c4ba8b6775957f1dab81b87de4.jpg" // Ścieżka do pobranego obrazka
          alt="Kalendarz"
          style={{ width: '510px', height: '366px', objectFit: 'cover', cursor: 'pointer' }}
          onClick={handleNavigateToCalendar}
        />
      </div>

      {/* Pozostała część kodu */}
      {/* Kafelek 2 */}
      <div
        style={{
          position: 'absolute',
          width: '510px',
          height: '366px',
          left: '888px',
          top: '470px',
          background: '#FBFBFB',
          boxShadow: '0px 4px 4px rgba(0, 0, 0, 0.25)',
          borderRadius: '10px',
        }}
      ></div>

     {/* Rectangle 3 */}
<div
  style={{
    position: 'absolute',
    width: '1137px',
    height: '281px',
    left: '267px',
    top: '151px',
    background: '#FBFBFB',
    boxShadow: '0px 4px 4px rgba(0, 0, 0, 0.25)',
    borderRadius: '10px',
    display: 'flex',
    alignItems: 'center', // Wyśrodkuj obrazek w pionie
  }}
>
  {/* Obrazek */}
  <img
    src="https://www.shutterstock.com/shutterstock/videos/1015550863/thumb/1.jpg?ip=x480" // Ścieżka do obrazka
    alt="Obrazek"
    style={{ borderRadius: '50%', width: '420px', height: '250px', marginLeft: 'auto' }} // Ustal rozmiar obrazka i dodaj margin-left:auto
  />
</div>

      {/* Rectangle 6 */}
      <div
        style={{
          position: 'absolute',
          width: '510px',
          height: '366px',
          left: '888px',
          top: '470px',
          background: '#FBFBFB',
          boxShadow: '0px 4px 4px rgba(0, 0, 0, 0.25)',
          borderRadius: '10px',
        }}
      ></div>

      {/* TWOJE AKTYWNE SZKOLENIA */}
     {/* TWOJE AKTYWNE SZKOLENIA */}
     <div style={{ ...commonTextStyle, position: 'absolute', width: '478px', height: '87px', left: '289px', top: '187px', fontSize: '30px', lineHeight: '95px', color: '#4B398D' }} onClick={handleNavigateToTrainings}>TWOJE AKTYWNE SZKOLENIA</div>
      <div style={{ ...commonTextStyle, position: 'absolute', width: '341px', height: '37px', left: '289px', top: '308px', fontSize: '20px', lineHeight: '40px' }}>SZKOLENIE Z BEZPIECZEŃSTWA I HIGIENY PRACY</div>
        
      {/* URLOPY */}
      <div
        style={{
          ...commonTextStyle,
          position: 'absolute',
          width: '466px',
          height: '300px',
          left: '910px',
          top: '500px',
          background: '#FFFFFF',
          boxShadow: '0px 4px 4px rgba(0, 0, 0, 0.25)',
          borderRadius: '10px',
          fontFamily: 'Aksara Bali Galang, sans-serif',
          fontStyle: 'normal',
          fontWeight: '400',
          fontSize: '25px',
          lineHeight: '45px',
          color: '#4B398D',
          cursor: 'pointer', // Zmieniamy kursor na wskaźnik, aby pokazać, że element jest klikalny
        }}
        onClick={handleApplyForLeave} // Wywołujemy funkcję po kliknięciu
      >
         URLOPY
      </div>

      {/* POZOSTAŁO CI */}
      <div
        style={{
          position: 'absolute',
          width: '183px',
          height: '45px',
          left: '1058px',
          top: '601px',
          fontFamily: 'Aksara Bali Galang, sans-serif',
          fontStyle: 'normal',
          fontWeight: '400',
          fontSize: '25px',
          lineHeight: '50px',
          color: '#000000',
        }}
      >
        POZOSTAŁO CI
      </div>

      {/* 19/21 DNI URLOPU */}
      <div
        style={{
          position: 'absolute',
          width: '237px',
          height: '48px',
          left: '1031px',
          top: '723px',
          fontFamily: 'Aksara Bali Galang, sans-serif',
          fontStyle: 'normal',
          fontWeight: '400',
          fontSize: '25px',
          lineHeight: '30px',
          color: '#5B40FF',
        }}
      >
        19/21 DNI URLOPU
      </div>
    </div>
  );
};

export default Glowna;
