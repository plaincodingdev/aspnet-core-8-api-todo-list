# Use SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
# ENV ASPNETCORE_HTTP_PORTS=5277
# ENV ASPNETCORE_URLS=http://*:5277
WORKDIR /App
COPY --from=build-env /App/out .

# Expose the port the app runs on
EXPOSE 5277
ENV ASPNETCORE_URLS=http://*:5277

ENTRYPOINT ["dotnet", "aspnet-core-8-todo-list-api.dll"]