# 🚀 My Project

![Project Logo](images/onest-logo.png)

Welcome to **My ST project for Weather Forecast App**!  
This README has a clickable **Table of Contents**, section headers. 

**Background Information**: This app is built to check the weather based on selected Singapore location 

---

## 📑 Table of Contents
- [Prerequisite](#prerequisite)
- [Download Project From Git Repo Link](#download-project-from-git-repo-link)
- [Deploying Application Locally](#deploying-application-locally)
- [Application Overview](#application-overview)
- [Demo & Walkthrough](#demo--walkthrough)

---

## Prerequisite

1) Required **.NET 9.0** to be installed

2) Downloadable link for **.NET 9.0** if required: https://dotnet.microsoft.com/en-us/download/dotnet/9.0

3) Recommeded to run in **Windows** Environment for this Project

4) Chrome Browser is installed

## Download Project From Git Repo Link

#### GitHub Repositiory (Option 1)

1) Launched Browser and go to this link: https://github.com/Jackson5240/WeatherCheck

2) From the medium pane, click on "Code" and click on "Download Zip"

![Alt text](images/git_repo_download_zip.png)

3) Extract the zip file (Note: For zip extraction, click on "Extract here" option)

#### Git Clone from Repo (Option 2)

1) Open Powershell and run the following command to clone the repo

```
git clone https://github.com/Jackson5240/WeatherCheck.git
```

## Deploying Application Locally

#### Run "runapp.ps1" (Option 1)

1) Open Powershell (Recommended to run as Administrator) and run the following command

```
## Go to the root folder of the project ( WeatherCheck or WeatherCheck-main )
cd <root folder>

## Run script
.\runapp.ps1
```
###### Script logic flows for runapp.ps1
 - dotnet clean
 - dotnet build
 - Run the application on the background
 - Launch the Application from Chrome

![Alt text](images/app_launched_in_chrome.png)

#### Run manually using Powershell (Option 2)

1) Open Powershell (Recommended to run as Administrator) and run the following command

```
## Go to the root folder of the project ( WeatherCheck or WeatherCheck-main )
cd <root folder>

## Clean Solution
dotnet clean

## Build Solution
dotnet build

## Run App
Start-Process -FilePath "dotnet" -ArgumentList "run --project .\WeatherForecastProj.csproj"
```

2) Launched Chrome and hit the brower with this url: http://localhost:5002

![Alt text](images/app_launched_in_chrome.png)

## Demo & Walkthrough

#### Check Weather based on Area
Select the area in the dropbox to check the forecast

![Alt text](images/app_demo.png)
