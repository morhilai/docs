# Authorization: Security Clearance and Permissions

X.509 certificates are used for authentication - validating that users are who they say they are. Once a connection is authenticated, RavenDB uses the certificate for authorization as well. 

Each certificate is associated with a security clearance and access permissions per database.

It is the administrator's responsibility to generate client certificates and assign permissions. Read more in the [Certificate Management](../authentication/certificate-management) section.

A client certificate's security clearance can be one of the following:

{PANEL:Cluster Admin}

`Cluster Admin` is the highest security clearance. There are no restrictions. A `Cluster Admin` certificate has admin permissions to all databases. It also has the ability to modify the cluster itself.

{NOTE The server certificate security clearance is called `Cluster Node`. The server certificate can also be used as a client certificate, and in that case `Cluster Node` is equivalent to `Cluster Admin` in terms of permissions. /}

The following operations are allowed **only** for `Cluster Admin` certificates:

- All cluster operations
- Manage `Cluster Admin` certificates
- Replace and renew server certificates
- Use the Admin JS Console
- Migrate databases
- Activate or update the license
- Get SNMP used OIDs

{PANEL/}

{PANEL:Operator}

A client certificate with an `Operator` security clearance has admin access to all databases, but is unable to modify the cluster. It cannot perform operations such as add/remove/promote/demote nodes from the cluster. This is useful in a hosted solution. If you are running on your own machines, you'll typically ignore that level in favor of `Cluster Admin` or `User`.

The following operations are allowed for **both** `Operator` and `Cluster Admin` certificates and are not allowed for `User` certificates:

- Operations on databases (put, delete, enable, disable)
- Manage `Operator` and `User` certificates
- Enable and disable an ongoing task
- Define External Replication
- Create and delete RavenDB ETL and SQL ETL
- View cluster observer logs
- View admin logs
- Gather local and cluster debug info (process, memory, cpu, threads) 
- Use smuggler
- Use the traffic watch
- Put cluster-wide client configuration (Max number of requests per session, Read balance behavior)
- Get the database record
- Manage database groups in the cluster
- Restore databases from backup
- Perform database and index compaction
- Get server metrics (request/sec, indexed/sec, batch size, etc...)
- Get remote server build info

{PANEL/}

{PANEL:User}

A `User` client certificate has a list of databases it is allowed to access. In addition, the access level to each database can be either `Database Admin` or `read/write`. A `User` certificate cannot perform any admin operations at the cluster level.

The following operations are allowed for `User` certificates with `Database Admin` access level and not allowed for `User` certificates with `read/write` access level:

- Operations on indexes (put, delete, start, stop, enable and disable)
- Solve replication conflicts
- Configure revisions and delete revision documents
- Define expiration
- Create backups and define periodic backups
- Operations on connection strings (put, get, delete)
- Put client configuration for the database (Max number of requests per session, Read balance behavior)
- Get transaction info
- Perform SQL migration (coming soon)

A `User` certificate with `read/write` access level can perform all the operations which are not listed above.  

{PANEL/}

## Related articles

### Security

- [Overview](../../../server/security/authorization/security-clearance-and-permissions)
- [Common Errors and FAQ](../../../server/security/common-errors-and-faq)
