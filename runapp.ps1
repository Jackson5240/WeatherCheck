# Stop immediately if any command fails
$ErrorActionPreference = "Stop"

Write-Host "=== Cleaning solution ===" -ForegroundColor Cyan
dotnet clean

Write-Host "=== Building solution ===" -ForegroundColor Cyan
dotnet build

Write-Host "=== Starting application ===" -ForegroundColor Cyan
# Start the app in the background
Start-Process -FilePath "dotnet" -ArgumentList "run --project .\WeatherForecastProj.csproj"

# Wait a little for the app to boot up
Start-Sleep -Seconds 5

Write-Host "=== Launching Chrome ===" -ForegroundColor Cyan
# Open Chrome pointing at localhost:5000 (adjust port if different in launchSettings.json)
Start-Process "chrome.exe" "http://localhost:5002"

Write-Host "=== All steps done ===" -ForegroundColor Green
