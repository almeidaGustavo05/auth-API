FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app
COPY ../../. ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
EXPOSE 443

ENV LANG pt_BR.UTF-8
ENV ASPNETCORE_URLS=http://+:80

CMD ["dotnet", "Auth.API.dll"]