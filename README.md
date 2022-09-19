## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new webapi -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```
* ```cd Discount.WebApi```
* ```dotnet add package Npgsql```
* ```dotnet add package Dapper```

## Executando o Projeto

* ```dotnet run --project solution_name.template_project```
* ```app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });```
  * modificação na classe **Program.cs** para redirecionar ao **swagger** acessando a url exposta na api

## Build do Cenário com Docker-Compose

* ```docker network create backend```
* ```docker-compose build --no-cache```
* ```docker-compose up -d```
* ```docker-compose down --rmi all -v```

## DDL Database

* ```
    CREATE TABLE public.Coupon (
      Id SERIAL PRIMARY KEY,
      ProductName VARCHAR(24) NOT NULL,
      Description TEXT,
      Amount INT
    );
  ```