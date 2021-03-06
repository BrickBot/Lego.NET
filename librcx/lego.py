class Type:
    def __init__(self, name, mname, csname = None, nullval='0'):
        if not csname:
            csname = name
        self.name = name
        self.mname = mname
        self.csname = csname
        self.nullval = nullval

    def genvalue(self, name):
        return name

void = Type('void', 'v', nullval=None)
bool = Type('int', 'b', 'bool', 'false')
int = Type('int', 's', 'short')
unsigned = Type('unsigned', 't', 'ushort')
long = Type('long', 'l', 'int')
ulong = Type('unsigned long', 'm', 'uint')
char = Type('char', 'a', 'sbyte')
uchar = Type('unsigned char', 'h', 'byte')
charptr = Type('char*', 'Pc', 'string', 'null')
voidptr = Type('void*', 'Pv', 'ushort')

# mem.h
size_t = unsigned

# tm.h
wakeup_t = long
pid_t = size_t
priority_t = uchar

# time.h
time_t = ulong

class Sensorp(Type):
    "Pointer to a sensor"
    def __init__(self):
        Type.__init__(self, 'short', 's', 'short')

    def genvalue(self, name):
        return "(%s==1?&SENSOR_1:%s==2?&SENSOR_2:&SENSOR_3)" % (name, name)

    def generate(self, module, p):
        p.cs('    public const short SENSOR_1 = 1;')
        p.cs('    public const short SENSOR_2 = 2;')
        p.cs('    public const short SENSOR_3 = 3;')
sensorp = Sensorp()

def cstype(p):
    return p[0].csname+' '+p[1]

def ctype(p):
    return p[0].name+' '+p[1]

def mtype(p):
    return p[0].mname

def lname(s):
    return "%d%s" % (len(s), s)

class CModule:
    def generate(self, module, p):
        self.extname = 'brickOS$brickOS$%s$%s' % (module.name, self.func_name())
        p.cfile('%s_%s.c' % ('_'.join(module.fname), self.name))
        p.c('#include <%s.h>' % '/'.join(module.fname))

    def func_name(self):
        return self.name

class Function(CModule):
    def __init__(self, ret, name, *args):
        self.ret = ret
        self.name = name
        self.args = [(t, 'arg%d' % n) for n, t in enumerate(args)]

    def generate(self, module, p):
        if self.name == module.name:
            self.name = '_' + self.name
        params = ', '.join([cstype(param) for param in self.args])
        if self.ret.nullval:
            ret = 'return %s;' % self.ret.nullval
        else:
            ret = ''
        p.cs('    public static %s %s(%s){%s}' % (self.ret.csname, self.name, params, ret))
        CModule.generate(self, module, p)
        self.extname = "_ZN7brickOS7brickOS" + lname(module.name) + lname(self.name) + 'E'
        for param in self.args:
            self.extname += mtype(param)
        if not self.args:
            self.extname += 'v'
        params = ', '.join([ctype(param) for param in self.args])
        p.c('%s %s(%s){' % (self.ret.name, self.extname, params))
        p.c('  %s(%s);' % (self.name, ', '.join([t.genvalue(v) for t,v in self.args])))
        p.c('}')

f = Function

class Constant:
    def __init__(self, type, name, value):
        self.name = name
        self.value = value
        self.type = type

    def generate(self, module, p):
        p.cs("    public const %s %s = %s;" % (self.type.csname, self.name, self.value))
c = Constant

class Enumeration:
    def __init__(self, name, *enumerators):
        self.enumerators = enumerators

    def generate(self, module, p):
        # generate as short constants for now
        for n,e in enumerate(self.enumerators):
            p.cs('    public const short %s = %d;' % (e,n))
e = Enumeration

class EnumerationReference(Type):
    def __init__(self, name):
        # generate as short for now
        self.name = 'short'
        self.mname = 'N'+lname(name)+'E'
        self.csname = 'short'
eref = EnumerationReference

class Property(CModule):
    def __init__(self, type, name):
        self.type = type
        self.name = name

    def generate(self, module, p):
        p.cs('    public static %s %s {' % (self.type.csname, self.name))
        p.cs('      get{ return %s; }' % self.type.nullval)
        p.cs('    }')
        CModule.generate(self, module, p)
	self.extname = "_ZN7brickOS7brickOS" + lname(module.name) + lname("get_"+self.name) + "Ev"
        p.c('%s %s(){' % (self.type.name, self.extname))
        p.c('  return %s;' % self.name)
        p.c('}')

    def func_name(self):
        return "get_"+self.name
