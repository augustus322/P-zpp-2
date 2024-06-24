import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";
import { Link } from "react-router-dom";

function NavBar() {
  const navbarStyle: React.CSSProperties = {
    backgroundColor: "#ffffff", // zmiana tła na białe
    boxShadow: "0px 4px 4px 5px #00000033",
  };

  const sidebarStyle: React.CSSProperties = {
    width: "auto",
    height: "100vh",
    backgroundColor: "#FBFBFB",
    boxShadow: "0px 4px 4px 5px #00000033",
    padding: "10px",
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: 18,
    textAlign: "center",
  };

  const navLinkStyle: React.CSSProperties = {
    color: "#000",
    textDecoration: "none",
  };

  const navLinkActiveStyle: React.CSSProperties = {
    ...navLinkStyle,
    fontWeight: "bold",
  };
  const logo: React.CSSProperties = {
    fontFamily: "Advent Pro, sans-serif",
    color: "#5B40FF",
    fontSize: "50px",
    textAlign: "center",
    padding: "7px",
    textDecoration: "underline",
    margin: "13px",
    textDecorationThickness: "4px",
    textDecorationColor: "#2D2D2D",
  };
  return (
    <>
      <nav
        className="navbar navbar-light  fixed-top"
        style={navbarStyle} // Ustawienie tła nawigacji
      >
        <div className="container-fluid">
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="offcanvas"
            data-bs-target="#offcanvasDarkNavbar"
            aria-controls="offcanvasDarkNavbar"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          <Link className="navbar-brand" to="/login">
            LOGOWANIE
          </Link>
          <div
            className="offcanvas offcanvas-start "
            id="offcanvasDarkNavbar"
            aria-labelledby="offcanvasDarkNavbarLabel"
          >
            <div style={sidebarStyle}>
              <button
                type="button"
                className="btn-close btn-close-black navbar-nav  "
                data-bs-dismiss="offcanvas"
                aria-label="Close"
              ></button>
              <h2 style={logo}> HR360 </h2>

              <ul className="nav flex-column">
                <li className="nav-item">
                  <Link className="nav-link" to="/główna" style={navLinkStyle}>
                    STRONA GŁÓWNA
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/data" style={navLinkStyle}>
                    DANE OSOBOWE
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    to="/wynagrodzenia"
                    style={navLinkStyle}
                  >
                    WYNAGRODZENIA
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/urlopy" style={navLinkStyle}>
                    URLOPY
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    to="/kalendarz"
                    style={navLinkStyle}
                  >
                    KALENDARZ
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    to="/rekrutacja"
                    style={navLinkStyle}
                  >
                    REKRUTACJA
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    to="/szkolenia"
                    style={navLinkStyle}
                  >
                    SZKOLENIA
                  </Link>
                </li>
                <li className="nav-item">
                  <Link
                    className="nav-link"
                    to="/rejestracja"
                    style={navLinkStyle}
                  >
                    REJESTRACJA
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default NavBar;
