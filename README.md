```Cool
 _____             _ _____           _       _        _____ _                             
/  __ \           | /  ___|         (_)     | |      /  ___| |                            
| /  \/ ___   ___ | \ `--.  ___ _ __ _ _ __ | |_ ___ \ `--.| |_ ___  _ __ __ _  __ _  ___ 
| |    / _ \ / _ \| |`--. \/ __| '__| | '_ \| __/ __| `--. \ __/ _ \| '__/ _` |/ _` |/ _ \
| \__/\ (_) | (_) | /\__/ / (__| |  | | |_) | |_\__ \/\__/ / || (_) | | | (_| | (_| |  __/
 \____/\___/ \___/|_\____/ \___|_|  |_| .__/ \__|___/\____/ \__\___/|_|  \__,_|\__, |\___|
         By Killerdani, 2020          | |                                       __/ |     
         github.com/killerdani24      |_|                                      |___/      
```
# Cool Scripts Storage
This repository will contain scripts that i made and use on regular basis to help automating mundane tasks.
# How To Run
### C#: 
For C# i personally suggest downloading latest <a href="https://www.mono-project.com/" target="_blank">Mono Framework</a> installation, add it to PATH and then execute the script file using the following command:
```powershell
csi ScriptFile.csx
```
### PowerShell: 
Use 
```powershell 
powershell ScriptFile.ps1
``` 
or just  
```powershell 
ScriptFile.ps1
```
if you are on windows.
# Troubleshooting
Press ```Ctrl + C``` to terminate the ongoing process.
### C#

### PowerShell
#### Unauthorized Access
If you are getting Unauthorized Access error, open PowerShell **as admin** and type the following line of code:
```powershell
Set-ExecutionPolicy RemoteSigned
```
then type ```A``` and enter.
