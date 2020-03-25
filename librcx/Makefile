RUNTIME = ../../gcc-frontend/libruntime/libruntime.o

AR=/usr/local/bin/h8300-hms-ar

libbrickos:
	$(MAKE) -C mscorlib
	$(MAKE) -C native
	$(AR) rucs libbrickos.a $(RUNTIME)

clean:
	$(MAKE) -C native clean
	rm -f libbrickos.a
