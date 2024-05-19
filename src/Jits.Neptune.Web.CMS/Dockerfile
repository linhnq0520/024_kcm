FROM aspnet7-alpine AS base
WORKDIR /app
EXPOSE 443
EXPOSE 5000

FROM aspnet7-sdk AS build
WORKDIR /src
COPY ["Jits.Neptune.Web.CMS/Jits.Neptune.Web.CMS.csproj", "Jits.Neptune.Web.CMS/"]
RUN dotnet restore "Jits.Neptune.Web.CMS/Jits.Neptune.Web.CMS.csproj"
COPY . .
WORKDIR "/src/Jits.Neptune.Web.CMS"
RUN dotnet build "Jits.Neptune.Web.CMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jits.Neptune.Web.CMS.csproj" -c Release -o /app/publish

FROM base AS final

# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY /ShareFiles/neptuneserver/NT.pfx /app/NT.pfx
COPY /ShareFiles/Jits.Neptune.Web.Framework.xml /app/Jits.Neptune.Web.Framework.xml
COPY ./Jits.Neptune.Web.CMS/entrypoint.sh /entrypoint.sh


COPY ./ShareFiles/cms/migration-data/ /app/
COPY ./ShareFiles/cms/DeployData/ /app/DeployData/
COPY ./ShareFiles/admin/migration-data/CodeListData.json /app/

RUN chmod 755 /entrypoint.sh

WORKDIR /app
RUN mkdir bin
WORKDIR /app

RUN mkdir App_Data
COPY ./Jits.Neptune.Web.CMS/App_Data/* /app/App_Data

# RUN mkdir cms_data
# COPY ./Jits.Neptune.Web.CMS/cms_data /app/cms_data

# RUN mkdir data
# COPY ./src/ShareFiles/cms/data /app/data

RUN mkdir j-webui-template
COPY ./ShareFiles/cms/j-webui-template /app/j-webui-template

RUN mkdir j-webui-login
COPY ./ShareFiles/cms/j-webui-login /app/j-webui-login

RUN mkdir j-webui-stable
COPY ./ShareFiles/cms/j-webui-stable /app/j-webui-stable

RUN mkdir wiz_rs
COPY ./ShareFiles/cms/wiz_rs /app/wiz_rs


WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT "/entrypoint.sh"
