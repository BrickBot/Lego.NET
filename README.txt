Lego.NET, version 1.4
========
A project to make the .NET run-time available on the Lego Mindstorm RCX platform

Original Project Website – https://www.dcl.hpi.uni-potsdam.de/research/lego.NET/

Project Article – http://www.jot.fm/issues/issue_2004_02/article2.pdf
  - Also included in the version control repository

This project relies on the following projects
* binutils-cil for h8300-hms cross-compilation
  - https://github.com/BrickBot/binutils-cil
* gcc-cil for h8300-hms cross-compilation, including g++
  - https://github.com/BrickBot/gcc-cil



Contents
========
-Quickstart
-What is LEGO .NET
-Visual Studio Integration
-Changing Tower Mode to serial
-Error codes on RCX


Quickstart
==========

1. Delete old firmware of RCX
   for example:
        -press a special hot key (see at documentation of your firmware)
        -remove batteries and wait until memory is erased

2. The batch files 'legoc', 'loadprog' and 'loadfirm' are located in your install path.
   To simplify the use of these commands, you can add the install path to 
   the environment variable 'PATH' or copy these files whereever you want.

3. Load new firmware:
   command: loadfirm

4. Compile your .NET program and link it with brickOS.dll,
   which can you find in the folder 'lib'.

5. Compile your .NET Assembly to a native brickOS binary:
   command: legoc file.exe

6. Upload your program to the RCX:
   command: loadprog file.lx
   
7. Execute your program on the RCX: press the green run button

Note: If you do not have an USB Tower, please read section 'Changing Tower Mode to serial'


What is LEGO.NET
=================

LEGO .NET provides some tools and a library to execute programs on the LEGO Mindstorms RCX,
which can be written in any .NET language. Therefore we have developed a frontend for the gcc
and a library to use the functionality of the RCX. As operating system we integrated
brickOS.

Specifically, this release implements the following features of the .NET platform:
- primitive datatypes: bool, char, byte, short, int, float, double
- value types: enums
- single-dimensional zero-based arrays
- classes, including static/instance attributes, properties, and constants
- interfaces
- strings
- delegates
- inheritance and polymorphism (virtual methods)
- overloading
- static/instance methods, including parameters, local variables, constructors, and class constructors
- arithmethic operations
- control flow operations: conditional and unconditional branch instructions, switch


Visual Studio Integration
=========================

To make your work with LEGO .NET easier, you can integrate the tools in
Visual Studio 2005.

1. Create a new project (for example: Visual C# Project/Console Application)

2. Add "brickOS wrapper" (brickOS.dll) to references of your project

3. Integrate 'legoc' into the build steps:
    -open the properties dialog of this project by right clicking on the project in the
     solution explorer.
    -Select under 'Common Properties' the page 'Build Events'. Type following
     in field 'Post-build Event Command Line' and replace PATH with your path.
    
     "PATH\legoc.bat" "$(TargetPath)"
    
     Note: Do not remove the quotes of "PATH\legoc.bat"

4. Integrate 'loadprog' as external tool:
    -Open Dialog 'External Tools' (under menu item 'Tool'/'External Tools')
    -Click the 'Add' button
    -Complete the follwing fields:
     'Title': Load to RCX
     'Command': PATH\loadprog.bat
     'Arguments': "$(ProjectDir)bin\debug\$(TargetName).lx"
     
Note: Step 4 has to be done only once.


Changing Tower Mode to serial
==============================

If you do not have an USB Tower, you have to change the variable 'RCXTTY'
in 'loadprog.bat' and 'loadfirm.bat'.

exmaple: set RCXTTY=COM1


Error codes on RCX
==================

We do not support exceptions yet. Therefore runtime exceptions are mapped
to error codes shown on the display.

error codes:
'E001': OutOfMemoryException
'E002': NullReferenceException
'E003': IndexOutOfRangeException
