import axios from "axios";
import { apiDomains } from "./domains";

export const authConnector = axios.create({
  baseURL: apiDomains.auth,
});

export const databaseConnector = axios.create({
  baseURL: apiDomains.database,
});

export const meetingsConnector = axios.create({
  baseURL: apiDomains.meeting,
});

export const recruitmentConnector = axios.create({
  baseURL: apiDomains.recruitment,
});

export const salaryConnector = axios.create({
  baseURL: apiDomains.salary,
});

export const timeOffConnector = axios.create({
  baseURL: apiDomains.timeOff,
});

export const userManagerConnector = axios.create({
  baseURL: apiDomains.userManager,
});
