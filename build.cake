#tool nuget:?package=NUnit.ConsoleRunner&version=3.14.0
#addin nuget:?package=Cake.FileHelpers&version=4.0.1

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var appversion = Argument("appversion", "0.22.0.0");

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var distfile64 = $"simple-video-cutter.zip";


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
      
    if (FileExists(distfile64))
    {
        DeleteFile(distfile64);
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
});

Task("CreateDist")
    .IsDependentOn("Build")
    .Does(() =>
{
    Zip($"./src/SimpleVideoCutter/bin/x64/{configuration}", distfile64);
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
