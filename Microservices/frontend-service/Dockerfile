FROM node:21-alpine
WORKDIR /frontend-service/

COPY frontend-service/public/ /frontend-service/public
COPY frontend-service/src/ /frontend-service/src
COPY frontend-service/package.json /frontend-service/

RUN npm install

CMD [ "npm", "run", "dev" ]