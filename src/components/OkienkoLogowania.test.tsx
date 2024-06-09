import React from "react";
import { render } from "@testing-library/react";
import StronaStartowa from "./OkienkaLogowania";

test("renders StronaStartowa component without crashing", () => {
  render(<StronaStartowa />);
});
