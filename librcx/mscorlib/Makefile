CIL="/cygdrive/c/loewis/gcc-frontend/h8300-hms/gcc/cil1.exe"
AS=/usr/local/bin/h8300-hms-as
AR=/usr/local/bin/h8300-hms-ar

DEVENV="/cygdrive/c/Program Files/Microsoft Visual Studio .NET 2003/Common7/IDE/devenv.exe"

CILFLAGS=-O2 -fomit-frame-pointer

libbrickos:  Release/mscorlib.o
	$(AR) rucs ../libbrickos.a $<

Release/mscorlib.o:  Release/mscorlib.s
	$(AS) -o $@ $<

Release/mscorlib.s: Release/mscorlib.dll
	$(CIL) $(CILFLAGS) $<

Release/mscorlib.dll: mscorlib.il
	$(DEVENV) /build Release mscorlib.vcproj  



