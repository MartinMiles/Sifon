# Release notes

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