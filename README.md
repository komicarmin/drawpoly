# DrawPoly
Polygon visualization tool. Draws input polygons in one window and Boolean operation result in another. 

## Usage
Run tool with following CLI command:
```bash
PolyDraw.exe path-to-input-data.txt path-to-result.txt
```

## Input files
Polygon data in files must be in following format:
```bash
x,y,z
x,y,z
x,y,z

x,y,z
x,y,z
x,y,z



```
One empty line represents new end of current polygon and start of new one, while double empty line represents end of file.

Example:
```bash
643508.544956253608689,1831463.091295037884265,13.608339231677062
643507.583161425078288,1831465.501027235761285,13.569608284184639
643506.773306413320825,1831464.166073419386521,13.925623290249504

643506.773306413320825,1831464.166073419386521,13.925623290249504
643507.583161425078288,1831465.501027235761285,13.569608284184639
643506.738572752568871,1831468.103960443288088,13.479353113328044



```
