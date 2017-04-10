FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000
CMD ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000", "mode=container"]
