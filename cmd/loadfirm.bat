@echo off

setlocal

set LEGO_DIR=%LEGO_DOTNET_DIR%
set LEGO_BIN_DIR=%LEGO_DIR%bin
set LEGO_LIB_DIR=%LEGO_DIR%lib

set RCXTTY=%TOWER_MODE%
set FIRMDL3=%LEGO_BIN_DIR%\firmdl3

set FILE=%LEGO_LIB_DIR%\brickOS.srec

if "%~1"=="/?" goto usage
if "%~1"=="/help" goto usage
if "%~1"=="-help" goto usage
if "%~1"=="--help" goto usage

if not exist "%FILE%" (
    echo.
    echo ERROR: The file required '%FILE%' does not exist.
    echo Please reinstall LEGO .NET.
    goto exit_error
)

"%FIRMDL3%" "%FILE%"
goto exit_normal

:usage
    echo.
    echo loadfirm uploads the required brickOS firmware to the RCX.
    echo. 
    echo usage: loadfirm
    goto exit_normal

:exit_error
    set ERRORLEVEL=1    

:exit_normal
    endlocal