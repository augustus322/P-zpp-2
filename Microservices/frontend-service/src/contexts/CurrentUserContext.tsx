// UserContext.tsx
import React, { createContext, useState, useContext, ReactNode } from "react";

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

const mockedUser = {
  id: "1234567890",
  firstName: "Jan",
  lastName: "Kowalski",
  email: "jan.kowalski@example.com",
  phone: "+48 123 456 789",
  position: "Developer",
};

const UserContext = createContext<UserContextType | undefined>(undefined);

export const CurrentUserProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [currentUser, setCurrentUser] = useState<User | null>(mockedUser);

  return (
    <UserContext.Provider value={{ currentUser, setCurrentUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useCurrentUser = (): UserContextType => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUser must be used within a CurrentUserProvider");
  }
  return context;
};
