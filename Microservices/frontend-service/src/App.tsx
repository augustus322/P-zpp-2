import NavBar from "./components/NavBar";
import StronaStartowa from "./components/OkienkaLogowania";
import StronaLogowania from "../src/pages/StronaLogowania";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import FormularzOsobowy from "./components/FormularzDanychOsobowych";
import StronaRekrutacji from "./pages/StronaRekrutacji";
import StronaKalendarz from "./pages/StronaKalendarz";
import StronaUrlopy from "./pages/StronaUrlopy";
import StronaWynagrodzenia from "./pages/StronaWynagrodzenia";
import AdminStronaDaneOsobowe from "./pages/AdminStronaDaneOsobowe";
import AdminStronaWynagrodzenia from "./pages/AdminStronaWynagrodzenia";
import StronaWniosekOUrlop from "./pages/StronaWniosekOUrlop";
import StronaHRUrlopy from "./pages/StronaHRUrlopy";
import StronaHRRekrutacja from "./pages/StronaHRRekrutacja";
import StronaSzkolenia from "./pages/StronaSzkolenia";
import StronaGłówna from "./pages/StronaGłówna";
import { CurrentUserProvider } from "./contexts/CurrentUserContext";

function App() {
  return (
    <div>
      <CurrentUserProvider>
        <BrowserRouter>
          <Routes>
            <Route index element={<StronaLogowania />}></Route>
            <Route path="/login" element={<StronaLogowania />}></Route>
            <Route path="/data" element={<FormularzOsobowy />}></Route>
            <Route
              path="/rekrutacja"
              element={<StronaRekrutacji></StronaRekrutacji>}
            ></Route>
            <Route
              path="/główna"
              element={<StronaGłówna></StronaGłówna>}
            ></Route>
            <Route
              path="/szkolenia"
              element={<StronaSzkolenia></StronaSzkolenia>}
            ></Route>
            <Route
              path="/kalendarz"
              element={<StronaKalendarz></StronaKalendarz>}
            ></Route>
            <Route
              path="/urlopy"
              element={<StronaUrlopy></StronaUrlopy>}
            ></Route>
            <Route
              path="/wynagrodzenia"
              element={<StronaWynagrodzenia></StronaWynagrodzenia>}
            ></Route>
            <Route
              path="/dataAdmin"
              element={<AdminStronaDaneOsobowe></AdminStronaDaneOsobowe>}
            ></Route>
            <Route
              path="wynagrodzeniaAdmin"
              element={<AdminStronaWynagrodzenia></AdminStronaWynagrodzenia>}
            ></Route>
            <Route
              path="/wniosek-o-urlop"
              element={<StronaWniosekOUrlop></StronaWniosekOUrlop>}
            ></Route>
            <Route
              path="/urlopy-hr"
              element={<StronaHRUrlopy></StronaHRUrlopy>}
            ></Route>
            <Route
              path="/rekrutacja-hr"
              element={<StronaHRRekrutacja></StronaHRRekrutacja>}
            ></Route>
          </Routes>
        </BrowserRouter>
      </CurrentUserProvider>
    </div>
  );
}

export default App;