p = Property

class Module:
    modules = []
    def __init__(self, name, *contents):
        self.name = name[-1]
        self.fname = name
        self.contents = contents
        self.modules.append(self)

    def generate(self, p):
        p.cs("// This class is generated. Do not edit")
        p.cs('namespace brickOS{\n')
        p.cs('  public class %s{\n' % self.name)
        for o in self.contents:
            o.generate(self, p)
        p.cs('  }\n')
        p.cs('}\n')

class Printer:
    def __init__(self):
        self.cf = None
        self.cfiles = []

    def cfile(self, name):
        if self.cf: self.cf.close()
        self.cf = open("native/"+name, 'w')
        self.cf.write("/* This file is generated by lego.py. Do not edit.*/\n")
        self.cfiles.append(name)

    def cs(self, text):
        self.csf.write(text+'\n')

    def c(self, text):
        self.cf.write(text+'\n')

    def generate(self):
        self.csf = open('emulated/brickOS/brickOS.cs','w')
        self.csf.write("// This file is generate by lego.py. Do not edit\n")
        for m in Module.modules:
            m.generate(self)
        self.cf.close()
        self.csf.close()
        makefile = open('native/Makefile','w')
        makefile.write(
        "# This file is generated by lego.py. Do not edit.\n"
        "COPT=-O2 -fno-builtin -fomit-frame-pointer -mquickcall\n"
        "CC=/usr/local/bin/h8300-hms-gcc\n"
        "AR=/usr/local/bin/h8300-hms-ar\n"
        "CFLAGS=-I/usr/local/include/brickos $(COPT)\n"
        "include extra/files\n")
        makefile.write('CFILES=${EXTRA}\\\n')
        for f in self.cfiles[:-1]:
            makefile.write('  %s\\\n' % f)
        makefile.write('  %s\n\n' % self.cfiles[-1])
        makefile.write('OBJFILES=${CFILES:%.c=%.o}\n\n')
        makefile.write('libbrickos: ${OBJFILES}\n\t$(AR) rucs ../libbrickos.a ${OBJFILES}\n\n')
        makefile.write('clean:\n\trm -f ${OBJFILES}\n\n')

Module(['conio'],
        f(void, 'cputc_native_0', char),
        f(void, 'cputc_native_1', char),
        f(void, 'cputc_native_2', char),
        f(void, 'cputc_native_3', char),
        f(void, 'cputc_native_4', char),
        f(void, 'cputc_native_5', char),
        f(void, 'cputc_hex_0', unsigned),
        f(void, 'cputc_hex_1', unsigned),
        f(void, 'cputc_hex_2', unsigned),
        f(void, 'cputc_hex_3', unsigned),
        f(void, 'cputc_hex_4', unsigned),
        f(void, 'cputc_hex_5', unsigned),
        f(void, 'cputc_hex', unsigned, int),
        f(void, 'cputw', unsigned),
        f(void, 'cputc_0', unsigned),
        f(void, 'cputc_1', unsigned),
        f(void, 'cputc_2', unsigned),
        f(void, 'cputc_3', unsigned),
        f(void, 'cputc_4', unsigned),
        f(void, 'cputc_5', unsigned),
        f(void, 'cputc', char, int),
        #TODO: f(void, 'cputs', charptr),
        f(void, 'cls')
)

Module(['dbutton'],
        c(unsigned, 'BUTTON_ONOFF', 0x0002),
        c(unsigned, 'BUTTON_RUN', 0x0004),
        c(unsigned, 'BUTTON_VIEW', 0x4000),
        c(unsigned, 'BUTTON_PROGRAM', 0x8000),
        f(bool,'RELEASED', int, int),
        f(bool,'PRESSED', int, int),
        f(int,'dbutton')
)

Module(['dkey'],
        c(int, 'KEY_ONOFF', 0x01),
        c(int, 'KEY_RUN', 0x02),
        c(int, 'KEY_VIEW', 0x04),
        c(int, 'KEY_PRGM', 0x08),
        c(int, 'KEY_ANY', 0x0f),
        f(wakeup_t, 'dkey_pressed', wakeup_t),
        f(wakeup_t, 'dkey_released', wakeup_t),
        f(int,'getchar')
)

