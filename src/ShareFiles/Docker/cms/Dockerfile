FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM base AS final

# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY ["cms/publish", "."]
COPY neptuneserver/NT.pfx /app/NT.pfx
COPY Jits.Neptune.Web.Framework.xml /app/Jits.Neptune.Web.Framework.xml
COPY cms/entrypoint.sh /entrypoint.sh
COPY cms/migration-data/ /app/
COPY admin/migration-data/CodeListData.json /app/
RUN chmod 755 /entrypoint.sh

WORKDIR /app
RUN mkdir bin
WORKDIR /app


RUN mkdir App_Data
COPY cms/settings.json /app/App_Data/appsettings.json
COPY cms/configOfDomain.json /app/App_Data/configOfDomain.json

# RUN mkdir cms_data
# COPY ./Jits.Neptune.Web.CMS/cms_data /app/cms_data

RUN mkdir j-webui-template
COPY cms/j-webui-template /app/j-webui-template

RUN mkdir j-webui-login
COPY cms/j-webui-login /app/j-webui-login

RUN mkdir j-webui-stable
COPY cms/j-webui-stable /app/j-webui-stable

RUN mkdir wiz_rs
COPY cms/wiz_rs /app/wiz_rs


ENTRYPOINT "/entrypoint.sh"
