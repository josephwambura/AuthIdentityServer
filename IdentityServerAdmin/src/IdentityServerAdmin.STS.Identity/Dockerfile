FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServerAdmin.STS.Identity/IdentityServerAdmin.STS.Identity.csproj", "src/IdentityServerAdmin.STS.Identity/"]
COPY ["src/IdentityServerAdmin.Admin.EntityFramework.Shared/IdentityServerAdmin.Admin.EntityFramework.Shared.csproj", "src/IdentityServerAdmin.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServerAdmin.Shared/IdentityServerAdmin.Shared.csproj", "src/IdentityServerAdmin.Shared/"]
RUN dotnet restore "src/IdentityServerAdmin.STS.Identity/IdentityServerAdmin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/IdentityServerAdmin.STS.Identity"
RUN dotnet build "IdentityServerAdmin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServerAdmin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServerAdmin.STS.Identity.dll"]