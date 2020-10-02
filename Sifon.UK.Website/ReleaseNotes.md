# Release notes

Version **0.98**

- first basic option for containers with Sitecore 10.0 has added, including easy clone and setup, profile switching
- container scripts now show under Containers menu, rather than under Plugins - 
- container scripts added for: set up Hyper-V and containers support, pulling the code, building and running Sitecore in Docker
- some plugins and Sifon in general tested against the remote instance and numerous issies indentified and fixed
- many existing plugins adjusted, thus only working with the latest (0.98 or newer) version of Sifon
- minor bugs on running first time and initial configuration
- added meta code supports to plugins scripts to comply with remote execition where UI isn't available: 
    1. executing GUI user input and automatically pass it to either local or remote script with a variable of choice
    2. specifying dependencies for those plugins that aren't just one script file: associated diles are also copied to remote


Version **0.97**

- now supports and correctly handles instances installations outside of `inetpub\wwwroot` folder
- this is mostly stabilized release of all previous features, critically reviewed and corrected
- on a first run there is no default profile set up for you (previously is was: habitat), now truly new user experience
- improvements within external plugins; also a new plugin to install SPE 6.1.1 with Remoting enabled in one click
- now Sifon module has two functions for package installation: 
    1. `Install-SitecorePackage` - universal and slow, creating temporal page (to get into Context) with module installation logic
    2. `Install-SitecorePackageUsingRemoting` - new, reliable and fast, but requires SPE with Remoting enabled on target


Version **0.96**

- a PowerShell module for Sifon has introduced with commonly called functions
- now Sifon is aware of Horizon and Pushishing Service and carefully does backup, cleanup and restore for those
- new "Settings" menu with an option to add your Sitecore developer's credentials
- a feature to test credentials and store and pass them into a script already in an encrypted way
- now Sifon is capable of dowloading Sitecore resources in one clickfrom any script via a module function
- this module is auto-installed into a system PowerShell folder on the first run
- profile editor now also asks for Sitecore instance admin username and password
- folder rename: Core scripts now went under PowerShell/Core along with Module folder
- added more mute synthaxes for: warnings, errors and for muting nested progress streams that break yours
- plenty of minor bugfixes and improvements


Version **0.95**

- new plugin system allows one-click plugins pull and setup from public GitHub repository
- plugins folder has been renamed to address the above change
- shared API got new LocalFilePicker control
- scripts plugins output has reworked to better presentation, also eliminating whitespaces
- new output muting / unmuting synthax to suppress uncontrolled "output verbose abuse"


Version **0.94**

- now supports Sitecore 10.0 and Commerce 10.0
- improved system services operations for stability
- adjusted Commerce database identification due to 10.0 changes
- minor bugfixes done


Version **0.93**

- supported Sitecore versions selector now available from Shared API
- restore of SQL databases now occurs in "relocate" mode to avoid broken paths
- minor bugfixes in the profile editor

<br/><br/>
[<- Home](/ "Home")	

<hr>

<footer>
<p style="float:left; width: 20%;">
</p>
<p style="float:left; width: 60%; text-align:center;">Copyright &copy; <a href="https://blog.MartinMiles.net">Martin Miles</a>, 2020</p>
<p style="float:left; width: 20%;">
</p>
</footer>