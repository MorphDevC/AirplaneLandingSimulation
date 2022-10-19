# AirplaneLandingSimulator

___

## Description

In this repo you can start base airplane landing simulation.

To Start simulation press button ```G```

___

## Base opportunities

___

### Settings menu

In the upper right corner by clicking on the gear wheel, a drop-down menu of settings will open

![image](https://user-images.githubusercontent.com/62260078/196730404-0497c11c-1638-4946-b902-506423e46c71.png)

There are 4 base settings of simulation:
- Distance

  Returns distance between airplane and endpoint to fly in metres (```10km * 1000m = 10 000m```)
  
  Following this setting it becomes possible to determine next options:
  1. Base height position. Look in next prop
  2. Duration of flying.
  
  For example there is the airplane with ```speed = 250 km/h``` and ```distance = 10km```

![image](https://user-images.githubusercontent.com/62260078/196741178-8a63c9b5-c425-47f1-9a61-57e67295fa4b.png)

- GlidePath angle

  Returns angle of rotation for camera.
  
  This property uses to get base height of airplane position
  
  For example there is the airplane with ```Glide path angle = 2°``` and ```distance = 10km```
  
  To get current height it takes ```tg(2°)``` in ```deg``` that equals ~ 0,0349207 and multyplying by distance ```10km```
  
  
  ![image](https://user-images.githubusercontent.com/62260078/196743602-08124fad-7578-4ee7-a3d8-789fc83044fc.png)

  
- Speed of airpling flying
- Height of airplane

  Height of airplane allow player not to look in the ground when fly has been stopped
  
  ![image](https://user-images.githubusercontent.com/62260078/196748400-28f39f46-ce7b-479c-8f17-b64bc750ab3d.png)


These settings are calculate the start position and rotation of airplain.


