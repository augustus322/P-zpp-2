import React from "react";
import { render, fireEvent } from "@testing-library/react";
import Kalendarz from "./Kalendarz";

describe("Kalendarz Component", () => {
  it("should render button correctly", () => {
    const { getByText } = render(<Kalendarz />);
    const buttonElement = getByText("Dodaj do Kalendarza Google");
    expect(buttonElement).toBeInTheDocument();
  });

  it("should open Google Calendar link in new tab when button is clicked", () => {
    const { getByText } = render(<Kalendarz />);
    const buttonElement = getByText("Dodaj do Kalendarza Google");

    // Mock window.open
    const originalOpen = window.open;
    window.open = jest.fn();

    // Click the button
    fireEvent.click(buttonElement);

    // Check if window.open is called with correct URL and target
    expect(window.open).toBeCalledWith(
      expect.stringContaining("https://www.google.com/calendar/render"),
      "_blank"
    );

    // Restore window.open
    window.open = originalOpen;
  });
});
