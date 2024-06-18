import { databaseConnector as connector } from "./connectors";
import employeeCreateDto from "./dtos/database/employeeCreateDto";
import employeeReadDto from "./dtos/database/employeeReadDto";

const getAllEmployees = async (): Promise<
  Array<employeeReadDto> | undefined
> => {
  try {
    var response = await connector.get("/employees");
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const getEmployeeById = async (
  id: number
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await connector.get(`/employees/${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const createEmployee = async (
  employee: employeeCreateDto
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await connector.post(`/employees`, employee);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const updateEmployee = async (
  id: number,
  employee: employeeCreateDto
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await connector.put(`/employees${id}`, employee);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const deleteEmployee = async (
  id: number
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await connector.delete(`/employees${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const databaseConnector = {
  getAllEmployees,
  getEmployeeById,
  createEmployee,
  updateEmployee,
  deleteEmployee,
};

export default databaseConnector;
