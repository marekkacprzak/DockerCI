FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DockerCourseApi/DockerCourseApi.csproj", "DockerCourseApi/"]
RUN dotnet restore "DockerCourseApi/DockerCourseApi.csproj"
COPY . .
WORKDIR "/src"
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "DockerCourseApi/DockerCourseApi.csproj" -c $BUILD_CONFIGURATION -o /app/build 
RUN dotnet test "DockerCourseApi.Tests/DockerCourseApi.Tests.csproj"
RUN dotnet publish "DockerCourseApi/DockerCourseApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#ENTRYPOINT ["tail", "-f", "/dev/null"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DockerCourseApi.dll"]
