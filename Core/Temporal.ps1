$pass = ConvertTo-SecureString -AsPlainText '321' -Force
                    $Cred = New-Object System.Management.Automation.PSCredential -ArgumentList 'Martin',$pass
                    $Session = New-PSSession -ComputerName 192.168.173.14 -Credential $Cred
                    $remotePath = Invoke-Command -Session $session -ScriptBlock {  New-Item -ItemType Directory -Force -Path Sifon }
                    Copy-Item -Path C:\RssbPlatform.Installer\Core\Get-SitecoreSites.ps1 -Destination $remotePath.FullName -ToSession $session
                    Write-Output "$remotePath\Get-SitecoreSites.ps1"
                    Remove-PSSession $Session