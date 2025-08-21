FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ./Api/*.csproj ./Api/
COPY ./Application/*.csproj ./Application/
COPY ./Domain/*.csproj ./Domain/
COPY ./Infrastructure/*.csproj ./Infrastructure/
RUN ["dotnet", "restore", "./Api/Api.csproj"]

COPY . .
RUN ["dotnet", "publish", "./Api/Api.csproj", "-c", "Release", "-o", "/app/publish"]

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final

WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 50051

ENTRYPOINT ["dotnet", "Api.dll"]
