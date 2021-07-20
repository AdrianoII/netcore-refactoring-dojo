FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /api
ARG ASPNETCORE_ENVIRONMENT
ARG ASPNETCORE_URLS2
ENV ASPNETCORE_ENVIRONMENT $ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_URLS $ASPNETCORE_URLS2
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./src .
RUN dotnet restore "MeuAcerto.Selecao.KataGildedRose.API/MeuAcerto.Selecao.KataGildedRose.API.csproj"
WORKDIR "/src/MeuAcerto.Selecao.KataGildedRose.API"
RUN dotnet build "MeuAcerto.Selecao.KataGildedRose.API.csproj" -c Release -o /api/build

FROM build AS publish
RUN dotnet publish "MeuAcerto.Selecao.KataGildedRose.API.csproj" -c Release -o /api/publish

FROM base AS final
WORKDIR /api
COPY --from=publish /api/publish .
ENTRYPOINT ["dotnet", "MeuAcerto.Selecao.KataGildedRose.API.dll"]
