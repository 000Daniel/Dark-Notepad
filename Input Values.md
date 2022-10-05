# Changing Header and Footer Commands in Dark Notepad
<br />
When using Dark Notepad you can change the header and footer of a document. <br />
Commands in the header and footer can be used to give your document a title and more! <br />
These settings can't be saved, so all header and footer settings must be entered menually each time <br />
you want to print a document. <br />
<br />

## To change headers and footers
Choose `Page Setup` in the `File` dropdown and enter the desired command(s) in the Header and <br />
Footer text fields. Here's a list of all the available commands:

|Command|Action                                      |
|-------|--------------------------------------------|
|&l     |Align the following characters to the Left  |
|&c     |Align the following characters to the Center|
|&r     |Align the following characters to the Right |
|&d     |Print the current Date                      |
|&t     |Print the current Time                      |
|&f     |Print the Name of the document              |
|&p     |Print the Page Number                       |
<br />
If you leave the header and footer text fields empty, no header or fooer will print.

## Examples
### Regular
>Header: `Document Title` <br />
>Footer: `Lower text` <br />

This will print a header with 'Document Title' text on the center, <br />
aswell as a Footer with 'Lower text' text on the center. <br />
<br />

### Commands
>Header: `&l&d &c&f` <br />
>Footer: `&rPage &p` <br />

This will print a header with Date text on the left and File Name on the center, <br />
aswell as a Footer with a Page Number on the right. <br />
