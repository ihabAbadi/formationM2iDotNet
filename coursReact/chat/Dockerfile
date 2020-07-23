FROM ubuntu
RUN apt-get update && apt-get upgrade -yq && apt-get install nodejs -yq && apt-get install npm -yq
WORKDIR /app
ADD . .
RUN npm install
EXPOSE 3000