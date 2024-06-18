import { authConnector as connector } from "./connectors";
import AuthResult from "./dtos/auth/authResult";
import UserCredentials from "./dtos/auth/userCredentials";

const loginUser = async (
  credentials: UserCredentials
): Promise<AuthResult | undefined> => {
  try {
    var response = await connector.post("/auth", credentials);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const authConnector = {
  loginUser,
};

export default authConnector;
