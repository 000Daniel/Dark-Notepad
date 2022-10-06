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
<img src="https://user-images.githubusercontent.com/90350173/194300530-fc91bb4c-e62f-4103-bbe1-b3662513384b.png" width="800" />
</p>
    <br />
    <br />
    
## Stylizing
    As said before there is a Stylizing option: In the software click on `Format` -> `Stylize...` <br />
    There is even a Color Spectrum to choose your colors from! <br />
    <br />
    <img src="https://user-images.githubusercontent.com/90350173/191742947-42d52fb0-9b88-41b9-be44-73f5b4927500.png" width="450" />
    <br />
    <br />
## Note before installing
    This software should work on any Windows 10 system with or without dotnet installed. <br />
    Since this software was written in C# it might use higher RAM resources when compared to Microsoft's notepad. <br />
    I do not take any responsibility for any kind of damage this software might cause with unintended or unresponsible uses. <br />
    <br />
    <br />
## Change Log
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
Reset Theme: Ctrl+R <br />
Print menu: Ctrl+P <br />
- Fixed an issue with saving files. <br />
- Fixed some styling to be more consistent: <br />
Removed borders from context menu buttons in the text editor. <br />
Added current encoder to status bar. <br />
- Added more comments to the source code. <br />
- Optimized some code and made it more readable. <br />
<br />
<br />

This software was programmed in Visual Studio Community 2022 (.Net 5.0).
>Note: This is an early iteration of this program, so expect limitations with this it.
<br />

```diff
- created by https://github.com/000Daniel
```
Began development on: 3.09.2022 <br />
Publish date: 22.09.2022 <br />
