// This file is generate by lego.py. Do not edit
// This class is generated. Do not edit
namespace brickOS{

  public class conio{

    public static void cputc_native_0(sbyte arg0){}
    public static void cputc_native_1(sbyte arg0){}
    public static void cputc_native_2(sbyte arg0){}
    public static void cputc_native_3(sbyte arg0){}
    public static void cputc_native_4(sbyte arg0){}
    public static void cputc_native_5(sbyte arg0){}
    public static void cputc_hex_0(ushort arg0){}
    public static void cputc_hex_1(ushort arg0){}
    public static void cputc_hex_2(ushort arg0){}
    public static void cputc_hex_3(ushort arg0){}
    public static void cputc_hex_4(ushort arg0){}
    public static void cputc_hex_5(ushort arg0){}
    public static void cputc_hex(ushort arg0, short arg1){}
    public static void cputw(ushort arg0){}
    public static void cputc_0(ushort arg0){}
    public static void cputc_1(ushort arg0){}
    public static void cputc_2(ushort arg0){}
    public static void cputc_3(ushort arg0){}
    public static void cputc_4(ushort arg0){}
    public static void cputc_5(ushort arg0){}
    public static void cputc(sbyte arg0, short arg1){}
    public static void cls(){}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class dbutton{

    public const ushort BUTTON_ONOFF = 2;
    public const ushort BUTTON_RUN = 4;
    public const ushort BUTTON_VIEW = 16384;
    public const ushort BUTTON_PROGRAM = 32768;
    public static bool RELEASED(short arg0, short arg1){return false;}
    public static bool PRESSED(short arg0, short arg1){return false;}
    public static short _dbutton(){return 0;}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class dkey{

    public const short KEY_ONOFF = 1;
    public const short KEY_RUN = 2;
    public const short KEY_VIEW = 4;
    public const short KEY_PRGM = 8;
    public const short KEY_ANY = 15;
    public static int dkey_pressed(int arg0){return 0;}
    public static int dkey_released(int arg0){return 0;}
    public static short getchar(){return 0;}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class dmotor{

    public const short off = 0;
    public const short fwd = 1;
    public const short rev = 2;
    public const short brake = 3;
    public const byte MIN_SPEED = 0;
    public const byte MAX_SPEED = 255;
    public static void motor_a_dir(short arg0){}
    public static void motor_b_dir(short arg0){}
    public static void motor_c_dir(short arg0){}
    public static void motor_a_speed(byte arg0){}
    public static void motor_b_speed(byte arg0){}
    public static void motor_c_speed(byte arg0){}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class dsensor{

    public const short SENSOR_1 = 1;
    public const short SENSOR_2 = 2;
    public const short SENSOR_3 = 3;
    public static short LIGHT_1 {
      get{ return 0; }
    }
    public static short LIGHT_2 {
      get{ return 0; }
    }
    public static short LIGHT_3 {
      get{ return 0; }
    }
    public static short LIGHT_MAX {
      get{ return 0; }
    }
    public static short ROTATION_1 {
      get{ return 0; }
    }
    public static short ROTATION_2 {
      get{ return 0; }
    }
    public static short ROTATION_3 {
      get{ return 0; }
    }
    public static bool TOUCH_1 {
      get{ return false; }
    }
    public static bool TOUCH_2 {
      get{ return false; }
    }
    public static bool TOUCH_3 {
      get{ return false; }
    }
    public static ushort ds_scale(short arg0){return 0;}
    public static ushort ds_unscale(short arg0){return 0;}
    public static void ds_active(short arg0){}
    public static void ds_passive(short arg0){}
    public static void ds_rotation_set(short arg0, short arg1){}
    public static void ds_rotation_on(short arg0){}
    public static void ds_rotation_off(short arg0){}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class dsound{

    public const short WHOLE = 16;
    public const short HALF = 8;
    public const short QUARTER = 4;
    public const short EIGHTH = 2;
    public const short PITCH_A0 = 0;
    public const short PITCH_Am0 = 1;
    public const short PITCH_H0 = 2;
    public const short PITCH_C1 = 3;
    public const short PITCH_Cm1 = 4;
    public const short PITCH_D1 = 5;
    public const short PITCH_Dm1 = 6;
    public const short PITCH_E1 = 7;
    public const short PITCH_F1 = 8;
    public const short PITCH_Fm1 = 9;
    public const short PITCH_G1 = 10;
    public const short PITCH_Gm1 = 11;
    public const short PITCH_A1 = 12;
    public const short PITCH_Am1 = 13;
    public const short PITCH_H1 = 14;
    public const short PITCH_C2 = 15;
    public const short PITCH_Cm2 = 16;
    public const short PITCH_D2 = 17;
    public const short PITCH_Dm2 = 18;
    public const short PITCH_E2 = 19;
    public const short PITCH_F2 = 20;
    public const short PITCH_Fm2 = 21;
    public const short PITCH_G2 = 22;
    public const short PITCH_Gm2 = 23;
    public const short PITCH_A2 = 24;
    public const short PITCH_Am2 = 25;
    public const short PITCH_H2 = 26;
    public const short PITCH_C3 = 27;
    public const short PITCH_Cm3 = 28;
    public const short PITCH_D3 = 29;
    public const short PITCH_Dm3 = 30;
    public const short PITCH_E3 = 31;
    public const short PITCH_F3 = 32;
    public const short PITCH_Fm3 = 33;
    public const short PITCH_G3 = 34;
    public const short PITCH_Gm3 = 35;
    public const short PITCH_A3 = 36;
    public const short PITCH_Am3 = 37;
    public const short PITCH_H3 = 38;
    public const short PITCH_C4 = 39;
    public const short PITCH_Cm4 = 40;
    public const short PITCH_D4 = 41;
    public const short PITCH_Dm4 = 42;
    public const short PITCH_E4 = 43;
    public const short PITCH_F4 = 44;
    public const short PITCH_Fm4 = 45;
    public const short PITCH_G4 = 46;
    public const short PITCH_Gm4 = 47;
    public const short PITCH_A4 = 48;
    public const short PITCH_Am4 = 49;
    public const short PITCH_H4 = 50;
    public const short PITCH_C5 = 51;
    public const short PITCH_Cm5 = 52;
    public const short PITCH_D5 = 53;
    public const short PITCH_Dm5 = 54;
    public const short PITCH_E5 = 55;
    public const short PITCH_F5 = 56;
    public const short PITCH_Fm5 = 57;
    public const short PITCH_G5 = 58;
    public const short PITCH_Gm5 = 59;
    public const short PITCH_A5 = 60;
    public const short PITCH_Am5 = 61;
    public const short PITCH_H5 = 62;
    public const short PITCH_C6 = 63;
    public const short PITCH_Cm6 = 64;
    public const short PITCH_D6 = 65;
    public const short PITCH_Dm6 = 66;
    public const short PITCH_E6 = 67;
    public const short PITCH_F6 = 68;
    public const short PITCH_Fm6 = 69;
    public const short PITCH_G6 = 70;
    public const short PITCH_Gm6 = 71;
    public const short PITCH_A6 = 72;
    public const short PITCH_Am6 = 73;
    public const short PITCH_H6 = 74;
    public const short PITCH_C7 = 75;
    public const short PITCH_Cm7 = 76;
    public const short PITCH_D7 = 77;
    public const short PITCH_Dm7 = 78;
    public const short PITCH_E7 = 79;
    public const short PITCH_F7 = 80;
    public const short PITCH_Fm7 = 81;
    public const short PITCH_G7 = 82;
    public const short PITCH_Gm7 = 83;
    public const short PITCH_A7 = 84;
    public const short PITCH_Am7 = 85;
    public const short PITCH_H7 = 86;
    public const short PITCH_C8 = 87;
    public const short PITCH_Cm8 = 88;
    public const short PITCH_D8 = 89;
    public const short PITCH_Dm8 = 90;
    public const short PITCH_E8 = 91;
    public const short PITCH_F8 = 92;
    public const short PITCH_Fm8 = 93;
    public const short PITCH_G8 = 94;
    public const short PITCH_Gm8 = 95;
    public const short PITCH_A8 = 96;
    public const short PITCH_PAUSE = 97;
    public const short PITCH_MAX = 98;
    public const short PITCH_END = 255;
    public const ushort DSOUND_BEEP = 0;
    public const ushort DSOUND_SYS_MAX = 1;
    public const short DSOUND_DEFAULT_16th_ms = 200;
    public const short DSOUND_DEFAULT_internote_ms = 15;
    public static ushort dsound_16th_ms {
      get{ return 0; }
    }
    public static ushort dsound_internote_ms {
      get{ return 0; }
    }
    public static void dsound_system(ushort arg0){}
    public static void dsound_set_duration(ushort arg0){}
    public static void dsound_set_internote(ushort arg0){}
    public static bool dsound_playing(){return false;}
    public static void dsound_stop(){}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class stdlib{

    public static ushort calloc(ushort arg0, ushort arg1){return 0;}
    public static ushort malloc(ushort arg0){return 0;}
    public static void free(ushort arg0){}
    public static int random(){return 0;}
    public static void srandom(ushort arg0){}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class time{

    public const short TICK_IN_MS = 1;
    public const short TICKS_PER_SEC = 1000;
    public static uint SECS_TO_TICKS(uint arg0){return 0;}
    public static uint TICKS_TO_SECS(uint arg0){return 0;}
    public static uint get_system_up_time(){return 0;}
  }

}

// This class is generated. Do not edit
namespace brickOS{

  public class unistd{

    public static void exit(short arg0){}
    public static void yield(){}
    public static ushort sleep(ushort arg0){return 0;}
    public static ushort msleep(ushort arg0){return 0;}
    public static void kill(ushort arg0){}
    public static void killall(byte arg0){}
  }

}

