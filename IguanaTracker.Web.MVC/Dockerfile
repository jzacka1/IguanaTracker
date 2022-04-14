#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IguanaTracker.Web.MVC/IguanaTracker.Web.MVC.csproj", "IguanaTracker.Web.MVC/"]
COPY ["IguanaTracker.BL/IguanaTracker.BL.csproj", "IguanaTracker.BL/"]
COPY ["IguanaTracker.Data/IguanaTracker.Data.csproj", "IguanaTracker.Data/"]
RUN dotnet restore "IguanaTracker.Web.MVC/IguanaTracker.Web.MVC.csproj"
COPY . .
WORKDIR "/src/IguanaTracker.Web.MVC"
RUN dotnet build "IguanaTracker.Web.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IguanaTracker.Web.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IguanaTracker.Web.MVC.dll"]