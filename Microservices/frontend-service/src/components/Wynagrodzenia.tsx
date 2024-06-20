import React, { useState, useEffect } from "react";
import { apiDomains } from "../api/domains";

const mockedSalaries = [
  {
    id: "1",
    firstName: "KAROLINA",
    lastName: "MĄKA",
    amount: 2137.0,
    paymentDate: "2024-06-12T12:30:00Z",
  },
  {
    id: "2",
    firstName: "WIKTORIA",
    lastName: "MRÓZEK",
    amount: 420.0,
    paymentDate: "2024-06-12T12:30:00Z",
  },
  {
    id: "3",
    firstName: "DAWID",
    lastName: "MACHAJ",
    amount: 2137.0,
    paymentDate: "2024-06-12T12:30:00Z",
  },
  {
    id: "4",
    firstName: "MIESZKO",
    lastName: "NIEZGODA",
    amount: 420.0,
    paymentDate: "2024-06-12T12:30:00Z",
  },
];

interface EmployeeSalary {
  id: string;
  firstName?: string;
  lastName?: string;
  amount?: number;
  paymentDate?: string;
}

function Wynagrodzenia() {
  const [paymentsData, setPaymentsData] =
    useState<EmployeeSalary[]>(mockedSalaries);

  useEffect(() => {
    const fetchSalaries = async () => {
      const salaryEndpoint = apiDomains.salary + "/salaryServiceController/";
      try {
        const response = await fetch(salaryEndpoint);
        const parsedResponse = await response.json();
        setPaymentsData(parsedResponse);
      } catch (error) {
        console.error("Error fetching salaries:", error);
      }
    };

    fetchSalaries();
  }, []);

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    return date.toLocaleDateString("pl-PL") + " " + date.toLocaleTimeString("pl-PL", {
      hour: '2-digit',
      minute: '2-digit',
    });
  };

  const containerStyle: React.CSSProperties = {
    backgroundColor: "#F9F6F6",
    boxShadow: "0px 4px 4px 0px #00000040",
    padding: "15px",
    borderRadius: "10px",
    maxWidth: "1000px",
    margin: "0 auto", // Wyśrodkowanie poziome
    display: "flex",
    flexDirection: "column",
    gap: "10px", // Odstęp między wierszami
  };

  const headerRowStyle: React.CSSProperties = {
    backgroundColor: "#F3F3F3",
    boxShadow: "0px 4px 4px 0px #00000040",
    borderRadius: "10px",
    padding: "10px",
    display: "flex",
    justifyContent: "space-between",
    textAlign: "center",
  };

  const headerCellStyle: React.CSSProperties = {
    flex: 1,
  };

  const titleStyle: React.CSSProperties = {
    fontFamily: "Aksara Bali Galang, sans-serif",
    fontSize: "20px",
    textAlign: "left",
    marginBottom: "10px", // Odstęp poniżej tytułu
  };

  const columnContainerStyle: React.CSSProperties = {
    display: "flex",
    flexDirection: "column",
    gap: "10px",
    backgroundColor: "#FBFBFB",
    boxShadow: "0px 4px 4px 0px #00000040",
    borderRadius: "10px",
    padding: "10px",
    flex: 1,
  };

  const cellStyle: React.CSSProperties = {
    textAlign: "center",
  };

  const columnsWrapperStyle: React.CSSProperties = {
    display: "flex",
    gap: "14px", // Odstęp między kolumnami
  };

  const spacerStyle: React.CSSProperties = {
    height: "7px",
    marginTop: "15px",
  };

  const wrapperStyle: React.CSSProperties = {
    maxWidth: "1000px",
    margin: "50px auto", // Wyśrodkowanie kontenera i odstęp od góry
    padding: "20px",
  };

  return (
    <>
      <div style={wrapperStyle}>
        <div style={titleStyle}>WYNAGRODZENIA</div>
        <div style={headerRowStyle}>
          <div style={headerCellStyle}>ID</div>
          <div style={headerCellStyle}>IMIĘ</div>
          <div style={headerCellStyle}>NAZWISKO</div>
          <div style={headerCellStyle}>KWOTA</div>
          <div style={headerCellStyle}>DATA</div>
        </div>
        <div style={spacerStyle}></div> {/* Ramka w kolorze #F3F3F3 */}
        <div style={containerStyle}>
          <div style={columnsWrapperStyle}>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div key={data.id} style={cellStyle}>
                  {data.id}
                </div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div key={data.id} style={cellStyle}>
                  {data.firstName}
                </div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div key={data.id} style={cellStyle}>
                  {data.lastName}
                </div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div key={data.id} style={cellStyle}>
                  {data.amount}
                </div>
              ))}
            </div>
            <div style={columnContainerStyle}>
              {paymentsData.map((data) => (
                <div key={data.id} style={cellStyle}>
                  {formatDate(data.paymentDate!)}
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default Wynagrodzenia;
