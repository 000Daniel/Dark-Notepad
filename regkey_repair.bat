@echo off
title RegKey Repairs

set arg=%1
set full_arg=%*
set "new_path=%full_arg:* =%"

echo %*
echo %arg%
echo %new_path%

if %arg%==remove (call :removeRegKey)
if %arg%==repair (call :repairRegKey)
exit /B

:removeRegKey
    	cls
    	set dnp=DarkNotepad
    	echo removing Dark-Notepad's registry keys...
	reg delete HKEY_CLASSES_ROOT\*\shell\%dnp% /f
	echo finished!
	pause
	exit /B

:repairRegKey
    	cls
	set dnp=DarkNotepad
    	echo repairing Dark-Notepad's registry keys...
    	echo repairing root key...
	reg add HKEY_CLASSES_ROOT\*\shell\%dnp% /f /d "Edit with DarkNotepad"
	reg add HKEY_CLASSES_ROOT\*\shell\%dnp% /f /v Icon /t REG_SZ /d  "%new_path%\DarkNotepad.exe"
    	echo repairing command key...
	reg add HKEY_CLASSES_ROOT\*\shell\%dnp%\command /f /d  "%new_path%\DarkNotepad.exe %%1"
    	echo finished!
	pause
	exit /B