FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["MovieGallery.Api/MovieGallery.Api.csproj", "MovieGallery.Api/"]
COPY ["MovieGallery.Application/MovieGallery.Application.csproj", "MovieGallery.Application/"]
COPY ["MovieGallery.Contracts/MovieGallery.Contracts.csproj", "MovieGallery.Contracts/"]
COPY ["MovieGallery.Domain/MovieGallery.Domain.csproj", "MovieGallery.Domain/"]
COPY ["MovieGallery.Infrastructure/MovieGallery.Infrastructure.csproj", "MovieGallery.Infrastructure/"]

RUN dotnet restore "MovieGallery.Api/MovieGallery.Api.csproj"

COPY . .

WORKDIR "/src/MovieGallery.Api"

RUN dotnet build "MovieGallery.Api.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet build --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

ENV ASPNETCORE_HTTP_PORTS=5001

EXPOSE 5001

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "MovieGallery.Api.dll"]
