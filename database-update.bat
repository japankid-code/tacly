@echo off
echo Updating BackendTacly ApplicationDbContext tables @ %DATE% %TIME%
dotnet ef database update --context ApplicationDbContext 
if %errorlevel% neq 0 exit /b %errorlevel%

echo Database Update Completed.
PAUSE