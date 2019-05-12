# Authentication: Certificate Renewal & Rotation

X.509 certificates have expiration dates and must be renewed once in a while.

When using the Setup Wizard to obtain a Let's Encrypt certificate, you don't have to worry about this. Read about [Automatic Let's Encrypt Renewals in RavenDB](../../../server/security/authentication/lets-encrypt-certificates).

If you provided your own certificate to RavenDB, it is **your responsibility** to renew it. 

Once you have a new valid certificate for your server/cluster you need to make RavenDB use it instead of the currently loaded certificate. Replacing a certificate in the cluster is a distributed operation which requires all the nodes to confirm the replacement. The actual update will happen when all nodes of the cluster confirm the replacement or when there are 3 days left for expiration. 

You can also ignore these limits and replace the certificates immediately but beware of this option. Nodes which didn't confirm the replacement, will not be able to re-join the cluster and will have to be setup manually. This means the new certificate will have to be placed manually in that node. 

To manually replace the server certificate you can either edit [settings.json](../../configuration/configuration-options#json) with a new certificate path and restart the server or you can overwrite the existing certificate file and the server will pick it up within one hour without requiring a restart.

{DANGER The new certificate must contain all of the cluster domain names in the CN or ASN properties of the certificate. Otherwise you will get an authentication error because SSL/TLS requires the domain in the certificate to match with the actual domain being used. /}

## Replace the Cluster Certificate Using the Studio

Access the certificate view, click on `Cluster certificate` -> `Replace cluster certificate` and upload the new certificate PFX file.

This will start the certificate replacement process.

When running as a cluster, the replacement process is a distributed operation. It involves sending the new certificate to all nodes, and requires all nodes to confirm receipt and replacement of the certificate.

Only when all nodes have confirmed, the cluster will start using this new certificate. 

If a node is not responding during the replacement, the operation will not complete until one of the following happens:

* The node will come back online. It should pick up the replacement command and join the replacement process automatically.

* There are only 3 days left for the expiration of the certificate. In this case, the cluster will complete the operation without the node which is down. When bringing that node up, the certificate must be replaced manually.

* `Replace immediately` is chosen. In this case, the cluster will complete the operation without the node which is down. When bringing that node up, the certificate must be replaced manually.

During the process you will receive alerts in the studio and in the logs indicating the status of the operation and any errors if they occur. The alerts are displayed for each node independently.

## Replace the Cluster Certificate Using Powershell

Here is a little example of using the REST API directly with powershell to replace the cluster certificate:

{CODE-BLOCK:powershell}
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

$clientCert = Get-PfxCertificate -FilePath C:\path\to\client\cert\admin.client.certificate.raven.pfx

$newCert = get-content 'C:\path\to\server\cert\new.certificate.pfx' -Encoding Byte

$newCertBase64 = [System.Convert]::ToBase64String($newCert)

$payload = @{
    Name              = "MyNewCert";
    Certificate       = $newCertBase64;
} | ConvertTo-Json

$response = Invoke-WebRequest https://b.raven.development.run:8080/admin/certificates/replace-cluster-cert -Certificate $clientCert -Method POST -Body $payload -ContentType "application/json"
{CODE-BLOCK/}

## Implicit Trust by Public Key Pinning Hash

As mentioned, RavenDB could only trust certificates which were explicitly registered in the cluster. Now, consider the following scenario:

Two secured RavenDB clusters with ETL or External Replication defined between the two. The destination cluster trusts (explicitly) the source cluster's certificate. 
Once the source cluster renews its certificate, the destination cluster will no longer trust it because the thumbprint has changed. 
In such a case, the admin had to go to the destination and manually tell it to trust the new source certificate.

The problem was addressed in RavenDB 4.2 where Implicit Trust by `Public Key Pinning Hash` was introduced. If the source cluster renews its certificate by 
using **the same private key**, the new certificate will have the same `Public Key Pinning Hash`, and the destination cluster will be able to trust the new certificate. It will also be registered (implicitly) for future connections.

{WARNING:Important}
For security reasons, this feature will only work if the new certificate was issued by the same certificate authority as the original certificate.
{WARNING/}

When using the RavenDB Let's Encrypt solution, all of the renewals and certificate signing is handled for you (using the same private key). It means you don't need to do **anything** and the whole process is transparent.
But, in case you provide your own certificate, in order to use this feature you must use the same issuer and sign the certificate with the same private key as the one you are renewing. 

This feature means that you can drastically reduce the amount of work that an admin has to do in a multi-cluster topology and leads you to a system that you setup once and just keeps working.

{NOTE:Tip}
To find out the public key pinning hash of your server certificate, take a look at this [C# code](https://github.com/ravendb/ravendb/blob/v4.2/src/Raven.Server/Utils/CertificateUtils.cs#L314) or issue the following command against your running server, by using OpenSSL:
{CODE-BLOCK:bash}
openssl s_client -servername my.ravendb.cluster.com -connect my.ravendb.cluster.com:443 | openssl x509 -pubkey -noout | openssl rsa -pubin -outform der | openssl dgst -sha256 -binary | openssl enc -base64
{CODE-BLOCK/}
{NOTE/}

## Related Articles

### Security

- [Overview](../../../server/security/overview)
- [Certificate Management](../../../server/security/authentication/certificate-management)

### Installation

- [Secure Setup with a Let's Encrypt Certificate](../../../start/installation/setup-wizard#secure-setup-with-a-let)
- [Secure Setup with Your Own Certificate](../../../start/installation/setup-wizard#secure-setup-with-your-own-certificate)

### Configuration

- [Security Configuration](../../../server/configuration/security-configuration)
