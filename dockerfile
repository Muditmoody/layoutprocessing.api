FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR "/code/webapp"
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /code

COPY /src /code/PWC_LayoutProcessing

RUN dotnet restore "/code/PWCLayoutProcessingWebApp/PWCLayoutProcessingWebApp.csproj"
COPY . .
WORKDIR "/code/PWCLayoutProcessingWebApp"

RUN dotnet build "PWCLayoutProcessingWebApp.csproj" -c Release -o /code/webapp/build

FROM build AS publish
RUN dotnet publish "PWCLayoutProcessingWebApp.csproj" -c Release -o /code/webapp/publish


FROM base AS final
WORKDIR /app
COPY --from=publish code/webapp/publish .
ENTRYPOINT ["dotnet", "PWCLayoutProcessingWebApp.dll"]