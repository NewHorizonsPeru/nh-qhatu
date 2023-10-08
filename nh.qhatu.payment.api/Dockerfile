#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.payment.api/nh.qhatu.payment.api.csproj", "nh.qhatu.payment.api/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.domain/nh.qhatu.domain.csproj", "nh.qhatu.domain/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
COPY ["nh.qhatu.payment.application/nh.qhatu.payment.application.csproj", "nh.qhatu.payment.application/"]
COPY ["nh.qhatu.payment.infrastructure/nh.qhatu.payment.infrastructure.csproj", "nh.qhatu.payment.infrastructure/"]
COPY ["nh.qhatu.payment.domain/nh.qhatu.payment.domain.csproj", "nh.qhatu.payment.domain/"]
RUN dotnet restore "nh.qhatu.payment.api/nh.qhatu.payment.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.payment.api"
RUN dotnet build "nh.qhatu.payment.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.payment.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.payment.api.dll"]