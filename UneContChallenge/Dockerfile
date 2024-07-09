FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UneContChallenge/UneContChallenge.Presentation.csproj", "UneContChallenge/"]
COPY ["UneContChallenge.Application/UneContChallenge.Application.csproj", "UneContChallenge.Application/"]
COPY ["UneContChallenge.Domain/UneContChallenge.Domain.csproj", "UneContChallenge.Domain/"]
COPY ["UneContChallenge.CrossCutting/UneContChallenge.CrossCutting.csproj", "UneContChallenge.CrossCutting/"]
COPY ["UneContChallenge.Infra.SqlServer/UneContChallenge.Infra.csproj", "UneContChallenge.Infra.SqlServer/"]
RUN dotnet restore "./UneContChallenge/UneContChallenge.Presentation.csproj"
COPY . .
WORKDIR "/src/UneContChallenge"
RUN dotnet build "./UneContChallenge.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UneContChallenge.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UneContChallenge.Presentation.dll"]