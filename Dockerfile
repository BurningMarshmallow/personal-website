FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS back
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -r linux-musl-x64 -o /app -p:PublishTrimmed=true

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine
WORKDIR /app
COPY --from=back /app .
CMD ASPNETCORE_URLS=http://*:$PORT ./PersonalWebsite
