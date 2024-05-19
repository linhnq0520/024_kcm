FROM aspnet7-alpine AS base
# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#FROM aspnet7 AS base

WORKDIR /app
EXPOSE 100
EXPOSE 105
EXPOSE 109

FROM base AS final
WORKDIR /app

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY ["ShareFiles/neptuneserver/publish", "."]
COPY ["ShareFiles/neptuneserver/NT.pfx", "."]

ENTRYPOINT ["dotnet", "JITS.Neptune.dll"]
