FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdentityServerAdmin.Admin.Api/IdentityServerAdmin.Admin.Api.csproj", "src/IdentityServerAdmin.Admin.Api/"]
COPY ["src/IdentityServerAdmin.Admin.EntityFramework.Shared/IdentityServerAdmin.Admin.EntityFramework.Shared.csproj", "src/IdentityServerAdmin.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServerAdmin.Admin.EntityFramework.SqlServer/IdentityServerAdmin.Admin.EntityFramework.SqlServer.csproj", "src/IdentityServerAdmin.Admin.EntityFramework.SqlServer/"]
COPY ["src/IdentityServerAdmin.Shared/IdentityServerAdmin.Shared.csproj", "src/IdentityServerAdmin.Shared/"]
COPY ["src/IdentityServerAdmin.Admin.EntityFramework.PostgreSQL/IdentityServerAdmin.Admin.EntityFramework.PostgreSQL.csproj", "src/IdentityServerAdmin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/IdentityServerAdmin.Admin.EntityFramework.MySql/IdentityServerAdmin.Admin.EntityFramework.MySql.csproj", "src/IdentityServerAdmin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/IdentityServerAdmin.Admin.Api/IdentityServerAdmin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/IdentityServerAdmin.Admin.Api"
RUN dotnet build "IdentityServerAdmin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServerAdmin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServerAdmin.Admin.Api.dll"]