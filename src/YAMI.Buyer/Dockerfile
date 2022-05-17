FROM mcr.microsoft.com/dotnet/sdk:6.0 as publish
WORKDIR /app
COPY . .
RUN dotnet publish src/YAMI.Buyer -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=publish /app/out .

ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT dotnet YAMI.Buyer.dll