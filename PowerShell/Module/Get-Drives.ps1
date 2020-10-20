function Get-Drives(){
    return [system.IO.DriveInfo]::GetDrives()
}