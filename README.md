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
docker build -t aspnet-core-8-todo-list-api .
```

After the image has been built, run the container with the following command:

```bash
docker run --rm -it -p 5277:5277 -e ASPNETCORE_ENVIRONMENT=Development aspnet-core-8-todo-list-api
```


# Articel

Object relational mapping

Code first migration



Create database
```bash
docker run --name postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_USER=postgres -p 5432:5432 -d postgres:16.4
```

Install packages
```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.8
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4

```

```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

