# Sifon [![Build Status](https://travis-ci.org/MartinMiles/Sifon.svg?branch=master)](https://travis-ci.org/MartinMiles/Sifon)

A must-have tool for any Sitecore developer, to simplify most of your day-to-day DevOps activities.

![Sifon](https://raw.githubusercontent.com/wiki/MartinMiles/Sifon/img/main.png "Sifon main interface") 


## Features

- backup, clean, restore selected Sitecore instance out-of-the-box with nice GUI
- supports Sitecore XP and XC versions 9.x and 10.0
- you can choose the above operations for webroot, xConnect, Identity Server sites and all together
- environment auto-detection: hostnames, bindings, installed Solr instances
- supports multiple instances on a host via creating and selecting profiles
- all the above can be done on remote VM via WinRM (WsMan) with remote profile
- supports plugins both written in PowerShell or compiled .NET libraries
- plugins are kept in hierarchical order and, in fact, are crowdsourced
- respects Windows services: marketing automation, xConnect search indexer, processing engine and of course IIS


## Downloads and documentation

The easiest way to install **Sifon** is using Chocolatey:

`cinst sifon`

You may also download Sifon from the [project website](http://sifon.uk "Sifon's Homepage").


## License

Sifon is distributed free of charge under [GNU General Public License v3 (GPL-3)](https://www.gnu.org/licenses/gpl-3.0.en.html "GNU General Public License v3 (GPL-3)") license.
