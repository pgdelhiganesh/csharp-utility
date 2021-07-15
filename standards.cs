C# Coding Standards and Naming Conventions
------------------------------------------
Object Name			Notation	Length	Plural	Prefix	Suffix	Abbreviation	Char Mask	Underscores
Class name			PascalCase	128		No		No		Yes		No				[A-z][0-9]		No
Constructor name	PascalCase	128		No		No		Yes		No				[A-z][0-9]		No
Method name			PascalCase	128		Yes		No		No		No				[A-z][0-9]		No
Method arguments	camelCase	128		Yes		No		No		Yes				[A-z][0-9]		No
Local variables		camelCase	50		Yes		No		No		Yes				[A-z][0-9]		No
Constants name		PascalCase	50		No		No		No		No				[A-z][0-9]		No
Field name			camelCase	50		Yes		No		No		Yes				[A-z][0-9]		Yes
Properties name		PascalCase	50		Yes		No		No		Yes				[A-z][0-9]		No
Delegate name		PascalCase	128		No		No		Yes		Yes				[A-z]			No
Enum type name		PascalCase	128		Yes		No		No		No				[A-z]			No


> Camel Case (camelCase): In this standard, the first letter of the word always in small letter and after that each word starts with a capital letter.
> Pascal Case (PascalCase): In this the first letter of every word is in capital letter.
> Underscore Prefix (_underScore): For underscore ( __ ), the word after _ use camelCase terminology.

 
Standard Abbreviation for Standard Controls.
-------------------------------------------
Abbreviations	Standard Control
-------------   ----------------
Btn	            Button
Chbx	        CheckBox
ChbxLi	        CheckBoxList
Cb	            DropDownList/Combo Box
FU	            FileUpload
Hdn	            HiddenField
Hlk	            Hyperlink
Img	            Image
Lbl	            Label
Lbtn	        LinkButton
mv	            MultiView
Panel	        Panel
Tb	            TextBox
Rbtn	        RadioButton
DGV	            DataGridView
FrmView	        FormView



-------------------------------------------
Kind			Rule
-------------   ----------------
Private Field	_lowerCamerlCase
Public Field	UpperCamerlCase
Protected Field	UpperCamerlCase
Internal Field	UpperCamerlCase
Property		UpperCamerlCase
Method			UpperCamerlCase
Class			UpperCamerlCase
Interface		IUpperCamerlCase
Local Variable	lowerCamerlCase
Paameter		lowerCamerlCase
