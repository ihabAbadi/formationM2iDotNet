FROM debian
RUN apt-get update -yq && apt-get upgrade -yq
RUN apt-get install nodejs -yq
RUN apt-get install npm  -yq
RUN mkdir node
EXPOSE 80
EXPOSE 3010
WORKDIR /node
ADD . .