# 1. Build mərhələsi
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Layihə fayllarını köçür
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 2. Runtime mərhələsi
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Exam.Web.dll"]
