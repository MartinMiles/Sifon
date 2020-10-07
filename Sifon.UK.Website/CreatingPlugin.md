# Creating a PowerShell plugin

A plugin is just a simple PowerShell script with a traditional `.PS1` file extension: as you got used to them. 
But what is indeed important to understand: each plugin executes in a context of a currently selected Profile, either running on a local machine or on remote computer by the means of PowerShell remoting. There is nothing extra for a developer to do (apart from accepting script parameters) - Sifon will care about the rest.

And of course due to that you can call these plugins scripts directly in the most cases. What sifon does for you on top of that is creating a context and taking care about parameters to be passed. This alone saves so much time, indeed!

As a simple example please take a look at the below one-liner, in fact a functional parameterless script. The only thing it does is outputting the computer host name: 

`"The current machine name is: $env:computername"`

Its output would vary, however, depending on the selected profile at Sifon:

![Output hostname plugin](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/Plugins/OutputHostname.png "Output hostname plugin") 

The easiest way to change a profile (if you got more than one of them) is by using a profile selector dropdown at the top-right area of a main Sifon screen. If you need to create a new one or modify existing, please use "Profiles" menu. Active profile is also shown at the main window header, so that user cat easily distinguish them and also identify if it's a local or remote one.


## Parameters

Of course, you would want your scripts to receive parameters from a current profile so that you can much more benefit from a one-click profile switching, rather than simply switch between local and remote profile, as shown above. Parameters are declared exactly that same as traditional PowerShell scripts do.

Example of a plugin script 'receiving' parameters:

``` 
param(
	[string]$Webroot,
    [string]$Website
)

Write-Output "Now enabling Live Mode for $Website website"
Write-Output "That means data will be read directly from the master database, thereby bypassing the need to publish"

$exampleConfig = "c:\Sitecore\platform.local\App_Config\Include\Examples\LiveMode.config.example"

If(Test-Path -Path $exampleConfig){
    Rename-Item -Path $exampleConfig -NewName "LiveMode.config"
    Write-Output "#COLOR:GREEN# Live mode successfully enabled"
}
else{
    Write-Warning "File missing at $exampleConfig - probably already working in Live mode"
}
```

What happens here is that Sifon executes a plugin passes it $Webroot and $Website parameters. Further down c finds a config file relative to a website root provided with `$Webroot` parameter and renames it. And of course, after selecting another profile from a dropdown this script will perform the same operation against another `$Website` relatively to its `$Webroot` folder.

Finally, below you can see what results upon plugin execution:

![Output hostname plugin](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/Plugins/LiveMode.png "Output hostname plugin") 



Some facts about parameters:
- each parameter receives value from a corresponding field from a selected profile
- you can declare only those parameters that your plugin will use
- you aren't limited by default profile parameters - you can create as many custom as you want



<br/>

## Meta information

Looking at some of existing plugins you may notice some of them starting with triple-hash characters ('###'). In PowerShell hash-character means comment, so the rest or the code right of it will be ignored. Sifon uses '###' signature for passing some of the useful meta-information to be consumed by a script or sifon itself.

Here are some of existing meta syntaxes:

`### Name: Plugin name as seen from a menu`

The line above is a way to provide a friendly name for your plugin to be seen under Plugins menus. If missing from your script, plugin will be shown under its filename instead.

`### Description: More verbose description that pops up with a tooltip when hovering mouse over a plugin in a menu`

Simile to the previous example, this one append additional user-friendly information or advise on a specific plugin, that is shown as tooltip on mouse over a menu item.

`### Compatibility: Sifon 0.98`

Currently not enforced, this will be a minimal version constraint for a plugin. If your Sifon version is lower that required by a plugin, it won't be seen under your plugins menu.

The reason behind give feature is that plugins are developed at and cloned from an individual GitHub repository. That bring us to a situation when a plugin in repository get updated with some features / API that were introduced in a newer Sifon, so it will prevent app from failure on breaking changes. Updating Sifon to the latest version plugin will re-appear.

`### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Sifon Package Installer for Sitecore","Pick up the package to install:","Archives|*.zip","Install")`

Finally, a bit complicated example of shared API usage. This gets explained in details at [API page](/API.md "API page").


<br/>

## Container plugins

Behave similarly, however everything from 'Container' folder is shown under Containers menu instead of 'Plugins', despite plugins coming from the same Github repository. This approach is taken for keeping related functionality together under the same logical groupings, rather than physical filesystem organization.

Apart from that difference Containers plugins are equal to others plugins.