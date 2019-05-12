# Configuration: Enabling SSL

{INFO SSL can only be enabled when RavenDB is running as a Windows Service. The certificate has to be installed in the local certificate repository [Certificates - Local Computer\Personal\Certificates] and include the private key (.pfx file), otherwise the following will not work. /}

By default, secure connectivity is disabled. To enable the SSL in RavenDB, you need to do the following:

1. change `Raven/UseSsl` configuration to `true`.  
2. tell RavenDB to use the specified X509 certificate. 

To tell RavenDB to use the specified X509 certificate, execute the following command on the command line:   

{CODE-BLOCK:plain}
Raven.Server.exe /installSSL=PathToCertificate==CertificatePassword
{CODE-BLOCK/}

E.g.   
{CODE-BLOCK:plain}
Raven.Server.exe /installSSL=C:\Temp\MyCertificate.pfx==MyPassword
{CODE-BLOCK/}

To uninstall the certificate execute:    

{CODE-BLOCK:plain}
Raven.Server.exe /uninstallSSL=PathToCertificate==CertificatePassword
{CODE-BLOCK/}

{NOTE The Studio might not work in some browsers (e.g. Firefox and Chrome) if the domain that certificate was issued for does not match the domain you are using it for. /}   

## Ignoring SSL errors

In RavenDB, we have added an option to ignore all SSL certificate validation errors. By default, `Raven/IgnoreSslCertificateErrors` configuration option is set to **None**, but it can be changed if needed.

{DANGER We do not recommend setting `Raven/IgnoreSslCertificateErrors` to **All** due to safety reasons. Enabling this option is done at your own risk. /}
