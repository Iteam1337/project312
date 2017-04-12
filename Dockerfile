FROM microsoft/dotnet:latest

#RUN apt-get update
#RUN apt-get install -y build-essential

RUN curl -sL https://deb.nodesource.com/setup_7.x | bash -
RUN apt-get install -y nodejs

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build
RUN dotnet publish

ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000
CMD ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000", "mode=container"]
