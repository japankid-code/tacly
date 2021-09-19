#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["backendv3.csproj", "."]
RUN dotnet restore "backendv3.csproj"
COPY . .
COPY . /app
WORKDIR "/src/"
RUN dotnet build "backendv3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backendv3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# RUN chmod +x ./entrypoint.sh
# CMD /bin/bash ./entrypoint.sh
ENTRYPOINT ["/bin/bash", "./entrypoint.sh"]
EXPOSE 5001
