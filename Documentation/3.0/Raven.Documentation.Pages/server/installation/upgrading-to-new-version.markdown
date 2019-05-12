# Installation: Upgrading to a new version

{INFO On a live system, a minor version upgrade process typically takes 30 seconds. /}

## Manually

Manual upgrade of RavenDB instance to a new version is very simple. In order to do so, you:

0. Download distribution package from [here](https://ravendb.net/download).
1. Shutdown the RavenDB server (this depends on your deployment strategy. For a service - shutdown the service. For a IIS site - shutdown the IIS site).
2. Remove old RavenDB binaries. Make sure not to delete your actual data which is in the folders like `Data` and not to overwrite your configuration files like `Raven.Server.exe.config` or `web.config`.
3. Copy new binaries 
4. Start the server again.

## Using installer

The RavenDB installer supports upgrades. The previously used settings (like a service name or an installation path) will be recovered by the wizard. The installation process first will automatically remove the old version and then install a new one.

## High availability

If you want a zero downtime, you can setup a failover server which will handle requests until the primary server is started up. The steps to do so are as follows:

1. Setup a replication between the primary and secondary server.
2. Wait until the second node will get all the docs from the primary node (for 10 minutes minimum, in order to make sure that any clients had a chance to get updated with the new replication information).
3. Shutdown primary server (clients will now silently failover to the secondary server).
4. Remove old RavenDB binaries. Make sure to not delete your actual data which is in folders like `Data`, or overwrite your configuration files like `Raven.Server.exe.config` or `web.config`.
5. Copy new binaries
6. Start primary server again.
7. Shutdown and update the secondary server.

## Upgrading data files

You don't have to do anything when you upgrade RavenDB to migrate the stored data. However, sometimes our adjustments require changing the file format. RavenDB includes support for performing of those kind of migrations automatically on startup if it finds that the stored database is using an old format.

{WARNING Data file migrations are only one way. If you want to move backward and any changes in the file format have occurred, RavenDB will fail to start (with a detailed error message). You can move data between different versions using the import/export tool, which works across all versions of RavenDB. /}

# Remarks

{INFO:Information}

- If you have secondary node running **only** for the duration of the actual update, you **don't need a license**.
- If you have secondary node running **constantly** (hot backup), you do **need a license**.

{INFO/}

{INFO:Major version upgrade}

In case of a major version upgrade (like 2.5 to 3.0) you need to validate the previous configuration before applying the upgrade. You will have better
replace the old configuration file with a new one having options adjusted to the current version.

{INFO/}

## Related articles

- [Client API : Backward compatibility](../../client-api/faq/backward-compatibility)
