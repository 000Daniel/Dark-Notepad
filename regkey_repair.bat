@echo off
title RegKey Repairs

set arg=%1
set full_arg=%*
set "new_path=%full_arg:* =%"

echo %*
echo %arg%
echo %new_path%

if %arg%==remove (goto :removeRegKey)
if %arg%==repair (goto :repairRegKey)
exit /B

:removeRegKey
    	cls
    	echo removing Dark-Notepad's registry keys...
	reg delete HKEY_CLASSES_ROOT\*\shell\DarkNotepad /f >nul 2>nul

	reg query HKEY_CLASSES_ROOT\*\shell\DarkNotepad >nul 2>nul
	if %errorlevel%==0 (
		echo.
		echo Failed to delete the key, Attempting again...
		echo If this message shows up too many times, close this command prompt and try again.
		pause
		goto :removeRegKey
	)
	echo.
	echo Action completed successfully!
	echo Software created by 000Daniel on Github!
	pause
	exit /B

:repairRegKey
    	cls
    	echo repairing Dark-Notepad's registry keys...
    	echo repairing root key...
	reg add HKEY_CLASSES_ROOT\*\shell\DarkNotepad /f >nul 2>nul /d "Edit with DarkNotepad"
	reg add HKEY_CLASSES_ROOT\*\shell\DarkNotepad /f >nul 2>nul /v Icon /t REG_SZ /d  "%new_path%\DarkNotepad.exe"
    	echo repairing command key...
	reg add HKEY_CLASSES_ROOT\*\shell\DarkNotepad\command /f >nul 2>nul /d  "%new_path%\DarkNotepad.exe %%1"
    	echo.
	echo Action completed successfully!
	echo Software created by 000Daniel on Github!
	pause
	exit /B