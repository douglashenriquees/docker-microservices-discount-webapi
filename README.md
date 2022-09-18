## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new webapi -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```
* ```cd Catalog.WebApi```
* ```dotnet add package MongoDB.Driver --version 2.17.1```

## Executando o Projeto

* ```dotnet run --project solution_name.template_project```
* ```app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });```
  * modificação na classe **Program.cs** para redirecionar ao **swagger** acessando a url exposta na api

## Executando o Container do MongoDB

* ```docker run -d -p 27017:27017 --name catalog-mongo mongo```

## Build da Imagem da WebApi

* ```docker build -t catalog-webapi . --no-cache```
* ```docker run -p 4400:80 --name catalog-webapi catalog-webapi```

## Build do Cenário com Docker-Compose

* ```docker network create backend```
* ```docker-compose build --no-cache```
* ```docker-compose up -d```
* ```docker-compose down --rmi all -v```