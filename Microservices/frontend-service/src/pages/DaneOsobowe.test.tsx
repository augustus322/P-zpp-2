import React from "react";
import { render } from "@testing-library/react";
import NavBar from "../components/NavBar";
import FormularzOsobowy from "../components/FormularzDanychOsobowych";
import WyswietlanieDanychOsobowych from "./DaneOsobowe";

test("renders WyswietlanieDanychOsobowych component without crashing", () => {
  render(<WyswietlanieDanychOsobowych />);
});
