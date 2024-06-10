import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min";

function NavBar() {
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
        style={{ boxShadow: "0px 4px 4px 5px #00000033" }}
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

          <a className="navbar-brand" href="http://localhost:5173/login">
            LOGOWANIE
          </a>
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
                  <a className="nav-link" href="#" style={navLinkStyle}>
                    STRONA GŁÓWNA
                  </a>
                </li>
                <li className="nav-item">
                  <a
                    className="nav-link"
                    href="http://localhost:5173/data"
                    style={navLinkStyle}
                  >
                    DANE OSOBOWE
                  </a>
                </li>
                <li className="nav-item">
                  <a
                    className="nav-link"
                    href="http://localhost:5173/wynagrodzenia"
                    style={navLinkStyle}
                  >
                    WYNAGRODZENIA
                  </a>
                </li>
                <li className="nav-item">
                  <a
                    className="nav-link"
                    href="http://localhost:5173/urlopy"
                    style={navLinkStyle}
                  >
                    URLOPY
                  </a>
                </li>
                <li className="nav-item">
                  <a
                    className="nav-link"
                    href="http://localhost:5173/kalendarz"
                    style={navLinkStyle}
                  >
                    KALENDARZ
                  </a>
                </li>
                <li className="nav-item">
                  <a
                    className="nav-link"
                    href="http://localhost:5173/rekrutacja"
                    style={navLinkStyle}
                  >
                    REKRUTACJA
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#" style={navLinkStyle}>
                    SZKOLENIA
                  </a>
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
