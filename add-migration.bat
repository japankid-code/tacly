@echo off

IF %1.==. GOTO No1

echo Adding migration @ %DATE% %TIME%...
dotnet ef migrations add "%1" --verbose --context ApplicationDbContext --output-dir Data/Migrations
if %errorlevel% neq 0 exit /b %errorlevel%
echo Migration created.
GOTO End1

:No1
  ECHO Provide migration name: dotnet ef migrations add MyNewMigration
GOTO End1

:End1
PAUSE