#dlcd.h requires direct memory access
Module(['dmotor'],
        e('MotorDirection', 'off', 'fwd', 'rev', 'brake'),
        c(uchar, 'MIN_SPEED', 0),
        c(uchar, 'MAX_SPEED', 255),
        # TODO: brickOS.dll says parameter is short
        #f(void, 'motor_a_dir', eref('MotorDirection')),
        #f(void, 'motor_b_dir', eref('MotorDirection')),
        #f(void, 'motor_c_dir', eref('MotorDirection')),
        f(void, 'motor_a_dir', int),
        f(void, 'motor_b_dir', int),
        f(void, 'motor_c_dir', int),
        f(void, 'motor_a_speed', uchar),
        f(void, 'motor_b_speed', uchar),
        f(void, 'motor_c_speed', uchar),
)

Module(['dsensor'],
        sensorp,
        p(int, 'LIGHT_1'),
        p(int, 'LIGHT_2'),
        p(int, 'LIGHT_3'),
        p(int, 'LIGHT_MAX'),
        p(int, 'ROTATION_1'),
        p(int, 'ROTATION_2'),
        p(int, 'ROTATION_3'),
        # disabled in config.h
        # p(int, 'VELOCITY_1'),
        # p(int, 'VELOCITY_2'),
        # p(int, 'VELOCITY_3'),
        p(bool, 'TOUCH_1'),
        p(bool, 'TOUCH_2'),
        p(bool, 'TOUCH_3'),
        f(unsigned, 'ds_scale', int),
        f(unsigned, 'ds_unscale', int),
        f(void, 'ds_active', sensorp),
        f(void, 'ds_passive', sensorp),
        f(void, 'ds_rotation_set', sensorp, int),
        f(void, 'ds_rotation_on', sensorp),
        f(void, 'ds_rotation_off', sensorp)
)

