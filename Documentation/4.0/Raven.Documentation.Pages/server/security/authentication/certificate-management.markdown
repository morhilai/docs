# Authentication: Certificate Management

Once authentication is set up, it's the administrator's responsibility to issue and manage client certificates.

RavenDB provides a certificates management view in the studio. All the operations which are described below are also available in the client API. 
Click [here](client-certificate-usage) for detailed client examples.

![Figure 1. Certificates View](images/main.png)

Client certificates are managed by RavenDB directly and not through any PKI infrastructure. If you want to remove
or reduce the permissions on a certificate handed to a client, you can edit the permissions or remove them entirely from this screen.

It's important to note that RavenDB does __not__ keep track of the certificate's private key. Whether you generate a client certificate
via RavenDB or upload an existing client certificate, the private key is not retained. If a certificate was lost, you'll
need to recreate a new certificate, assign the same permissions, and distribute the certificate again.

{PANEL:The RavenDB Security Approach}

The security system in RavenDB does not assume any correlation between a particular certificate and a user. The concept of a user
does not really exist within RavenDB in this manner. Instead, you have a certificate that is assigned a set of permissions. 

In most cases, users do not access RavenDB directly. Aside from admins and developers during the development process, all access to 
the data inside RavenDB is expected to be done through your applications. A security mechanism on a per user basis is not meaningful.
The same application may need to access the same data on behalf of different users with different levels of access. In most systems, the access level
and operations allowed are never simple enough to be able to express them as an Access Control List, but are highly dependent on business rules and
processes, the state of the system, etc.

For example, in an HR system, an employee may request a vacation day, modify that request up until the point it is approved or declined, but the employee
is not permitted to approve their own vacations. The manager, on the other hand, may approve the vacation but cannot delete it after approval.
From the point of view of RavenDB, the act of editing a vacation request document or approving it looks very much the same, it's a simple document edit.
The way that the HR system looks at those operations is very different. 

RavenDB expects the applications and systems using it to utilize the security infrastructure it provides to prevent unauthorized access, such as a different
application trying to access the HR database. However, once access is granted, the access is complete. By design, RavenDB does not have the notion of a read-only
access to a database.

RavenDB security infrastructure operates at the level of the entire database. If you are granted access to a database, you can access
any and all documents in that database. There is no way to limit access to particular documents or collections.

It is common that this is something that you would need, exposing some part of the data or exposing read only access. If you need to provide direct access
to the database, the way it is usually handled is by generating a separate certificate for that purpose and granting it access to a _different_ database. In that case, set up an ETL process from the source data to the destination.

In this manner, you can choose exactly what is exposed, including redacting personal information, hiding details, etc. Because that ETL process is unidirectional, 
this also protects the source data from modifications made on the new database. Together, ETL and dedicated databases can be used for fine grained access, but that 
tends to be the exception, rather than the rule. 

In general, RavenDB assumes that an application will implement its own logic regarding what business operations are allowed, limiting 
itself to protecting the data from unauthorized access. Applications operate on behalf of users, and as such they are in a better position to determine what is
allowed than RavenDB. 

{PANEL/}

{PANEL:List of Registered Certificates} 

In the screenshot, we can see an example list of registered certificates. Each item contains the following information:

- Name
- Thumbprint
- Security Clearance
- Allowed databases
- Expiration date

![Figure 2. Registered Certificates](images/registered.png)

{PANEL/}

{PANEL:Generate Client Certificate} 

Using this view, you can generate client certificates directly via RavenDB. Newly generated certificates will be added to the list of registered certificates.

![Figure 3. Generate Client Certificate](images/generate.png)

When generating a certificate, you need to fill the following fields:

- Name
- Security Clearance
- Allowed databases and access level for each database

This information is used by RavenDB internally and is not stored in the certificate itself.

Expiration for client certificates is set to 5 years by default.

{PANEL/}

{PANEL:Upload an Existing Certificate} 

Using this view you can upload existing client certificates. Uploaded certificates will be added to the list of registered certificates.

![Figure 4. Upload Existing Certificate](images/upload.png)

When uploading an existing certificate file, you also need to fill the following fields:

- Name
- Security Clearance
- Allowed databases and access level for each database

This information is used by RavenDB internally and is not stored in the certificate itself.

{PANEL/}

{PANEL:Edit Certificate} 

Every certificate in the list can be edited. The editable fields are:

- Name
- Security Clearance
- Allowed databases and access level for each database

![Figure 5. Edit Certificate](images/edit.png)

{PANEL/}

{PANEL:Certificate Collections} 

Pfx files may contain a single certificate or a collection of certificates.

When uploading a .pfx file with a collection, RavenDB will add all of the certificates to the list of registered certificates as one entry and will allow access to all of the certificates in the collection explicitly by their thumbprint.

{PANEL/}

{PANEL:Export Cluster Certificates} 

This options allows you to export the server certificate as a .pfx file. In case of a cluster which contains several different server certificates, a .pfx collection will be exported.

{PANEL/}

{PANEL:Client Certificate Chain of Trust} 

As mentioned above, RavenDB generates client certificates by signing them using the server certificate. A typical server certificate doesn't allow acting as an Intermediate Certificate Authority signing other certificates. This is the case with Let's Encrypt certificates.

The left side of the following screenshot shows a newly generated client certificate, signed by a Let's Encrypt server certificate. You cannot see the full chain of trust because the OS (Windows) doesn't have knowledge of the server certificate.

If you wish to view the full chain, add the server certificate to the OS trusted store. This step is **not necessary** for RavenDB and is explained here only to show how to view the full chain in Windows. The right side of the screenshot shows the full chain. 


![Figure 6. Client Cert Chain](images/client-cert.png)

Because client certificates are managed by RavenDB directly and not through any PKI infrastructure **this is perfectly acceptable**. Authenticating a client certificate is done explicitly by looking for the thumbprint in the registered certificates list in the server and not by validating the chain of trust. 

{PANEL/}

## Related articles

### Security

- [Overview](../../../server/security/overview)
- [Manual Certificate Configuration](../../../server/security/authentication/certificate-configuration)

### Installation

- [Secure Setup with a Let's Encrypt Certificate](../../../start/installation/setup-wizard#secure-setup-with-a-let)
- [Secure Setup with Your Own Certificate](../../../start/installation/setup-wizard#secure-setup-with-your-own-certificate)

### Configuration

- [Security Configuration](../../../server/configuration/security-configuration)
