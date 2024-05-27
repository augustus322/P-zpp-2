FROM node:21-alpine
WORKDIR /frontend-service/

COPY public/ /frontend-service/public
COPY src/ /frontend-service/src
COPY package.json /frontend-service/

RUN npm install

CMD [ "npm", "start" ]