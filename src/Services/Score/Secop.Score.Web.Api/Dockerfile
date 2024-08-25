# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Score/Secop.Score.Web.Api/Secop.Score.Web.Api.csproj", "src/Services/Score/Secop.Score.Web.Api/"]
COPY ["src/Services/Score/Secop.Score.Persistence/Secop.Score.Persistence.csproj", "src/Services/Score/Secop.Score.Persistence/"]
COPY ["src/Core/Secop.Core.Application/Secop.Core.Application.csproj", "src/Core/Secop.Core.Application/"]
COPY ["src/Core/Secop.Core.Domain/Secop.Core.Domain.csproj", "src/Core/Secop.Core.Domain/"]
RUN dotnet restore "./src/Services/Score/Secop.Score.Web.Api/Secop.Score.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Score/Secop.Score.Web.Api"
RUN dotnet build "./Secop.Score.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Secop.Score.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Secop.Score.Web.Api.dll"]