#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["Services/API/DNCD.Service.API/DNCD.Service.API.csproj", "Services/API/DNCD.Service.API/"]
COPY ["Services/Features/DNCD.Services.Features.Customer/DNCD.Services.Features.Customer.csproj", "Services/Features/DNCD.Services.Features.Customer/"]
COPY ["Common/DNCD.Common.Base/DNCD.Common.Base.csproj", "Common/DNCD.Common.Base/"]
RUN dotnet restore "Services/API/DNCD.Service.API/DNCD.Service.API.csproj"
COPY . .
WORKDIR "/src/Services/API/DNCD.Service.API"
RUN dotnet build "DNCD.Service.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DNCD.Service.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DNCD.Service.API.dll"]