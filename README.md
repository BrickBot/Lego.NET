Lego.NET
=====================
A project to make the .NET run-time available on a Lego MindStorms RCX running BrickOS firmware.

Original Project Websites
* https://www.dcl.hpi.uni-potsdam.de/research/lego.NET/
* https://osm.hpi.de/LEGO.NET/

Project Article – http://www.jot.fm/issues/issue_2004_02/article2.pdf
* Also included in the version control repository

Dependencies
------------
This project relies on a special branch of binutils and gcc that was developed to support .NET,
and these capabilities later became known as the CLI Front-End (with a related effort being the CLI Back-End).
* [GCC CLI Project](https://gcc.gnu.org/projects/cli.html)
* [ReadMe with Build Instructions](https://gcc.gnu.org/git/?p=gcc.git;a=blob;f=README;hb=refs/vendors/st/heads/README)

The following repositories contain the version of binutils and gcc that were bundled with Lego.NET v1.4
* [binutils-cil](https://github.com/BrickBot/binutils-cil) for h8300-hms cross-compilation
* [gcc-cil](https://github.com/BrickBot/gcc-cil) for h8300-hms cross-compilation, including g++

Related refs in the [GNU GCC Git repository](https://gcc.gnu.org/git.html) can be queried by executing the Git command line noted below,
which are more recent versions of BinUtils-CIL and GCC-CIL than what was bundled with Lego.NET v1.4.
``` Shell
git ls-remote --refs http://gcc.gnu.org/git/gcc.git refs/vendors/st/\*
```

An archive based on one of those refs can be downloaded by executing a Git command like the following:
``` Shell
git archive --format=zip --remote=git://gcc.gnu.org/git/gcc.git refs/vendors/st/heads/cli-fe --output=cli-fe.zip
```

Because Lego.NET programs are designed to run under BrickOS on a Lego MindStorms RCX, the
[H8/300 cross-compilation capabilities](https://gcc.gnu.org/projects/h8300-abi.html) of GCC and BinUtils are also needed.

Between the fact that Lego.NET is designed to work with .NET executables targeting .NET 2.0
and the fact that the toolchain for BrickOS is Linux based, it appears to be advisable to use
the [Mono project](https://mono-project.com/) for the .NET build tasks.
Additionally, by leveraging the [Mono build of MSBuild](https://github.com/mono/msbuild)
SDK-style project files can even be used when building projects targeting .NET Framework 2.0.


Contents
--------
* Quickstart
* What is LEGO .NET
* Visual Studio Integration
* Changing Tower Mode to serial
* Error codes on RCX


Quickstart
----------
1. Delete old firmware of RCX
   + for example:
     - press a special hot key (see the documentation of your firmware)
     - remove batteries and wait until memory is erased

2. The batch files 'legoc', 'loadprog' and 'loadfirm' are located in your install path.
   + To simplify the use of these commands, you can add the install path to 
     the environment variable 'PATH' or copy these files whereever you want.

3. Load new firmware:
   + command: `loadfirm`

4. Compile your .NET program and link it with brickOS.dll,
   which can you find in the folder 'lib'.

5. Compile your .NET Assembly to a native brickOS binary:
   + command: `legoc file.exe`

6. Upload your program to the RCX:
   + command: `loadprog file.lx`
   
7. Execute your program on the RCX:
   + press the green “Run” button

**Note**: If you do not have an USB Tower, please read section 'Changing Tower Mode to serial'


What is LEGO.NET
----------------
LEGO .NET provides some tools and a library to execute programs on the LEGO Mindstorms RCX,
which can be written in any .NET language. Therefore we have developed a frontend for the gcc
and a library to use the functionality of the RCX. As operating system we integrated
brickOS.

Specifically, this release implements the following features of the .NET platform:
* primitive datatypes: bool, char, byte, short, int, float, double
* value types: enums
* single-dimensional zero-based arrays
* classes, including static/instance attributes, properties, and constants
* interfaces
* strings
* delegates
* inheritance and polymorphism (virtual methods)
* overloading
* static/instance methods, including parameters, local variables, constructors, and class constructors
* arithmethic operations
* control flow operations: conditional and unconditional branch instructions, switch


Visual Studio Integration
-------------------------
To make your work with LEGO .NET easier, you can integrate the tools in
Visual Studio 2005.

1. Create a new project (for example: Visual C# Project/Console Application)

2. Add "brickOS wrapper" (brickOS.dll) to references of your project

3. Integrate 'legoc' into the build steps:
   + open the properties dialog of this project by right clicking on the project in the
     solution explorer.
   + Select under 'Common Properties' the page 'Build Events'. Type following
     in field 'Post-build Event Command Line' and replace PATH with your path.
    
     - `"PATH\legoc.bat" "$(TargetPath)"`
    
    + Note: Do not remove the quotes of "PATH\legoc.bat"

4. Integrate 'loadprog' as external tool:
   + Open Dialog 'External Tools' (under menu item 'Tool'/'External Tools')
   + Click the 'Add' button
   + Complete the follwing fields:
     - 'Title': Load to RCX
     - 'Command': PATH\loadprog.bat
     - 'Arguments': "$(ProjectDir)bin\debug\$(TargetName).lx"
     
**Note**: Step 4 has to be done only once.


Changing Tower Mode to serial
-----------------------------
If you do not have an USB Tower, you have to change the variable 'RCXTTY'
in 'loadprog.bat' and 'loadfirm.bat'.

* example: `set RCXTTY=COM1`


Error codes on RCX
------------------
Exceptions are not yet supported. Therefore runtime exceptions are mapped
to error codes shown on the display.

error codes:
* 'E001': OutOfMemoryException
* 'E002': NullReferenceException
* 'E003': IndexOutOfRangeException
