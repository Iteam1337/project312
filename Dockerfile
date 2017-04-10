FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000
CMD ["dotnet", "run", "--server.urls", "http://0.0.0.0:5000", "mode=container"]

#RUN mkdir -p /app/obj/Debug/netcoreapp1.0
#RUN touch /app/obj/Debug/netcoreapp1.0/CoreCompileInputs.cache

#RUN mkdir -p /app/obj/Debug/netcoreapp1.0
#RUN touch /app/obj/Debug/netcoreapp1.0/project312.csproj.FileListAbsolute.txt

#RUN chmod -R 777 /app
#RUN chmod -R 777 /tmp
