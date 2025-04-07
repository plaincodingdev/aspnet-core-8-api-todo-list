# Run the Project in Developer Mode

To start the project in developer mode, use the following command in your terminal:

```bash
dotnet build
dotnet run
```

Once the application is running, you can access the Swagger UI to test and interact with your API. Open your preferred web browser and navigate to:

```bash
http://localhost:5277/swagger/index.html
```

## Create and Run Docker Image in Development Mode

Use the following command to build the Docker image. This command tags the image with a name to make it easier to reference later:

```bash
# Production image
docker build -t aspnet-core-8-api-todo-list:latest .
# Development image
docker build -t aspnet-core-8-api-todo-list:latest-dev -f Dockerfile.dev .
```

After the image has been built, run the container with the following command:

```bash
# Production image
docker run --rm -it --name todo-api -p 5277:5277 -e ASPNETCORE_ENVIRONMENT=Development aspnet-core-8-api-todo-list:latest
# Development image
docker run --rm -it --name todo-api -p 5277:5277 -e ASPNETCORE_ENVIRONMENT=Development aspnet-core-8-api-todo-list:latest-dev
```