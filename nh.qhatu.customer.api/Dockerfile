#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.customer.api/nh.qhatu.customer.api.csproj", "nh.qhatu.customer.api/"]
COPY ["nh.qhatu.customer.application/nh.qhatu.customer.application.csproj", "nh.qhatu.customer.application/"]
COPY ["nh.qhatu.customer.domain/nh.qhatu.customer.domain.csproj", "nh.qhatu.customer.domain/"]
COPY ["nh.qhatu.domain.core/nh.qhatu.domain.csproj", "nh.qhatu.domain.core/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.common.infrastructure/nh.qhatu.common.infrastructure.csproj", "nh.qhatu.common.infrastructure/"]
COPY ["nh.qhatu.common.domain/nh.qhatu.common.domain.csproj", "nh.qhatu.common.domain/"]
COPY ["nh.qhatu.customer.infrastructure/nh.qhatu.customer.infrastructure.csproj", "nh.qhatu.customer.infrastructure/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
COPY ["nh.qhatu.omnichannel.infrastructure/nh.qhatu.omnichannel.infrastructure.csproj", "nh.qhatu.omnichannel.infrastructure/"]
COPY ["nh.qhatu.omnichannel.domain/nh.qhatu.omnichannel.domain.csproj", "nh.qhatu.omnichannel.domain/"]
RUN dotnet restore "nh.qhatu.customer.api/nh.qhatu.customer.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.customer.api"
RUN dotnet build "nh.qhatu.customer.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.customer.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.customer.api.dll"]