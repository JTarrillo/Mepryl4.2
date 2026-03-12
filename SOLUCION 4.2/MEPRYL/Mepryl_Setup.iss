#define MyAppName "Mepryl 4.4"
#define MyAppVersion "4.4.0.0"
#define MyAppPublisher "Mepryl"
#define MyAppExeName "MEPRYL.exe"
#define MyAppPath "C:\Mepryl4.2\SOLUCION 4.2\MEPRYL\Administracion\bin\Release"

[Setup]
AppId={{A91F3E2D-6B3F-4A5E-9B12-1C7E4F92D8AB}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}

AppPublisherURL=https://www.tuempresa.com
AppSupportURL=https://www.tuempresa.com/soporte
AppUpdatesURL=https://www.tuempresa.com/actualizaciones

DefaultDirName={commonpf}\{#MyAppName}
DefaultGroupName={#MyAppName}

UsePreviousGroup=False
DisableProgramGroupPage=no
AllowNoIcons=yes

OutputDir=C:\Mepryl4.2\SOLUCION 4.2\Instaladores
OutputBaseFilename=Mepryl_4.4_Setup

Compression=lzma
SolidCompression=yes

PrivilegesRequired=admin
WizardStyle=modern

UninstallDisplayIcon={app}\{#MyAppExeName}

SetupIconFile="{#MyAppPath}\Logo Definitivo.ico"

ChangesEnvironment=no

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Crear acceso directo en el escritorio"; Flags: unchecked

[Files]
; Archivo ejecutable principal
Source: "{#MyAppPath}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
; Archivo de configuración
Source: "{#MyAppPath}\MEPRYL.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; Todos los archivos DLL del release (incluye subcarpetas para DLLs de PDF de DevExpress y Spire)
Source: "{#MyAppPath}\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Archivos adicionales
Source: "{#MyAppPath}\Logo Definitivo.ico"; DestDir: "{app}"; DestName: "Logo Definitivo.ico"; Flags: ignoreversion
Source: "{#MyAppPath}\Config.xml"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
Source: "{#MyAppPath}\credentials.json"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Logo Definitivo.ico"
Name: "{group}\Desinstalar {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon; IconFilename: "{app}\Logo Definitivo.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Ejecutar {#MyAppName}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}\Reportes"
Type: filesandordirs; Name: "{app}\Lib"
Type: filesandordirs; Name: "{app}\*.log"
