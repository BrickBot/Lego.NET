@setlocal

@rem required paths: please edit your paths
@set CYGWIN1_DLL_DIR=C:\cygwin\bin
@set GCC_DIR=C:\loewis\gcc
@set GCC_CIL1_DIR=C:\loewis\gcc-frontend\h8300-hms\gcc
@set LEGO_NET_DIR=C:\loewis\LEGO.NET
@set BRICKOS_DIR=C:\loewis\LEGO.NET\brickos
@set TOOL_PREFIX=h8300-hms-
@set H8300_TOOLS_DIR=C:\cygwin\usr\local\bin

@rem requrired tools: please edit your paths
@set DEVENV=%VS80COMNTOOLS%\..\IDE\devenv.com
@set MAKE=C:\cygwin\bin\make.exe
@set STRIP=C:\cygwin\bin\strip.exe
@set AR=C:\cygwin\usr\local\bin\h8300-hms-ar.exe

@set TARGET_DIR=%LEGO_NET_DIR%\deployment\files
@set TARGET_BIN_DIR=%TARGET_DIR%\bin
@set TARGET_LIB_DIR=%TARGET_DIR%\lib

@if not exist %TARGET_DIR% (
    mkdir %TARGET_DIR%
    echo Created directory "%TARGET_DIR%"
)

@if not exist %TARGET_BIN_DIR% (
    mkdir %TARGET_BIN_DIR%
    echo Created directory "%TARGET_BIN_DIR%"
)

@if not exist %TARGET_LIB_DIR% (
    mkdir %TARGET_LIB_DIR%
    echo Created directory "%TARGET_LIB_DIR%"
)

@if not exist "%TARGET_DIR%\examples\linetracker" (
    mkdir "%TARGET_DIR%\examples\linetracker"
    echo Created directory "%TARGET_DIR%\examples\linetracker"
)

"%MAKE%" -C "%GCC_CIL1_DIR%"
"%MAKE%" -C "%GCC_DIR%\libruntime"
"%MAKE%" -C "%LEGO_NET_DIR%\librcx"
"%MAKE%" -C "%LEGO_NET_DIR%\librcx\startup"

"%DEVENV%" /build Release "%LEGO_NET_DIR%\librcx\emulated\brickos\brickOS.csproj"
"%DEVENV%" /build Release "%LEGO_NET_DIR%\deployment\SetSettings\SetSettings.sln"

cp "%CYGWIN1_DLL_DIR%\cygwin1.dll" "%TARGET_BIN_DIR%\cygwin1.dll"
cp "%CYGWIN1_DLL_DIR%\cygiconv-2.dll" "%TARGET_BIN_DIR%\cygiconv-2.dll"
cp "%CYGWIN1_DLL_DIR%\cygintl-3.dll" "%TARGET_BIN_DIR%\cygintl-3.dll"

cp "%BRICKOS_DIR%\util\dll.exe" "%TARGET_BIN_DIR%\dll.exe"
cp "%BRICKOS_DIR%\util\firmdl3.exe" "%TARGET_BIN_DIR%\firmdl3.exe"
cp "%BRICKOS_DIR%\util\makelx.exe" "%TARGET_BIN_DIR%\makelx.exe"

cp "%BRICKOS_DIR%\boot\brickOS.lds" "%TARGET_LIB_DIR%\brickOS.lds"
cp "%BRICKOS_DIR%\boot\brickOS.srec" "%TARGET_LIB_DIR%\brickOS.srec"

cp "%H8300_TOOLS_DIR%\%TOOL_PREFIX%as.exe" "%TARGET_BIN_DIR%\%TOOL_PREFIX%as.exe"
cp "%H8300_TOOLS_DIR%\%TOOL_PREFIX%ld.exe" "%TARGET_BIN_DIR%\%TOOL_PREFIX%ld.exe"
cp "%H8300_TOOLS_DIR%\%TOOL_PREFIX%objcopy.exe" "%TARGET_BIN_DIR%\%TOOL_PREFIX%objcopy.exe"

cp "%GCC_CIL1_DIR%\cil1.exe" "%TARGET_BIN_DIR%\%TOOL_PREFIX%cil1.exe"
"%STRIP%" -s "%TARGET_BIN_DIR%\%TOOL_PREFIX%cil1.exe"

cp "%LEGO_NET_DIR%\deployment\SetSettings\bin\Release\SetSettings.exe" "%TARGET_BIN_DIR%\SetSettings.exe"

cp "%LEGO_NET_DIR%\librcx\mscorlib\Release\mscorlib.dll" "%TARGET_LIB_DIR%\mscorlib.dll"
cp "%LEGO_NET_DIR%\librcx\emulated\brickos\bin\Release\brickOS.dll" "%TARGET_LIB_DIR%\brickOS.dll"

cp "%LEGO_NET_DIR%\librcx\startup\startup.o" "%TARGET_LIB_DIR%\startup.o"

cp "%LEGO_NET_DIR%\librcx\libbrickos.a" "%TARGET_LIB_DIR%\libbrickos.a"

cp "%BRICKOS_DIR%\lib\libc.a" "%TARGET_LIB_DIR%\libc.a"
cp "%BRICKOS_DIR%\lib\libmint.a" "%TARGET_LIB_DIR%\libmint.a"

cp "%LEGO_NET_DIR%\bin\legoc.bat" "%TARGET_DIR%\legoc.bat"
cp "%LEGO_NET_DIR%\bin\loadprog.bat" "%TARGET_DIR%\loadprog.bat"
cp "%LEGO_NET_DIR%\bin\loadfirm.bat" "%TARGET_DIR%\loadfirm.bat"

cp "%LEGO_NET_DIR%\deployment\examples\linetracker\linetracker.sln" "%TARGET_DIR%\examples\linetracker\linetracker.sln"
cp "%LEGO_NET_DIR%\deployment\examples\linetracker\linetracker.csproj" "%TARGET_DIR%\examples\linetracker\linetracker.csproj"
cp "%LEGO_NET_DIR%\deployment\examples\linetracker\linetracker.cs" "%TARGET_DIR%\examples\linetracker\linetracker.cs"

cp "%LEGO_NET_DIR%\librcx\apidoc\LEGO.NET.chm" "%TARGET_DIR%\LEGO.NET.chm"

cp "%LEGO_NET_DIR%\deployment\README.TXT" "%TARGET_DIR%\README.TXT"
cp "%LEGO_NET_DIR%\deployment\COPYING.TXT" "%TARGET_DIR%\COPYING.TXT"

"%DEVENV%" /build Release "%LEGO_NET_DIR%\deployment\SetupProject\SetupProject.sln"

@endlocal


