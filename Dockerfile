FROM microsoft/dotnet:2.2-sdk AS build

COPY ./WebAppForDocker/WebAppForDocker.csproj /webapp/WebAppForDocker.csproj
WORKDIR /webapp

RUN dotnet restore

COPY ./WebAppForDocker /webapp
RUN dotnet publish -c Release -o out



FROM microsoft/dotnet:2.2-aspnetcore-runtime  
COPY --from=build /webapp /webapp
WORKDIR /webapp
ENV APP_NAME CEPA
ENV ENVIRONMENT BEPA

HEALTHCHECK CMD curl --fail http://localhost:80/healthz || exit 1
ENTRYPOINT dotnet out/WebAppForDocker.dll
