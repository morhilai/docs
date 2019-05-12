# Troubleshooting: Running in Debug mode

Raven can be deployed in several ways, but the easiest method is to simply start the server located in the release zip under "/Server/Raven.Server.exe"
That will start the server as a console application, which displays the server log.
The server logs all requests, including status and duration. You can use that to get an idea  about how fast Raven really is.

* Close the server by hitting Enter on the console.
* If you want to clear the log and keep the server running, you can type "cls" and then press enter.

## Debug Configuration

You can set the following configuration options in the Raven.Server.exe.config file's appSettings section:

* Raven/DataDir - The physical location for the Raven data directory.
* Raven/AnonymousAccess - What access rights anonymous users have. The default is Get (anonymous users can only read data). The other options are None and All.
* Raven/Port - The port that Raven will listen to. The default is 8080.
* Raven/VirtualDirectory - The virtual directory that Raven will listen to. The default is empty.
* Raven/PluginsDirectory - The plugin directory for extending Raven. The default is a directory named "Plugins" under Raven base directory.
* Raven/MaxPageSize - The maximum number of results a Raven query can return (overrides any page size set by the client). The default is 1024.

Running in this configuration is useful when you want simply to try things out. For the production permanent deployment, it is recommended to use the Service or IIS modes.
