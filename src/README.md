# Start project

1. Clone project with HTTP

   `git clone https://hcm.jits.com.vn:8062/rndhcm/cbs-neptune.git`

2. Config global user name and email

   `git config --global user.name "Võ Trung Kiên"`

   `git config --global user.email kienvt@jits.com.vn`

3. Switch branch

   `git switch develop`

4. Pull code

   `git pull`

# Commit code

1. Switch branch develop

   `cd cbs-neptune/src`

2. Pull project

   `git pull`

3. Add project

   `git add <project name>`

4. Commit project

   `git commit -m "<comment>"`

5. Push

   `git push`

6. Build service

   `docker pull mcr.microsoft.com/dotnet/aspnet:7.0-alpine`
   `docker pull mcr.microsoft.com/dotnet/sdk:7.0`
   `docker tag mcr.microsoft.com/dotnet/aspnet:7.0-alpine aspnet7-alpine`
   `docker tag mcr.microsoft.com/dotnet/sdk:7.0 aspnet7-sdk`
