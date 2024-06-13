FROM node:21-alpine AS base
WORKDIR /frontend-service/

COPY frontend-service/package.json /frontend-service/.

RUN npm install

# COPY frontend-service/public/ /frontend-service/public
# COPY frontend-service/src/ /frontend-service/src

COPY frontend-service/. /frontend-service/.

EXPOSE 8080

# CMD [ "npm", "run", "dev" ]

FROM base AS dev

CMD [ "npm", "run", "dev" ]

FROM base AS prod

RUN npm run build

CMD [ "npm", "run", "preview" ]