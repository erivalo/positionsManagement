FROM mcr.microsoft.com/dotnet/aspnet:9.0 as base
RUN apt-get update 
RUN apt-get --yes install curl
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY ["management-service/Management.Service/Management.Service.csproj", "Management.Service/"]
RUN dotnet restore "Management.Service/Management.Service.csproj"

COPY ["management-service/Management.Service/", "Management.Service/"]
WORKDIR "Management.Service"
RUN dotnet build "Management.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build as publish
RUN dotnet publish "Management.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
COPY management-service/Management.Service/app.db ./
ENTRYPOINT ["dotnet", "Management.Service.dll"]