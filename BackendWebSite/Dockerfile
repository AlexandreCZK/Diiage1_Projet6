FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY */*.csproj ./
#RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./Groupe3.Dungeon_Crawler.WebApplication/Groupe3.Dungeon_Crawler.WebApplication.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV CONNEXION_STRING_ENVIRONEMENT=""
ENV IP_FRONT_ENVIRONEMENT=""
ENV CONNEXION_STRING_MONGO=""
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Groupe3.Dungeon_Crawler.WebApplication.dll"]
EXPOSE 44357