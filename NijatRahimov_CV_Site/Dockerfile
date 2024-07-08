FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NijatRahimov_CV_Site/NijatRahimov_CV_Site.csproj", "NijatRahimov_CV_Site/"]
RUN dotnet restore "NijatRahimov_CV_Site/NijatRahimov_CV_Site.csproj"
COPY . .
WORKDIR "/src/NijatRahimov_CV_Site"
RUN dotnet build "NijatRahimov_CV_Site.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NijatRahimov_CV_Site.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NijatRahimov_CV_Site.dll"]
