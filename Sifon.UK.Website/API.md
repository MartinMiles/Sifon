# Shared Forms API

From time to time you may want to benefit from using existing user control just immediately from your plugin. You have several option for doing that:

- write the form inline with PowerShell GUI
- create a form in Visual Studio in a seperate DLL

With Sifon you may of course do either of the above, but the fact to consider is that both will exucute for local profile only. When running a remote profile, Sifon copies your script to a remote machine and  genuinely executes it in the context of a remote machine and by means of that remote machine. It only intercepts several output streams from a remote machime, such as Output, Warning, Progress and Error which leaves us without any way to interact with GUI done with Winforms.


<br/>

## Sample plugin requirements

However, some limited options of creating **universal plugin** with GUI input still exist. By saying iniversal it meant a plugin will function regardless of if the profile is local or remote. You as developer should always try to creating universal plugins, unless you are not sharing your scripts and working locally only. Let's assume the following plugin requirements exist:

- the plugin requires user picking and providing Sitecore license 
- you want user to pick up the license file with GUI filepicker
- plugin must execute on both local and remote machine, depending on a context of selected profile
- licence file picker operates on a local machines always and cares about copying license to a remote host (for remote profiles)

[Sifon Controls Library](/Library.md "Sifon Controls Library") already has a suitable control for us - **LocalFilePicker**. And that's how it looks in action:

![LocalFilePicker in action](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/API/LicenseSelector.png "LocalFilePicker in action") 


<br/>

## Sample plugin implementation - local only

If there wasn't a requrement for a plugin to exetute remotely, the solution would be as simple as that:

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
The above code forks pretty well and it will instantiate a new popup window of `LocalFilePicker` over Sifon in order to select a file from your computer and pass the resulted file full path further into a plugin script. The above approach is called PowerShell GUI and since you can use any of .NET code from your scripts - that remains valid also or Windows Forms.

Unfortunately if the above code is run in a context of a remote machine, Sifon that runs locally won't be able to show you these forms as the whole script been copied and gets executed entirely at the remote machine by WinRM protocol. So we need to find a walkaround to a given scenario


<br/>

## Using meta-languauge

And that is exact point where script meta-synthax comes into a play. Let's take a look at the working solution below, followed by an explanation on how it works:

```
### Name: Install Horizon for Sitecore 10.0
### Description: Installs Sitecore JSS along with CLI
### Compatibility: Sifon 0.98
### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Sitecore license selector","Select Sitecore license in order to install Horizon:","License files|*.xml","OK")

param(
    [string]$Webroot,
    [string]$Website,
    [string]$Prefix,
    $SelectedFile
)

If(!(Test-Path -Path $SelectedFile))
{
    Write-Error "File $SelectedFile does not exist on you local machine"
    exit
}   
```
Please pay attention to the line number 4. Everything starting with `#` is ignored by PowerShell as being a comment, so it is a good opportunity to tell Sifon some necessary additional information, mandatory for a plugin to function. We do that by starting such lines with `###` block and passing Sifon necessary instruction.

In the above example we pass a line that looks very similar to a PowerShell code:
```
### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Sitecore license selector","Select Sitecore license in order to install Horizon:","License files|*.xml","OK")
```
What happens under the bonnet is Sifon finding such meta-synthax instructions executes them in a local context prior to running a script that could be run a remote context. In this example, it instantiates a LocalFilePicker form and calls its method `GetFile()` pasing all the required parameters. This is same class as shown in a previous PowerShell GUI example, that draws you a file selector form. 

Once file get selected, it is being assigned to an input parameter `$SelectedFile` as declared. Please pay attention to the following:

- parameter `$SelectedFile` is below accepted as an income parameter to a script
- this parameter is not part of profile, but being added and assigned from the above meta-synthax line
- script may be executed in a remote machine context
- for remote scripts selected file is automatically copied to a target machine and resulted remote file path automatically assigned to a variable
- this path on remote machine will be likely different, as you local file is copeid into Sifon working folder at the remote

So, to sum up - you as a script developer need to do nothing else but:

1. using one-liner as above, declare a variable and assign it with an output from a locally-running (not mandatory) GUI code or whatever you need
2. receive same variable within `param(...)` block and use it in you locally and remotely running script.

No need to mes up with establishing remote connection and copying the selected file there - Sifon will do it all for you and will assign your declared variable with a correct path!

