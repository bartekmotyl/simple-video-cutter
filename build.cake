#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.FileHelpers"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var appversion = Argument("appversion", "0.1.0.0");

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var distfile64 = $"simple-video-cutter-x64-{appversion}.zip";
var distfile86 = $"simple-video-cutter-x86-{appversion}.zip";


//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./src/SimpleVideoCutter/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    MSBuild("./src/SimpleVideoCutter.sln", settings =>
      settings.SetConfiguration(configuration).SetPlatformTarget(PlatformTarget.x64).WithTarget("Clean"));
    MSBuild("./src/SimpleVideoCutter.sln", settings =>
      settings.SetConfiguration(configuration).SetPlatformTarget(PlatformTarget.x86).WithTarget("Clean"));
      
    if (FileExists(distfile64))
    {
        DeleteFile(distfile64);
    }
    if (FileExists(distfile86))
    {
        DeleteFile(distfile86);
    }
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./src/SimpleVideoCutter.sln");
});

Task("SetVersion")
   .Does(() => {
       ReplaceRegexInFiles("./src/SimpleVideoCutter/Properties/AssemblyInfo.cs", 
                           "(?<=AssemblyVersion\\(\")(.+?)(?=\"\\))", 
                           appversion);
       
       ReplaceRegexInFiles("./src/SimpleVideoCutter/Properties/AssemblyInfo.cs", 
                           "(?<=AssemblyFileVersion\\(\")(.+?)(?=\"\\))", 
                           appversion);
   });


Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("SetVersion")
    .Does(() =>
{
    MSBuild("./src/SimpleVideoCutter.sln", settings =>
      settings.SetPlatformTarget(PlatformTarget.x64).SetConfiguration(configuration));
    MSBuild("./src/SimpleVideoCutter.sln", settings =>
      settings.SetPlatformTarget(PlatformTarget.x86).SetConfiguration(configuration));
});

Task("CreateDist")
    .IsDependentOn("Build")
    .Does(() =>
{
    Zip($"./src/SimpleVideoCutter/bin/x64/{configuration}", distfile64);
    Zip($"./src/SimpleVideoCutter/bin/x86/{configuration}", distfile86);
});




//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("CreateDist");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
