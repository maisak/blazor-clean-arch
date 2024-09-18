#Requires -PSEdition Core
# Script-wide constants
$solutionFileName       = "BCA.sln"
####################################################################################################
# Finding root directory - $rootFolder #############################################################
####################################################################################################
$rootDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent;
do {
    $solutionFile = Get-ChildItem -Path $rootDir -Recurse -File | Where-Object { $_.Name -eq $solutionFileName }
    if ($null -ne $solutionFile) {
        $rootFolder = Split-Path -Path $solutionFile.FullName -Parent;
        break;
    }
    $rootDir = Split-Path -Path $rootDir -Parent;
} while ($true);
####################################################################################################
# Get all test projects in the solution directory that have 'UnitTests' in their name ##############
####################################################################################################
$testProjects = Get-ChildItem -Path $rootDir -Recurse -Filter *UnitTests*.csproj
$testProjects | ForEach-Object {
    $testProject = $_.FullName
    echo $testProject
    dotnet test $testProject
}