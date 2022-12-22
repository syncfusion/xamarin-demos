function waitUntillInstallation {
    Write-Host "Function has been called"
    
    $installComplete = 0

while($installComplete -le 1) 
{
    Write-Host "Test"
    $msi = Get-Process msiexec -ErrorAction SilentlyContinue
    if ($msi) {
        Sleep(10)
    }
    else
    {
        $installComplete = 2
    }

}
}

#Create Software folder for download
New-Item -ItemType Directory -Force -Path C:/Software
& { (New-Object System.Net.WebClient).DownloadFile('https://r4---sn-i5uif5t-h55s.gvt1.com/edgedl/android/studio/install/2021.3.1.16/android-studio-2021.3.1.16-windows.exe', 'C:/Software/android-studio-2021.3.1.16-windows.exe') }
dir C:/Software
C:/Software/android-studio-2021.3.1.16-windows.exe /S
Sleep(100)

waitUntillInstallation

# SDK installation
& { (New-Object System.Net.WebClient).DownloadFile('https://www.syncfusion.com/downloads/support/directtrac/general/ze/android-29-271814436', 'C:/Software/android-29-271814436.zip') }

#Extract zip file
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::ExtractToDirectory('C:/Software/android-29-271814436.zip', 'C:\Program Files (x86)\Android\android-sdk\platforms')

waitUntillInstallation