FROM mcr.microsoft.com/dotnet/sdk:6.0.100-rc.1-windowsservercore-ltsc2022 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o output
FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/output/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 80
EXPOSE 8080