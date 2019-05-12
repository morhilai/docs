# Configuration: Security

The following configuration values allow you to control the desired level of security in a RavenDB server. For a more detailed explanation, please visit the [Security Section](../security/overview).

{PANEL:Security.Certificate.Path}

The path to .pfx certificate file. If specified, RavenDB will use HTTPS/SSL for all network activities.   
Certificate setting priority order:   
1. Path   
2. Executable   

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Password}

The (optional) password of the .pfx certificate file.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec}

A command or executable providing a .pfx certificate file. If specified, RavenDB will use HTTPS/SSL for all network activities. The certificate path setting takes precedence over executable configuration option.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec.Arguments}

The command line arguments for the 'Security.Certificate.Exec' command or executable.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.Exec.TimeoutInSec}

The number of seconds to wait for the certificate executable to exit.

- **Type**: `int`
- **Default**: `30`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.Certificate.LetsEncrypt.Email}

The E-mail address associated with the Let's Encrypt certificate. Used for renewal requests.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Path}

The path of the (256-bit) Master Key. If specified, RavenDB will use this key to protect secrets.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec}

A command or executable to run which will provide a (256-bit) Master Key. If specified, RavenDB will use this key to protect secrets.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec.Arguments}

The command line arguments for the 'Security.MasterKey.Exec' command or executable. 

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.MasterKey.Exec.TimeoutInSec}

The number of seconds to wait for the Master Key executable to exit.

- **Type**: `int`
- **Default**: `30`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.UnsecuredAccessAllowed}

If authentication is disabled, set the address range type for which server access is unsecured (`None | Local | PrivateNetwork | PublicNetwork`).

- **Type**: `flags`
- **Default**: `Local`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.DoNotConsiderMemoryLockFailureAsCatastrophicError}

Determines whether RavenDB will consider memory lock error to be catastrophic. This is used with encrypted databases to ensure that temporary buffers are never written to disk and are locked to memory. Setting this to true is not recommended and should be done only after a proper security analysis has been performed.

- **Type**: `bool`
- **Default**: `false`
- **Scope**: Server-wide or per database

{WARNING Use with caution. /}

{PANEL/}

{PANEL:Security.DisableHttpsRedirection}

Disable automatic redirection when listening to HTTPS. By default, when using port 443, RavenDB redirects all incoming HTTP traffic on port 80 to HTTPS on port 443.

- **Type**: `bool`
- **Default**: `false`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.AuditLog.FolderPath}

The path to a folder where RavenDB will store the access audit logs.

- **Type**: `string`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.AuditLog.RetentionTimeInHrs or Security.AuditLog.RetentionTimeInHours}

How far back we should retain audit log entries.

- **Type**: `int`
- **Default**: `365 * 24`
- **Scope**: Server-wide only

{PANEL/}

{PANEL:Security.WellKnownCertificates.Admin}

Allows you to specify well known certificate thumbprints that will be trusted by the server as cluster admins.

- **Type**: `strings separated by ;`
- **Example**: `297430d6d2ce259772e4eccf97863a4dfe6b048c;e6a3b45b062d509b3382282d196efe97d5956ccb`
- **Default**: `null`
- **Scope**: Server-wide only

{PANEL/}
