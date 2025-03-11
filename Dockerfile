ARG PROJECT_NAME=Polyglot.DevSecOps

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app
COPY . .
RUN dotnet publish ${PROJECT} -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
ENTRYPOINT dotnet ${PROJECT}.dll