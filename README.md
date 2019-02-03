# OSD
An Windows OSD implementation based on https://www.codeproject.com/Articles/12597/OSD-window-with-animation-effect-in-C


## Compatitbility
Windows 10

## Usage
#### Default
OSD.Display("Text to display.")

#### Explicit
WinOSD.OSD.Display(
            text:"Text to display.",
            x: 20, 
			y: 45,
            opacity: 255,
            displayTime: 3000,
            animation: AnimateMode.ExpandCollapse,
            animationTime: 200
            );

### PowerShell
Work in progress


