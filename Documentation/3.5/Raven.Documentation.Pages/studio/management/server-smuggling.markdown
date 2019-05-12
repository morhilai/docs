# Manage Your Server: Server Smuggling
This feature is meant primarily for users that work with multiple instances of RavenDB. 
The common scenario is in production/staging/development where you need to move data between databases. 
Previously, you had to manually move the data using import or export.   
To setup data migration you need to supply the destination server url and which databases to migrate. 
By default we use incremental option, so you can run this over time and only get the new stuff.
You can enable strip replication information and disable versioning bundle.

![Figure 1. Manage Your Server. Server Smuggling.](images/manage_your_server-server-smuggling-1.png)
