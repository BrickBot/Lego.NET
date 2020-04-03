@echo off

setlocal

set LEGO_DIR=%LEGO_DOTNET_DIR%
set LEGO_BIN_DIR=%LEGO_DIR%bin
set LEGO_LIB_DIR=%LEGO_DIR%lib

set TOOL_PREFIX=h8300-hms-
set CIL1=%LEGO_BIN_DIR%\%TOOL_PREFIX%cil1
set AS=%LEGO_BIN_DIR%\%TOOL_PREFIX%as
set LD=%LEGO_BIN_DIR%\%TOOL_PREFIX%ld
set OBJCOPY=%LEGO_BIN_DIR%\%TOOL_PREFIX%objcopy
set MAKELX=%LEGO_BIN_DIR%\makelx

set CILFLAGS=-L "%LEGO_LIB_DIR%" -O2 -fomit-frame-pointer -mquickcall
set LDFLAGS=-T "%LEGO_LIB_DIR%\brickOS.lds" -relax -L "%LEGO_LIB_DIR%"
set STARTUP=%LEGO_LIB_DIR%\startup.o
set LIBS=-lc -lmint -lbrickos

set BASE1=0xb000
set BASE2=0xb210

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

if "%FILE_EXT%"==".exe" goto start_compile
goto error_invalid_filetype

:start_compile
    set FILE_NO_EXT=%~dpn1
 
    "%CIL1%" %CILFLAGS% "%FILE%"    
    
    if not exist "%FILE_NO_EXT%.s" (
      echo. 
       echo ERROR: '%FILE_NO_EXT%.s' does not exist. Could not build '%FILE_NO_EXT%.o'.
        goto exit_error
    )
    "%AS%" -o "%FILE_NO_EXT%.o" "%FILE_NO_EXT%.s" 
        
    if not exist "%FILE_NO_EXT%.o" (
      echo.
       echo ERROR: '%FILE_NO_EXT%.o' does not exist. Could not build '%FILE_NO_EXT%.dc1'.
        goto exit_error
    )
    "%LD%" -o "%FILE_NO_EXT%.dc1" %LDFLAGS% "%STARTUP%" "%FILE_NO_EXT%.o" %LIBS%  -Ttext %BASE1% --oformat coff-h8300 
    "%LD%" -o "%FILE_NO_EXT%.dc2" %LDFLAGS% "%STARTUP%" "%FILE_NO_EXT%.o" %LIBS%  -Ttext %BASE2% --oformat coff-h8300

    if not exist "%FILE_NO_EXT%.dc1" (
      echo.
       echo ERROR: '%FILE_NO_EXT%.dc1' does not exist. Could not build '%FILE_NO_EXT%.ds1'.
        goto exit_error
    )    
    "%OBJCOPY%" -I coff-h8300 -O symbolsrec "%FILE_NO_EXT%.dc1" "%FILE_NO_EXT%.ds1"

    if not exist "%FILE_NO_EXT%.dc2" (
      echo.
       echo ERROR: '%FILE_NO_EXT%.dc2' does not exist. Could not build '%FILE_NO_EXT%.ds2'.
        goto exit_error
    )    
    "%OBJCOPY%" -I coff-h8300 -O symbolsrec "%FILE_NO_EXT%.dc2" "%FILE_NO_EXT%.ds2"

    if not exist "%FILE_NO_EXT%.ds1" (
      echo.
       echo ERROR: '%FILE_NO_EXT%.ds1' does not exist. Could not build '%FILE_NO_EXT%.lx'.
        goto exit_error
    )
    if not exist "%FILE_NO_EXT%.ds2" (
      echo.
       echo ERROR: '%FILE_NO_EXT%.ds2' does not exist. Could not build '%FILE_NO_EXT%.lx'.
        goto exit_error
    )
    if exist "%FILE_NO_EXT%.lx" del "%FILE_NO_EXT%.lx"
    "%MAKELX%" "%FILE_NO_EXT%.ds1" "%FILE_NO_EXT%.ds2" "%FILE_NO_EXT%.lx"
    
    echo.
    if exist "%FILE_NO_EXT%.lx" echo Successfully build '%FILE_NO_EXT%.lx'.
    
    goto exit_delete

:usage
    echo.
    echo legoc compiles an .NET assembly to a native brickOS binary.
    echo. 
    echo usage: legoc file
    goto exit_normal

:error_invalid_filetype
    echo.
    echo ERROR: The input file has an invalid filetype.
    echo.
    echo Valid filetypes are: .exe    

:exit_error
    set ERRORLEVEL=1    

:exit_delete
    if exist "%FILE_NO_EXT%.s" del "%FILE_NO_EXT%.s"
    if exist "%FILE_NO_EXT%.o" del "%FILE_NO_EXT%.o"
    if exist "%FILE_NO_EXT%.dc1" del "%FILE_NO_EXT%.dc1"
    if exist "%FILE_NO_EXT%.dc2" del "%FILE_NO_EXT%.dc2"
    if exist "%FILE_NO_EXT%.ds1" del "%FILE_NO_EXT%.ds1"
    if exist "%FILE_NO_EXT%.ds2" del "%FILE_NO_EXT%.ds2"
    
 :exit_normal
    endlocal
