# WorkTracker
quick C# app to track work

This wil live in your system tray when you minimize it. Double clicking should restore it. You can also quit from the system tray. It only tracks time while its running. 

There are 2 windows
- Main window, where you can select a category and push track time
- Data window & options, where you can view info options

The settings are dynamically loaded from a .json file, which is probably easiest to hand edit. You can theoretically edit it in the options UI.

It has some other functionality around 'expected time' and 'maximum time' so if you forget it and never change task, it will time out after an hour or two.

_the code basically documents itself_ ;-) 
