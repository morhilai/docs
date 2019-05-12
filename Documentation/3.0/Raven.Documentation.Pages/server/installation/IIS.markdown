# Installation: Running as an IIS application

RavenDB can be run as an IIS application, or from a virtual directory under an IIS application.

## Setting up a RavenDB IIS application

1. [Download the distribution zip](https://ravendb.net/download) and extract the "Web" folder.
2. In the IIS Manager, create a new website and point its physical path to the `"/Web"` folder you extracted. Alternatively, point a virtual directory under an existing website to that folder.
3. Set the Application Pool for the IIS application you will be using to "ASP.Net v4.0", or create a new Application Pool set to .NET 4.0 Integrated Pipeline.
4. Set port and host if needed.
5. Make sure that the user you set for the website has write access to the physical database location.
6. Make sure to disable the "Overlapped Recycle" in the App Pool Advanced Settings.  (Otherwise, you may have two concurrent RavenDB instances competing for the same data directory, which is going to generate failures).

## Setting up with IIS 7.5 and 8.0

* Remove the WebDAVModule from the installed Modules on your IIS server
* If you wish to run RavenDB with authentication:
    * Ensure that IIS "Windows Authentication" security module is installed (by default it is not). This can be checked under `Programs and Features` > `Turn Windows features on or off` > `Internet Information Services` > `World Wide Web Services` > `Security`.
    * Enable "Windows Authentication" for the RavenDB website.
    * In the web.config file, set the app settings value `Raven/AnonymousUserAccessMode` to Get or None
* If you wish to run with no authentication:
    * In the web.config file, set the app settings value `Raven/AnonymousUserAccessMode` to All

## Setting up with IIS 7

You may get a "405 Method Not Allowed" error when trying to create an index from the Client API when RavenDB is running in IIS 7.

This usually happens when you are running RavenDB from a virtual directory. The problem is a conflict that occurs with the WebDAV module. To resolve that, you need to edit the web.config file in the parent directory and add:

{CODE-BLOCK:xml}
<system.webServer>
   <modules runAllManagedModulesForAllRequests="true">
      <remove name="WebDAVModule" />
   </modules>
 </system.webServer>
{CODE-BLOCK/}
 
That will remove the WebDAV module and resolve the conflict.

{NOTE This modification is not to the RavenDB's web.config file, it is to the web.config of the parent application. /}

## Setting up with IIS 6

When using IIS 6, you need to make sure all requests are mapped to the ASP.NET DLL, modify the Web.config file, and remove the `system.webServer` element and add the following system.web element:

{CODE-BLOCK:xml}
<system.web>
   <httpHandlers>
      <add path="*" verb="*" 
         type="Raven.Web.ForwardToRavenRespondersFactory, Raven.Web"/>
   </httpHandlers>
</system.web>
{CODE-BLOCK/}

If you are experiencing problems with accessing the Studio, try this path: Home Directory > Configuration > Wildcard application maps > Insert
c:\windows\microsoft.net\framework\v4.0.30319\aspnet_isapi.dll, and Uncheck Verify file exists.

## Web Configuration

Many configuration options are available for tuning RavenDB and fitting it to your needs. See the [Configuration options](https://ravendb.net/docs/server/administration/configuration) page for the complete info.

## Recommended IIS Configuration

RavenDB isn't a typical website because it needs to be running at all times. In IIS 7.5, you can set this using the following configuration settings:

* If you created a dedicated application pool for RavenDB, change the application pool configuration in the application host file (C:\Windows\System32\inetsrv\config\applicationHost.config) to:

{CODE-BLOCK:xml}
       <add name="RavenApplicationPool" managedRuntimeVersion="v4.0" startMode="AlwaysRunning" />
{CODE-BLOCK/}

* If Raven runs in an application pool with other sites, modify the application host file (C:\Windows\System32\inetsrv\config\applicationHost.config) to: 

{CODE-BLOCK:xml}
       <application path="/Raven" serviceAutoStartEnabled="true" />
{CODE-BLOCK/}

{INFO:Remember}

If `startMode` is set to `AlwaysRunning` for proper IIS behavior the _Application Initialization Module_ needs to be installed on IIS.

{INFO/}

## HTTP Error 503

You may hit an HTTP Error 503 - "The service is unavailable" - when deploying to IIS, with nothing written to the Event Log.

This problem usually occurs when you are trying to run the RavenDB's IIS site on port 8080 after you have run RavenDB in executable mode. The problem stems from RavenDB reserving the `http://+:8080/` namespace for your user, and when IIS attempts to start a site on the same endpoint, error occurs.

You can resolve this problem by executing the following on the command line:

    netsh http delete urlacl http://+:8080/

You can also see all existing registrations with the following command:

    ntsh http show urlacl

## IISReset

Another issue that is worth mentioning is a IISReset problem. By default it gives the IIS server 20 seconds to restart, 60 seconds to stop and 0s to reboot, after that period of time it aborts the thread of the application by using `Thread.Abort()` (in context of a RavenDB it means that we will have to run recovery process next time we start, so it will take even `longer`). In most cases there should be enough time, but when we consider a multi-tenancy feature and possibility of a database recovery process, then the available time might be insufficient.

To handle the problematic IIS behavior we have redesigned the RavenDB startup process to handle `Thread.Abort()` more robustly and moved the DB initialization process to a separate, non-dependent by IIS process. More details about the issue and our solution can be found [here](https://ayende.com/blog/158817/things-we-learned-from-production-part-iindash-wake-up-or-i-kill-you-dead).

Our current implementation, due to limitations in IIS, does not cover WebSite restart scenario when long-running requests are in progress and might cause file access errors. When this problem occurs, the only solution is to **restart** the **IIS** server.

## IIS Application Request Routing (IIS ARR)

It has been confirmed that caching on RavenDB Server Farm causes unexpected errors and should be disabled for proper operation.

## IIS + Encryption

When encryption bundle is activated the `CryptographicException` can occur with following message: "**The data protection operation was unsuccessful. This may have been caused by not having the user profile loaded for the current thread's user context, which may be the case when the thread is impersonating.**". To resolve this issue, on IIS 7 and later, user profile of the application pool identity must be loaded.

## References

Microsoft KB article about ASP.NET Partial Trust and application isolation - [https://support.microsoft.com/en-us/help/2698981/asp-net-partial-trust-does-not-guarantee-application-isolation](https://support.microsoft.com/en-us/help/2698981/asp-net-partial-trust-does-not-guarantee-application-isolation)

## Related articles

 - [Using installer](./using-installer)
