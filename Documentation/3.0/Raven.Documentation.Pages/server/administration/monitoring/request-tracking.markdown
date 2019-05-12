# Monitoring: Request Tracking

It is possible to record and replay requests that are being received by RavenDB.

Monitoring is possible using the Raven.Traffic Tool, which can be found in [installDirectory]\Diag\Raven.Traffic 

{PANEL:**Recording Traffic**}

To record traffic, use this command:

{CODE-BLOCK:plain}
    Raven.Traffic rec http://localhost:8080/ Northwind outputFile.json
{CODE-BLOCK/}


### Customizing recording
The default recording behaviour is to record 1000 requests, for no longer then 60 seconds. In order to change this behavior, you can use the traceSeconds and\or traceRequests options.
{CODE-BLOCK:plain}
    Raven.Traffic rec out http://localhost:8080/ Northwind outputFile.json traceSeconds=10
{CODE-BLOCK/}						
or
{CODE-BLOCK:plain}
    Raven.Traffic rec out http://localhost:8080/ Northwind outputFile.json traceRequests=100
{CODE-BLOCK/}
or
{CODE-BLOCK:plain}
    Raven.Traffic rec out http://localhost:8080/ Northwind outputFile.json traceSeconds=180 traceRequests=5000
{CODE-BLOCK/}

{INFO:Information}
Other possible customizations allows compressing output, setting API keys etc. you can see it in the options section.
{INFO/}
{PANEL/}

{PANEL:**Replaying Traffic**}

In addition to recording traffic, it is possible to replay recorder traffic. In order to replay, use this command:

{CODE-BLOCK:plain}
    Raven.Traffic play http://localhost:8080/ Northwind outputFile.json
{CODE-BLOCK/}


{INFO:Information}
Unlike the recording, in replaying it is not possible to limit replay length or volume, instead, the whole file will be replayed. But it does allow you to set connection settings compressing output, setting API keys etc. you can see it in the options section.
{INFO/}
{PANEL/}


{PANEL:**Command line options**}

You can change the Raven.Traffic behavior using the config parameters below

 - --traceSeconds[=VALUE] : (In Record mode only) Requests recording max duration
 - --traceRequests[=VALUE] : (In Record mode only) Max amount of requests to record
 - --compressed              Work with compressed json outpu/input
 - --noOutput                Suppress console progress output
 - --timeout[=VALUE]         The timeout to use for requests(seconds)
 - -u, --user, --username[=VALUE] The username to use when the database requires the client to authenticate.
 - -p, --pass, --password[=VALUE] The password to use when the database requires the client to authenticate.
 - --domain[=VALUE]          The domain to use when the database requires the client to authenticate.
 - --key, --api-key, --apikey[=VALUE] The API-key to use, when using OAuth.
{PANEL/}



## Related articles

- [Studio : Management : Traffic Watch](../../../studio/management/traffic-watch)
