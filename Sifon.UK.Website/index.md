# Sifon 

A must-have tool for any Sitecore developer, to simplify most of your day-to-day DevOps activities

![Sifon](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/main.png "Sifon main interface") 


<br/>

## Downloads

Use this link to [download](/download/Sifon_0.98.zip "download Sifon") your copy of Sifon. The source code is available at [GitHub](https://github.com/MartinMiles/Sifon "Sifon GitHub repository").


<br/>

## Features

- functions with Sitecore versions 9.x and 10.0
- backup, clean, restore selected Sitecore instance out-of-the-box with nice GUI
- you can choose the above operations for webroot, xConnect, Identity Server, Horizon and Publishing Service sites (or them all)
- support Sitecore Commerce of both 9.x and 10.x versions
- basic support for Sitecore in containers with Docker
- supports and correctly handles instances installations outside `inetpub\wwwroot` folder
- environment auto-detection: hostnames, bindings, installed Solr instances
- supports multiple instances on a host via creating and selecting profiles
- all the above can be done on remote VM via WinRM (WsMan) with remote profile
- supports plugins both written in PowerShell or compiled .NET libraries
- plugins can use API for downloading and consuming resources from Sitecore Developers Portal
- plugins are kept in hierarchical order and, in fact, may be crowdsourced
- respects Windows services: marketing automation, xConnect search indexer, processing engine and of course IIS

<br/>

## Getting started

Please take a look at this video before the first run, as it explains important bits, such as setting up a profile on the first run and what Profiles are. It also show you hpw to obtain the lates collection of plugins from a [public GitHib plugins repository](https://github.com/MartinMiles/Sifon.Plugins "public GitHib plugins repository"), how to configure containers for the first run of Sitecore 10 XP0 and also how to perform local and remote backups.

<p><iframe width="800" height="450" src="https://www.youtube.com/embed/rjF2yeLu5Yc?feature=oembed" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe></p>

Here you may find even more [quick start videos and instructions](/QuickStart.md "quick start videos and instructions")

<br/>

## Documentation

Please go through the documentation in order to get the max from using Sifon

- [Quick start guide](/QuickStart.md "Quick start guide")
- [Plugins library](/PluginsLibrary.md "Plugins library")
- [Creating a PowerShell plugins](/CreatingPlugin.md "Creating a PowerShell plugins")
- Creating .NET compiled DLL plugins
- Using Shared API
- [Release notes](/ReleaseNotes.md "Release notes")
- [Known issues](/KnownIssues.md "Known issues")

<br/>

## Impressive features to arrive later

- abilty to build own solutions images with Docker
- mass content migration utility between environments
- restore Sitecore from backup into another clean machine


<br/>

## License

Sifon is distributed free of charge under [GNU General Public License v3 (GPL-3)](https://www.gnu.org/licenses/gpl-3.0.en.html "GNU General Public License v3 (GPL-3)") license

<hr>

<footer>
<p style="float:left; width: 20%;">
</p>
<p style="float:left; width: 60%; text-align:center;">Copyright &copy; <a href="https://blog.MartinMiles.net">Martin Miles</a>, 2020</p>
<p style="float:left; width: 20%;">
</p>
</footer>