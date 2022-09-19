FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Discount.WebApi/Discount.WebApi.csproj", "Discount.WebApi/"]
RUN dotnet restore "Discount.WebApi/Discount.WebApi.csproj"
COPY . .
WORKDIR /src/Discount.WebApi
RUN dotnet build "Discount.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Discount.WebApi.dll" ]