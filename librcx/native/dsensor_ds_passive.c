/* This file is generated by lego.py. Do not edit.*/
#include <dsensor.h>
void _ZN7brickOS7brickOS7dsensor10ds_passiveEs(short arg0){
  ds_passive((arg0==1?&SENSOR_1:arg0==2?&SENSOR_2:&SENSOR_3));
}
