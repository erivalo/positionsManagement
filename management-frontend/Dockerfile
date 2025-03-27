FROM node:20-alpine

WORKDIR /app

COPY management-frontend/package*.json .
COPY management-frontend/tsconfig*.json .

RUN npm install

COPY management-frontend/ .

RUN npm run build

EXPOSE 5173

CMD [ "npm", "run", "dev" ]