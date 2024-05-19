# Check internet connection
```
ping google.com.vn
```
If there is no internet connetion, run the following command to obtain, renew, and release a clients IP address, subnet mask, default gateway, and DNS servers from a DHCP server.
```
yum dhclient
```
# Create first setup Shell Script `Setup.sh`
``` sh
#! bin/bash

# First setup for new server
echo "RUNNING STEP 1..."
# yum -y: assume that the answer to any question which would be asked is yes.
yum -y update
yum -y install yum-utils

# Install docker
echo "RUNNING STEP 2..."
yum-config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
yum -y install docker-ce docker-ce-cli containerd.io docker-compose-plugin
# Prune Docker -a: all, -f: force
docker system prune -af
systemctl start docker
systemctl enable docker

# Install Python
echo "RUNNING STEP 3..."
yum -y install epel-release
yum -y install python-pip

# Install git
echo "RUNNING STEP 4..."
yum -y install git

# Install dotnet 6
echo "RUNNING STEP 5..."
rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
yum -y install dotnet-sdk-6.0
yum -y install aspnetcore-runtime-6.0
yum -y install dotnet-runtime-6.0

exit 0
```
**Or transfer `Setup.sh` file from local to remote server**
```
scp /file/to/send username@remote:/where/to/put
```
Example
```
scp "C:\Users\User\OneDrive\Desktop\Setup.sh" root@192.168.1.184:/root
```
# Run `Setup.sh`
```
bash Setup.sh
```
# Add config Domain IP to file ~/etc/hosts
```
127.0.0.1   localhost localhost.localdomain localhost4 localhost4.localdomain4
::1         localhost localhost.localdomain localhost6 localhost6.localdomain6
192.168.1.166 hcm.jits.com.vn
```
### Check hostname
```
hostname -A
```
### Pull Image
```
docker pull portainer/portainer-ce
docker pull phpmyadmin
docker pull mysql
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker pull rabbitmq:3-management-alpine
```
### Oracle
```
docker login
docker pull store/oracle/database-enterprise:12.2.0.1-slim
docker run -d -it --name oracle -v ~/docker_files/oracle/OracleDBData:/ORCL store/oracle/database-enterprise:12.2.0.1-slim
```
****
# Remove or Uninstall
### Uninstall the Docker Engine, CLI, Containerd, and Docker Compose packages:
```
yum remove docker-ce docker-ce-cli containerd.io docker-compose-plugin
```
Remove images, containers, volumes, or customized configuration files on your host are not automatically removed. To delete all images, containers, and volumes:
```
sudo rm -rf /var/lib/docker
sudo rm -rf /var/lib/containerd
```
### Remove repo (~/etc/yum.repos.d)
```
rm 'RepoFileName'
```
Then press 'y'

**Or force-remove file**
```
rm -f 'FileName'
```
### Remove directory
```
rm -r 'directory'
```
**Or force-remove Directory**
```
rm -rf 'directory'
```
