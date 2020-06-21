# Cool Scripts Storage
This repository will contain scripts that i made and use on regular basis to help automating mundane tasks.
# How To Run
C#: For C# i personally suggest downloading latest <a href="https://www.mono-project.com/" target="_blank">Mono Framework</a> installation, add it to PATH and then execute the script file using the following command:
```powershell
csi ScriptFile.csx
```
PowerShell: Use 
```powershell 
powershell ScriptFile.ps1
``` 
or just  
```powershell 
ScriptFile.ps1
```
if you are on windows.
# Troubleshooting
#### PowerShell
If you are getting Unauthorized Access error, open PowerShell **as admin** and type the following line of code:
```powershell
Set-ExecutionPolicy RemoteSigned
```
then type 'A' and enter.
