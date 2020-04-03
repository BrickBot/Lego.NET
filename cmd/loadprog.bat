@echo off

setlocal

set LEGO_DIR=%LEGO_DOTNET_DIR%
set LEGO_BIN_DIR=%LEGO_DIR%bin

set RCXTTY=%TOWER_MODE%
set DLL=%LEGO_BIN_DIR%\dll

if "%~1"=="" goto usage
if "%~1"=="/?" goto usage
if "%~1"=="/help" goto usage
if "%~1"=="-help" goto usage
if "%~1"=="--help" goto usage

set FILE=%~1
set FILE_EXT=%~x1

if not exist "%FILE%" (
    echo.
    echo ERROR: The file '%FILE%' does not exist.
    goto exit_error
)

if "%FILE_EXT%"==".lx" goto start_loading
goto error_invalid_filetype

:start_loading
    "%DLL%" "%FILE%"
    if not ERRORLEVEL 0 goto exit_error
    goto exit_normal

:usage
    echo.
    echo loadprog uploads a program as brickOS binary to the RCX.
    echo. 
    echo usage: loadprog file.lx
    goto exit_normal

:error_invalid_filetype
    echo.
    echo ERROR: The input file has an invalid filetype.
    echo.
    echo Valid filetype is: .lx

:exit_error
    set ERRORLEVEL=1    

:exit_normal
    endlocal