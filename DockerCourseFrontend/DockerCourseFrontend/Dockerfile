FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerCourseFrontend/DockerCourseFrontend.csproj", "DockerCourseFrontend/"]
RUN dotnet restore "DockerCourseFrontend/DockerCourseFrontend.csproj"
COPY . .
WORKDIR "/src/DockerCourseFrontend"
RUN dotnet publish "DockerCourseFrontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#ENTRYPOINT ["tail", "-f", "/dev/null"]

FROM nginx:alpine AS base
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

