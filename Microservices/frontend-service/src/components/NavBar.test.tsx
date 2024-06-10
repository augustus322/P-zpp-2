import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import NavBar from "./NavBar";

describe("NavBar Component", () => {
  it("renders all navigation links", () => {
    render(<NavBar />);

    const links = screen.getAllByRole("link");

    expect(links.length).toBe(7); // Sprawdź, czy wszystkie linki nawigacyjne są renderowane
  });

  it("toggles offcanvas sidebar when toggler button is clicked", () => {
    render(<NavBar />);

    const togglerButton = screen.getByRole("button", {
      name: "Toggle navigation",
    });
    const offcanvas = screen.getByTestId("offcanvas");

    fireEvent.click(togglerButton);

    expect(offcanvas).toHaveClass("show"); // Sprawdź, czy offcanvas sidebar jest widoczny po kliknięciu przycisku toggler

    fireEvent.click(togglerButton);

    expect(offcanvas).not.toHaveClass("show"); // Sprawdź, czy offcanvas sidebar jest ukryty po ponownym kliknięciu przycisku toggler
  });

  // Dodaj więcej testów w zależności od potrzeb
});
