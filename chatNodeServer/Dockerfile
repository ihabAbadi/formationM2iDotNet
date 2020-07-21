FROM debian
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install nodejs -yq && apt-get install npm -yq
WORKDIR /app
# ADD index.js .
# ADD package.json .
# ADD /data ./data
ADD . .
RUN npm install
