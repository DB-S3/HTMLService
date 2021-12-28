#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HTMLServer/HTMLServer.csproj", "HTMLServer/"]
COPY ["Logic/Logic.csproj", "Logic/"]
COPY ["Factory/Factory.csproj", "Factory/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "HTMLServer/HTMLServer.csproj"
COPY . .
WORKDIR "/src/HTMLServer"
RUN dotnet build "HTMLServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HTMLServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HTMLServer.dll"]