# Sifon Components Library

There are some components ready for to be used with Sifon from within a plugin script

<br/>

# LocalFilePicker

This component allow picking up a file on a local (to Sifon) filesystem and passes it further ahead. An file validation is optional prior to sending a selected file further ahead.


**Library:** `Sifon.Shared`

**Type with namespace:** `Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker`

![LocalFilePicker in action](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/Library/LocalFilePicker.png "LocalFilePicker in action")

## Properties:

| Name     |     Type   |  Example | Description |
|-----------|:-------------:|:-------|:------|
| Caption   |  string | "Sitecore license selector" | This property is shown at the header of a window |
| Label     |    string   |   "Select sitecore license to install:" |  A text of label above a text box |
| Filters | string | "Archives\|*.zip" |  The filtering message and mask to show only desired file types by an extension   |
| Button | string | "OK" | The button triggering form submission |
| Validation | delegate |   s => "Error message details to be shown" | An optional delegate that return empty string if validation passes OK, or error message |


<br/>

## Usage Examples

It could be used in 3 different ways:

### **1. From the PowerShell GUI:**
```
$form = new-object Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker
$form.StartPosition = [System.Windows.Forms.FormStartPosition]::CenterParent;

$form.Caption = "Sitecore license selector";
$form.Filters = "License files|*.xml";
$form.Label = "Select Sitecore license in order to install Horizon:";
$form.Button = "OK";

# Validation is optional, just uncomment below. Also the line below is a nice way of passing inline logic as a delegate into DLL without losing types:
# $form.Validation = { [Validation.FilePicker]::IsSitecoreLicense($args[0]) }

$result = $form.ShowDialog()

$licenseMessage = 
if ($result -ne [System.Windows.Forms.DialogResult]::OK -or [string]::IsNullOrEmpty($SelectedFile))
{
    Write-Output "Sitecore license required for Horizon installation"
    exit
}
# send the file to remote and do the rest of your tasks with a license file received
```

<br/>

### **2. From Meta-language:**

`### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Sifon Package Installer for Sitecore","Pick up the package to install:","Archives|*.zip","Install")`

<br/>

### **3. From .NET code:**

```
var filePicker = new LocalFilePicker();
filePicker.Caption = "";
filePicker.ShowDialog();
```


