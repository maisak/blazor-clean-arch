# Script to determine paths to migrations folder and root folder
# Usage ./get-paths.ps1
#Requires -PSEdition Core
# Script-wide constants
$solutionFileName       = "BCA.sln"
$dataProjectFileName    = "BCA.Infrastructure.csproj"
$startupProjectFileName = "BCA.Web.csproj"
$migrationsFolderName   = "Migrations"
$dbContextName          = "ApplicationDbContext"
####################################################################################################
# Finding root directory - $rootFolder #############################################################
####################################################################################################
$currentDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
do {
	$solutionFile = Get-ChildItem -Path $currentDir -Recurse -File | Where-Object { $_.Name -eq $solutionFileName }
	if ($null -ne $solutionFile) {
		$rootFolder = Split-Path -Path $solutionFile.FullName -Parent;
		break;
	}
	$currentDir = Split-Path -Path $currentDir -Parent;
} while ($true);
####################################################################################################
$dataProjectPath    = Get-ChildItem -Path $rootFolder -Recurse -File | Where-Object { $_.Name -eq $dataProjectFileName  }
$startupProjectPath = Get-ChildItem -Path $rootFolder -Recurse -File | Where-Object { $_.Name -eq $startupProjectFileName  }
$migrationsPath     = Get-ChildItem -Path $rootFolder -Recurse -Directory | Where-Object { $_.Name -eq $migrationsFolderName };
####################################################################################################
return New-Object PSObject -Property @{
    Root = $rootFolder
    DataProject = $dataProjectPath.FullName
    StartupProject = $startupProjectPath.FullName
    Migrations = $migrationsPath.FullName
	Context = $dbContextName
}