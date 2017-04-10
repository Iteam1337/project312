FROM microsoft/dotnet:latest

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5000

ENV ASPNETCORE_URLS http://*:5000

RUN mkdir -p /app/obj/Debug/netcoreapp1.0
RUN touch /app/obj/Debug/netcoreapp1.0/CoreCompileInputs.cache

RUN mkdir -p /app/obj/Debug/netcoreapp1.0
RUN touch /app/obj/Debug/netcoreapp1.0/project312.csproj.FileListAbsolute.txt

RUN chmod -R 777 /app

CMD ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000", "mode=container"]
