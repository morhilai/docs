# Installation: Upgrading to a New Version

{INFO On a live system, a minor version upgrade process typically takes around 30 seconds. /}

## Upgrading

Upgrading a RavenDB instance to a new version is very simple. In order to do so, you need to:

1. Download distribution package from [here](https://ravendb.net/downloads).

2. Shutdown the RavenDB server
    * for service (or daemon) - shutdown before upgrading
    * for console application - execute 'shutdown' command in the RavenDB CLI

3. Remove old RavenDB binaries
    * make sure to _not_ delete your actual data which is in the folders like `RavenData` and _not_ to overwrite your configuration files like [settings.json](../../server/configuration/configuration-options#json). 
    * make sure not to delete your certificate file which ends with `.pfx` or `.pem`, for more details see our [certificate page](../../server/security/authentication/certificate-configuration). 

4. Copy new binaries. 

5. Start the server again.

## High Availability & Cluster

If you want a zero downtime, please upgrade a single cluster node at a time and wait until it becomes a fully fledged node (either Member, Leader or Watcher). The state of the node can be checked in [Cluster View](../../studio/server/cluster/cluster-view).

## Upgrading Data Files

You don't have to do anything when you upgrade RavenDB to migrate the stored data. However, sometimes our adjustments require changing the file format (called schema version). RavenDB includes support for performing of those kind of migrations automatically on startup if it finds that the stored database is using an old format.

{WARNING Data file migrations are only one way. If you want to move backward and any changes in the file format have occurred, RavenDB will fail to start (with a detailed error message). You can move data between different versions using the import/export tool, which works across all versions of RavenDB. /}

## Remarks

{INFO:Major version upgrade}

RavenDB 4.x does not support automatic upgrading from previous major versions of the product (e.g. 3.5).  

Please read our [migration article](../../migration/server/data-migration) that describes in detail possible data and client migration strategies.

{INFO/}

## Related Articles

### Installation

- [System Requirements](../../start/installation/system-requirements)
- [System Configuration Recommendations](../../start/installation/system-configuration-recommendations)
- [Deployment Considerations](../../start/installation/deployment-considerations)

### Client API

- [Backward Compatibility](../../client-api/faq/backward-compatibility)
