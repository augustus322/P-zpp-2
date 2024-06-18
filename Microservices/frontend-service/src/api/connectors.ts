import axios from "axios";

export const authConnector = axios.create({
  baseURL: "http://localhost:5098/api",
});

export const databaseConnector = axios.create({
  baseURL: "http://localhost:5261/api",
});

export const meetingsConnector = axios.create({
  baseURL: "http://localhost:5176/api",
});

export const recruitmentConnector = axios.create({
  baseURL: "http://localhost:5230/api",
});

export const salaryConnector = axios.create({
  baseURL: "http://localhost:5077/api",
});

export const timeOffConnector = axios.create({
  baseURL: "http://localhost:5121/api",
});

export const userManagerConnector = axios.create({
  baseURL: "http://localhost:5116/api",
});