Module(['dsound'],
        c(int, 'WHOLE', 16),
        c(int, 'HALF', 8),
        c(int, 'QUARTER', 4),
        c(int, 'EIGHTH', 2),
        c(int, 'PITCH_A0', 0),
        c(int, 'PITCH_Am0', 1),
        c(int, 'PITCH_H0', 2),
        c(int, 'PITCH_C1', 3),
        c(int, 'PITCH_Cm1', 4),
        c(int, 'PITCH_D1', 5),
        c(int, 'PITCH_Dm1', 6),
        c(int, 'PITCH_E1', 7),
        c(int, 'PITCH_F1', 8),
        c(int, 'PITCH_Fm1', 9),
        c(int, 'PITCH_G1', 10),
        c(int, 'PITCH_Gm1', 11),
        c(int, 'PITCH_A1', 12),
        c(int, 'PITCH_Am1', 13),
        c(int, 'PITCH_H1', 14),
        c(int, 'PITCH_C2', 15),
        c(int, 'PITCH_Cm2', 16),
        c(int, 'PITCH_D2', 17),
        c(int, 'PITCH_Dm2', 18),
        c(int, 'PITCH_E2', 19),
        c(int, 'PITCH_F2', 20),
        c(int, 'PITCH_Fm2', 21),
        c(int, 'PITCH_G2', 22),
        c(int, 'PITCH_Gm2', 23),
        c(int, 'PITCH_A2', 24),
        c(int, 'PITCH_Am2', 25),
        c(int, 'PITCH_H2', 26),
        c(int, 'PITCH_C3', 27),
        c(int, 'PITCH_Cm3', 28),
        c(int, 'PITCH_D3', 29),
        c(int, 'PITCH_Dm3', 30),
        c(int, 'PITCH_E3', 31),
        c(int, 'PITCH_F3', 32),
        c(int, 'PITCH_Fm3', 33),
        c(int, 'PITCH_G3', 34),
        c(int, 'PITCH_Gm3', 35),
        c(int, 'PITCH_A3', 36),
        c(int, 'PITCH_Am3', 37),
        c(int, 'PITCH_H3', 38),
        c(int, 'PITCH_C4', 39),
        c(int, 'PITCH_Cm4', 40),
        c(int, 'PITCH_D4', 41),
        c(int, 'PITCH_Dm4', 42),
        c(int, 'PITCH_E4', 43),
        c(int, 'PITCH_F4', 44),
        c(int, 'PITCH_Fm4', 45),
        c(int, 'PITCH_G4', 46),
        c(int, 'PITCH_Gm4', 47),
        c(int, 'PITCH_A4', 48),
        c(int, 'PITCH_Am4', 49),
        c(int, 'PITCH_H4', 50),
        c(int, 'PITCH_C5', 51),
        c(int, 'PITCH_Cm5', 52),
        c(int, 'PITCH_D5', 53),
        c(int, 'PITCH_Dm5', 54),
        c(int, 'PITCH_E5', 55),
        c(int, 'PITCH_F5', 56),
        c(int, 'PITCH_Fm5', 57),
        c(int, 'PITCH_G5', 58),
        c(int, 'PITCH_Gm5', 59),
        c(int, 'PITCH_A5', 60),
        c(int, 'PITCH_Am5', 61),
        c(int, 'PITCH_H5', 62),
        c(int, 'PITCH_C6', 63),
        c(int, 'PITCH_Cm6', 64),
        c(int, 'PITCH_D6', 65),
        c(int, 'PITCH_Dm6', 66),
        c(int, 'PITCH_E6', 67),
        c(int, 'PITCH_F6', 68),
        c(int, 'PITCH_Fm6', 69),
        c(int, 'PITCH_G6', 70),
        c(int, 'PITCH_Gm6', 71),
        c(int, 'PITCH_A6', 72),
        c(int, 'PITCH_Am6', 73),
        c(int, 'PITCH_H6', 74),
        c(int, 'PITCH_C7', 75),
        c(int, 'PITCH_Cm7', 76),
        c(int, 'PITCH_D7', 77),
        c(int, 'PITCH_Dm7', 78),
        c(int, 'PITCH_E7', 79),
        c(int, 'PITCH_F7', 80),
        c(int, 'PITCH_Fm7', 81),
        c(int, 'PITCH_G7', 82),
        c(int, 'PITCH_Gm7', 83),
        c(int, 'PITCH_A7', 84),
        c(int, 'PITCH_Am7', 85),
        c(int, 'PITCH_H7', 86),
        c(int, 'PITCH_C8', 87),
        c(int, 'PITCH_Cm8', 88),
        c(int, 'PITCH_D8', 89),
        c(int, 'PITCH_Dm8', 90),
        c(int, 'PITCH_E8', 91),
        c(int, 'PITCH_F8', 92),
        c(int, 'PITCH_Fm8', 93),
        c(int, 'PITCH_G8', 94),
        c(int, 'PITCH_Gm8', 95),
        c(int, 'PITCH_A8', 96),
        c(int, 'PITCH_PAUSE', 97),
        c(int, 'PITCH_MAX', 98),
        c(int, 'PITCH_END', 255),
        c(unsigned, 'DSOUND_BEEP', 0),
        c(unsigned, 'DSOUND_SYS_MAX', 1),
        c(int, 'DSOUND_DEFAULT_16th_ms', 200),
        c(int, 'DSOUND_DEFAULT_internote_ms', 15),
        p(unsigned,'dsound_16th_ms'),
        p(unsigned,'dsound_internote_ms'),
        #TODO: dsound_play
        f(void,'dsound_system', unsigned),
        f(void,'dsound_set_duration', unsigned),
        f(void,'dsound_set_internote', unsigned),
        f(bool,'dsound_playing'),
        #TODO: dsound_finished
        f(void, 'dsound_stop')
)

# TODO: semaphore.h

Module(['stdlib'],
        f(voidptr, 'calloc', size_t, size_t),
        f(voidptr, 'malloc', size_t),
        f(void, 'free', voidptr),
        f(long, 'random'),
        f(void, 'srandom', unsigned)
)

# TODO: string.h

Module(['time'],
        c(int, 'TICK_IN_MS', 1),
        c(int, 'TICKS_PER_SEC', 1000),
        f(time_t, 'SECS_TO_TICKS', ulong),
        f(ulong, 'TICKS_TO_SECS', time_t),
        f(time_t, 'get_system_up_time')
)

# TODO: tm.h

Module(['unistd'],
        # TODO: execi
        f(void, 'exit', int),
        f(void, 'yield'),
        # TODO: wait_event
        f(unsigned, 'sleep', unsigned),
        f(unsigned, 'msleep', unsigned),
        f(void, 'kill', pid_t),
        f(void, 'killall', priority_t)
)

Printer().generate()
