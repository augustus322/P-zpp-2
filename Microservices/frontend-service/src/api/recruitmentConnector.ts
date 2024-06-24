import { recruitmentConnector as connector } from "./connectors";
import recruitmentCreateDto from "./dtos/recruitments/recruitmentCreateDto";
import recruitmentReadDto from "./dtos/recruitments/recruitmentReadDto";

const getAllRecruitments = async (): Promise<
  Array<recruitmentReadDto> | undefined
> => {
  try {
    var response = await connector.get("/recruitments");
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const getRecruitmentById = async (
  id: number
): Promise<recruitmentReadDto | undefined> => {
  try {
    var response = await connector.get(`/recruitments/${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const createRecruitment = async (
  recruitment: recruitmentCreateDto
): Promise<recruitmentReadDto | undefined> => {
  try {
    var response = await connector.post(`/recruitments`, recruitment);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const updateRecruitment = async (
  id: number,
  recruitment: recruitmentCreateDto
): Promise<recruitmentReadDto | undefined> => {
  try {
    var response = await connector.put(`/recruitments${id}`, recruitment);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const deleteRecruitment = async (
  id: number
): Promise<recruitmentReadDto | undefined> => {
  try {
    var response = await connector.delete(`/recruitments${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
    return;
  }
};

const recruitmentConnector = {
  getAllRecruitments,
  getRecruitmentById,
  createRecruitment,
  updateRecruitment,
  deleteRecruitment,
};

export default recruitmentConnector;
