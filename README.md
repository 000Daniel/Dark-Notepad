# Dark-Notepad
    DarkNotepad is a recreation of Microsoft's Notepad in C#, and it also supports themes. <br />
    This software was primarily meant to run on Microsoft's Windows 10 and was written in <br />
    C# DOTNET 5.0 using the WinForms library. <br />
    <br />
    <p align="center">
    ![Notepad_Logo_HD](https://user-images.githubusercontent.com/90350173/191742096-84bb5226-05ef-4bad-9083-ec41ff1364f9.png)
    </p>
    <br />
    
## Usage
    Just like a regular notepad, open the software and write or read whatever text file you want to. <br />
    There is an option to modify the Text's font and the program's theme! <br />
    You can also print your documents with a custom Header and Footer! <br />
    <br />
<p align="center">
<img src="https://user-images.githubusercontent.com/90350173/198069458-6bc32794-2da9-47a9-a13a-22a65c032b8a.png" width="800" />
</p>
    <br />
    <br />
    
## Stylizing
    As said before there is a Stylizing option: In the software click on `Format` -> `Stylize...` <br />
    From there you can customize almost everything in Dark-Notepad, down to the Statusbar and Scrollbars!
    There is even a Color Spectrum to choose your colors from! <br />
    <br />
    <img src="https://user-images.githubusercontent.com/90350173/198069735-cadc3ed9-fb1c-4dde-bad5-9989d21884c2.png" width="450" />
    <br />
    <br />
## Included Themes
    From Version 1.0.2 and onward Dark-Notepad will come with a few included themes, here are some of them: <br/>
    <p align="center">
<img src="https://user-images.githubusercontent.com/90350173/198072439-ba98520f-1f8f-4422-af6f-bc8dd93b8daa.png" width="800" />
<img src="https://user-images.githubusercontent.com/90350173/198071764-c8293279-e808-4b34-ba75-1ea94a7cdbe2.png" width="800" />
<img src="https://user-images.githubusercontent.com/90350173/198071774-badfbf24-11c7-4b36-9683-5e2bf7bc800e.png" width="800" />
    </p>

## Note before installing
    This software should work on any Windows 10 system with or without dotnet installed. <br />
    Since this software was written in C# it might use higher RAM resources when compared to Microsoft's notepad. <br />
    I do not take any responsibility for any kind of damage this software might cause with unintended or <br />
    unresponsible uses. <br />
    <br />
    <br />
## Change Log
### Version 1.0.3
- Added new themes: <br/>
`Deep Gray theme`, `Four Faith theme`, `Nostalgic valve theme`, `Retrowave Day theme`. <br/>
- Fixed an issue where opened and unedited files would still require to save. <br/>
- Fixed an issue where CTRL + A shortcut would cause the `Ln: ,Col:` in the status bar to break.
- Now the default encoder is UTF-7 and the encoder settings are saved.
- Batch(.bat) files now no longer get their encoder settings overwritten.
- Updated the `regkey_repair.bat` file to work better.
<br/>

### Version 1.0.2
- Added custom scrollbars. <br/>
This replaces every scrollbar in Dark-Notepad, this feature is also optional.
- Overhauled the Font settings menu. <br/>
now the text selection is done through buttons. <br/>
the current font is now highlighted when the page opens. <br/>
now writing a font's name would highlight it in the selection window.
- Added support for right to left reading order.
- Added right click context menu in the text area
- Added more settings to settings page: <br/>
`enable custom scrollbar`, `enable status bar`, `enable right to left reading order`, `enable edit with darknotepad`.
- Added support for scrolling sideways with `SHIFT + SCROLLWHEEL`.
- Added more options for theme stylizing: <br/>
`statusbar`, `scrollbar`.
- Now Dark-Notepad would generate custom icons based on the stylizing settings.
- Added default directories to import and export themes to.
- Added a theme folder bundled with 7 new themes: <br/>
`Anonymous theme`, `Antarctic Deep theme`, `Antarctic Light theme`, `Crimson Gold theme`, `Cyber Cold theme`. <br/>
And special thanks to [Kemono](https://github.com/Kemono03) for providing these themes: `Cooking Forum theme`, `Green Terminal theme`.
- Added hex color code support in the Color Picker menu.
- Now pressing `ESC` in a context menu closes it.
- Added better support for resize grip handle.
- Added text padding to the text area.
- Added new shortcuts: <br/>

|Shortcut|Comment                                      |
|--------|---------------------------------------------|
|F1      |Opens internet help                          |
|ALT + F |Opens the File menu                          |
|ALT + E |Opens the Edit menu                          |
|ALT + O |Opens the Format menu                        |
|ALT + V |Opens the View menu                          |
|ALT + H |Opens the Help menu                          |
|ALT + X |exits Dark-Notepad                           |

- **Fixed bugs:**
- Added `CTRL + C` and `CTRL + V` to textboxes. <br/>
- Now batch(.bat) files would automatically be encoded with ASCII encoding.
- Fixed find/replace bug not working correctly, aswell as added the ability to press enter to find or replace the next text.
- Added shadow backdrop to the context menus.
- Now leaving an empty textbox in Color Picker resets its value to 0.
- After context menus close Dark-Notepad focuses back into the text area.
- Fixed resize grip handle appearing in fullscreen.
- Fixed incorrect text colors in warning boxes.
- Fixed other minor bugs.
- Added more comments to the source code. <br />
- Optimized some code and made it more readable. <br />
<br />

### Version 1.0.1
- Added printing support. `file` -> `Print...`
- Added print settings. `file` -> `Page Setup...` Known issues: <br />
Footer might sometimes print incorrectly <br />
Page size (A4 etc') might not work! <br />
- Added theme import and export themes: <br />
This feature uses custom .config files. <br />
- Added support for more text encoders: <br />
ASCII, Latin1, UTF-32, UTF-16 Unicode, UTF-16 BE, UTF-8, UTF-7. <br />
- Added file drag n drop support, both to drop into the .exe or into the editor itself. <br />
- Added shortcuts: <br />

|Shortcut |Comment                                     |
|---------|--------------------------------------------|
|CTRL + R |Resets the theme                            |
|CTRL + P |Opens the Print menu                        |

- Fixed an issue with saving files. <br />
- Fixed some styling to be more consistent: <br />
- Removed borders from context menu buttons in the text editor. <br />
- Added current encoder to status bar. <br />
- Added more comments to the source code. <br />
- Optimized some code and made it more readable. <br />
<br />
<br />

This software was programmed in Visual Studio Community 2022 (.Net 5.0).
>Note: This software project is complete and will probably not recieve a lot of support overtime.
<br />

```diff
- created by https://github.com/000Daniel
```
Began development on: 3.09.2022 <br />
Publish date: 22.09.2022 <br />
