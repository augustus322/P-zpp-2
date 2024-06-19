console.log(`node env: ${import.meta.env.MODE}`);

export const apiDomains = {
  auth: import.meta.env.VITE_AUTH_ADDRESS,
  database: import.meta.env.VITE_DATABASE_ADDRESS,
  meeting: import.meta.env.VITE_MEETING_ADDRESS,
  recruitment: import.meta.env.VITE_RECRUITMENT_ADDRESS,
  salary: import.meta.env.VITE_SALARY_ADDRESS,
  timeOff: import.meta.env.VITE_TIME_OFF_ADDRESS,
  userManager: import.meta.env.VITE_USER_MANAGER_ADDRESS,
  notification: import.meta.env.VITE_NOTIFICATION_ADDRESS,
  // calendar: "172.20.0.4",
  // course: process.env.,
};

console.log("api domains: ", apiDomains);
