import { databaseConnector } from "./connectors";
import employeeCreateDto from "./dtos/employeeCreateDto";
import employeeReadDto from "./dtos/employeeReadDto";

export const getAllEmployees = async (): Promise<
  Array<employeeReadDto> | undefined
> => {
  try {
    var response = await databaseConnector.get("/employees");
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

export const getEmployeeById = async (
  id: number
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await databaseConnector.get(`/employees/${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

export const createEmployee = async (
  employee: employeeCreateDto
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await databaseConnector.post(`/employees`, employee);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

export const updateEmployee = async (
  id: number,
  employee: employeeCreateDto
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await databaseConnector.put(`/employees${id}`, employee);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

export const deleteEmployee = async (
  id: number
): Promise<employeeReadDto | undefined> => {
  try {
    var response = await databaseConnector.delete(`/employees${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};
