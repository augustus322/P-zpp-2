import { userManagerConnector as connector } from "./connectors";
import userCreateDto from "./dtos/userManager/userCreateDto";
import userReadDto from "./dtos/userManager/userReadDto";

const getAllUsers = async (): Promise<Array<userReadDto> | undefined> => {
  try {
    var response = await connector.get("/users");
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const getUserById = async (id: number): Promise<userReadDto | undefined> => {
  try {
    var response = await connector.get(`/users/${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const createUser = async (
  user: userCreateDto
): Promise<userReadDto | undefined> => {
  try {
    var response = await connector.post(`/users`, user);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const updateUser = async (
  id: number,
  user: userCreateDto
): Promise<userReadDto | undefined> => {
  try {
    var response = await connector.put(`/users${id}`, user);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const deleteUser = async (id: number): Promise<userReadDto | undefined> => {
  try {
    var response = await connector.delete(`/users${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const userManagerConnector = {
  getAllUsers,
  getUserById,
  createUser,
  updateUser,
  deleteUser,
};

export default userManagerConnector;
