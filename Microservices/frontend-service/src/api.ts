// Dla pierwszego mikroserwisu na porcie 5000
import axiosServiceAuth from "axios";

const apiAuth = axiosServiceAuth.create({
  baseURL: "http://localhost:5098/api", //?? nie wiem czy to jest dobrze ale brałam te dane z launchSettings.json z każdego mikroserwisu
});

// Dla drugiego mikroserwisu na porcie 6000
import axiosServiceCourse from "axios";

const apiCourse = axiosServiceCourse.create({
  baseURL: "http://localhost:5175/api",
});

import axiosDatabase from "axios";

const apiDataBase = axiosDatabase.create({
  baseURL: "http://localhost:5261/api",
});

import axiosMeetings from "axios";

const apiMeetings = axiosMeetings.create({
  baseURL: "http://localhost:5176/api",
});

import axiosRecruitment from "axios";

const apiRecruitment = axiosRecruitment.create({
  baseURL: "http://localhost:5116/api",
});

import axiosSalary from "axios";

const apiSalary = axiosSalary.create({
  baseURL: "http://localhost:5077/api",
});
