# install scoope
Set-ExecutionPolicy RemoteSigned -scope CurrentUser
Invoke-Expression (New-Object System.Net.WebClient).DownloadString('https://get.scoop.sh')

# install go-task
scoop bucket add extras
scoop install task
Scoop search task

# ecs-cli
New-Item -Path 'C:\Program Files\Amazon\ECSCLI' -ItemType Directory
Invoke-WebRequest -OutFile 'C:\Program Files\Amazon\ECSCLI\ecs-cli.exe' https://amazon-ecs-cli.s3.amazonaws.com/ecs-cli-windows-amd64-latest.exe

#install dotnet command
dotnet tool install --global LocalStack.AwsLocal --version 1.3.3
dotnet tool install -g Amazon.Lambda.Tools
