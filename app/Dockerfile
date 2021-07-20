FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ARG ASPNETCORE_ENVIRONMENT
ARG ASPNETCORE_URLS2
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_URLS $ASPNETCORE_URLS2
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./src .
COPY ngix.conf /etc/nginx/nginx.conf
RUN dotnet restore "MeuAcerto.Selecao.KataGildedRose.Web/MeuAcerto.Selecao.KataGildedRose.Web.csproj"
WORKDIR "/src/MeuAcerto.Selecao.KataGildedRose.Web"
RUN dotnet build "MeuAcerto.Selecao.KataGildedRose.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeuAcerto.Selecao.KataGildedRose.Web.csproj" -c Release -o /app/publish
RUN ls /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
RUN ls
COPY --from=publish /app/publish/wwwroot/ ./
COPY --from=publish /app/publish/wwwroot/appsettings.Docker.json ./appsettings.json
RUN ls
COPY --from=publish /etc/nginx/nginx.conf /etc/nginx/nginx.conf
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "MeuAcerto.Selecao.KataGildedRose.Web.dll"]
