﻿# Building RavenDB from source

RavenDB requires .NET 4.0 SDK installed to build. You should be able to just open RavenDB in Visual Studio 2012 and start working with it immediately.

RavenDB uses PowerShell to execute its build process. Open a PowerShell prompt as a user with Administrator privileges, and execute:

	.\build.cmd

The following dependencies required by RavenDB code will be downloaded from NuGet:

* [Asymmetric RSA Encryption for Silverlight and WP7](https://www.nuget.org/packages/DH.Scrypt.dll/)
* [NLog](https://nlog-project.org/)
* [Reactive Extensions](https://archive.codeplex.com/?p=rx)
* [ICSharpCode.NRefactory](https://www.nuget.org/packages/ICSharpCode.NRefactory)
* [Mono.Cecil](https://www.nuget.org/packages/Mono.Cecil/)
* [Microsoft.Web.Infrastructure](https://www.nuget.org/packages/Microsoft.Web.Infrastructure/)
* [xUnit](https://github.com/xunit/xunit)
* [Nancy FX](http://nancyfx.org/)

Other dependencies you will find under _SharedLibs_ folder:

* AWS.Extensions
* AWSSDK
* Esent.Interop
* GeoAPI
* Lucene.Net
* NetTopologySuite
* Spatial4n.Core.NTS

Additionally to build it correctly you have to install:

* [Windows Installer XML (WiX)](http://wixtoolset.org/)
* [ASP.NET MVC 4](https://docs.microsoft.com/en-us/aspnet/mvc/mvc4)

The build process will, by default, execute all tests, which will take a while. You may skip the tests by executing:

    .\quick.ps1