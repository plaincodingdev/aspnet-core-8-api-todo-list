Run the project in developer mode:

```bash
dotnet run
```

When the application is running you can open browser to navigate swagger UI at http://localhost:5277/swagger/index.html.

Create docker image and run it in development mode:

```bash
docker build -t aspnet-core-8-todo-list-api .
docker run --rm -it -p 5277:5277 -e ASPNETCORE_ENVIRONMENT=Development aspnet-core-8-todo-list-api
```
