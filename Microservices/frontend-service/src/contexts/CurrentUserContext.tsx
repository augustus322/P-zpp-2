import React, {
  createContext,
  useState,
  useContext,
  ReactNode,
  useEffect,
} from "react";

interface User {
  id: string;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  position: string;
}

interface UserContextType {
  currentUser: User | null;
  setCurrentUser: (currentUser: User | null) => void;
}

const mockedUser: User = {
  id: " ",
  firstName: " ",
  lastName: " ",
  email: " ",
  phone: " ",
  position: " ",
};

const UserContext = createContext<UserContextType | undefined>(undefined);

export const CurrentUserProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [currentUser, setCurrentUser] = useState<User | null>(mockedUser);
  const [id, setId] = useState<string | null>(null);

  useEffect(() => {
    const fetchEmployee = async () => {
      if (id) {
        try {
          const response = await fetch(
            `https://localhost:7175/api/Employees/${id}`
          );
          if (!response.ok) {
            throw new Error("Network response was not ok");
          }
          const data = await response.json();
          setCurrentUser({
            id: data["id"],
            firstName: data["firstName"],
            lastName: data["lastName"],
            email: data["email"],
            phone: data["phone"],
            position: data["position"],
          });
        } catch (error) {
          console.error("Failed to fetch employee data:", error);
        }
      }
    };

    fetchEmployee();
  }, [id]);

  return (
    <UserContext.Provider value={{ currentUser, setCurrentUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useCurrentUser = (): UserContextType => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useCurrentUser must be used within a CurrentUserProvider");
  }
  return context;
};
