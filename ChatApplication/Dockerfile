# Use the .NET Framework SDK image to build the application
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2019 AS build
WORKDIR /src
COPY ["ChatApplication.csproj", "./"]
RUN nuget restore "ChatApplication.csproj"
COPY . .
WORKDIR "/src"
RUN msbuild /p:Configuration=Release /p:OutputPath=/app/build

# Use the .NET Framework runtime image to run the application
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS base
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["ChatApplication.exe"]
