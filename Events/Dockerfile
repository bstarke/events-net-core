FROM azcr.docker.prod.walmart.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

RUN echo "<configuration><packageSources> \
<add key=\"dotnet-core\" value=\"https://repository.walmart.com/repository/nuget-gallery/\" /> \
<add key=\"dotnet-core-wmt\" value=\"https://repository.walmart.com/repository/nuget-hosted/\" /> \
</packageSources></configuration>" > nuget.config

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore --configfile nuget.config

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM azcr.docker.prod.walmart.com/dotnet/core/aspnet:2.2
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Events.dll"]