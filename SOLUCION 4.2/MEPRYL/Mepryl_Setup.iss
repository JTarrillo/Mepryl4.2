; Script de instalación para Mepryl - Versión 4.0
; Generado con InnoSetup Compiler 6.2.0

[Setup]
AppId={{3A1AF435-5DB7-473C-9322-F0560A360E7F}
AppName=Mepryl 4.0
AppVersion=4.0.0.0
AppPublisher=Tu Empresa
AppPublisherURL=https://www.tuempresa.com
AppSupportURL=https://www.tuempresa.com/soporte
AppUpdatesURL=https://www.tuempresa.com/actualizaciones
DefaultDirName={commonpf}\Mepryl 4.0
DefaultGroupName=Mepryl 4.0
DisableProgramGroupPage=no
AllowNoIcons=yes
LicenseFile=
InfoBeforeFile=
InfoAfterFile=
OutputDir=C:\Programador\SOLUCION 3.10\Instaladores
OutputBaseFilename=Mepryl_4.0_Setup
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
ChangesEnvironment=no
WizardStyle=modern
UninstallDisplayIcon={app}\Mepryl.exe
SetupIconFile="C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\Logo Definitivo.ico"
WizardImageFile=
WizardSmallImageFile=

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1,6.1

[Files]
; Archivo ejecutable principal
Source: "C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\MEPRYL.exe"; DestDir: "{app}"; Flags: ignoreversion
; Archivo de configuración
Source: "C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\MEPRYL.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; Todos los archivos DLL del release
Source: "C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
; Archivos adicionales
Source: "C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\Logo Definitivo.ico"; DestDir: "{app}"; DestName: "Logo Definitivo.ico"; Flags: ignoreversion
Source: "C:\Programador\SOLUCION 3.10\MEPRYL\Administracion\bin\Release\Config.xml"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist


[Icons]
Name: "{group}\Mepryl 4.0"; Filename: "{app}\Mepryl.exe"; IconFilename: "{app}\Logo Definitivo.ico"; IconIndex: 0
Name: "{group}\{cm:UninstallProgram,Mepryl 4.0}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Mepryl 4.0"; Filename: "{app}\Mepryl.exe"; IconFilename: "{app}\Logo Definitivo.ico"; IconIndex: 0
Name: "{commondesktop}\Mepryl 4.0 (Admin)"; Filename: "{app}\Mepryl.exe"; IconFilename: "{app}\Logo Definitivo.ico"; IconIndex: 0
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\Mepryl 4.0"; Filename: "{app}\Mepryl.exe"; Tasks: quicklaunchicon; IconIndex: 0

[Run]
Filename: "{app}\Mepryl.exe"; Description: "{cm:LaunchProgram,Mepryl}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\Reportes"
Type: filesandordirs; Name: "{app}\Lib"
Type: filesandordirs; Name: "{app}\*.log"
