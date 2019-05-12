# Authentication: Let's Encrypt Certificates

RavenDB 4.x uses X.509 certificates for authentication and authorization and has **built in support** for [Let's Encrypt](https://letsencrypt.org/).

## Obtain a Let's Encrypt Certificate

The [Setup Wizard Walkthrough](../../../start/installation/setup-wizard) explains how to obtain a free Let's Encrypt certificate for your server or cluster.

It's a wildcard certificate, so if you choose the domain `example` during the wizard (with the community license), the generated certificate will have the common name (CN) `*.example.ravendb.community`.

## Automatic Renewal

Let's Encrypt certificates have a [90-day lifetime policy](https://letsencrypt.org/2015/11/09/why-90-days.html).

In RavenDB, you don't need to worry about renewals. RavenDB takes care of this for you.

When there are 30 days left until expiration, RavenDB will initiate the certificate renewal and replacement process. The actual request to Let's Encrypt will happen on the nearest coming Saturday.

Once the renewed certificate is obtained, [it will be replaced](../../../server/security/authentication/certificate-renewal-and-rotation) in all the nodes of the cluster without needing to shut down any server.

{WARNING: Warning} 
Automatic certificate renewal is available only if you obtained your certificate using the Setup Wizard and got your free RavenDB domain. Independently obtained certificates will not renew automatically, even if issued by Let's Encrypt.
{WARNING/}

When running as a cluster, the replacement process is a distributed operation. It involves sending the new certificate to all nodes, and requires all nodes to confirm that they have recieved and replaced the certificate.

Only when all nodes have confirmed will the cluster start using this new certificate. 

If a node is not responding during the replacement, the operation will not complete until one of the following happens:

* The node will come back online. It should pick up the replacement command and join the replacement process automatically.

* There are only 3 days left for the expiration of the certificate. In this case, the cluster will complete the operation without the node which is down. **When bringing that node up, the certificate must be replaced manually.**

During the process you will receive alerts in the studio and in the logs indicating the status of the operation and any errors if they occur. The alerts are displayed for each node independently.

## Manual Renewal

You may initiate the renewal process manually by going to the certificate view in the studio and clicking `Renew` on the server certificate. It will trigger the same certificate replacement process which was described in [Automatic Renewal](../../../server/security/authentication/lets-encrypt-certificates#automatic-renewal).

If a node is down and you click `Renew`, the cluster will complete the operation without the node that is down. **When bringing that node up, the certificate must be replaced manually.**


## Updating DNS records

Updating DNS records for your domain can be acheived by running the Setup Wizard again or by using a dedicated page at the RavenDB website.

You can easily edit the DNS records which are associated with your license using the [Customers Portal](https://customers.ravendb.net).

## Related articles

### Security 

- [Overview](../../../server/security/overview)
- [Certificate Management](../../../server/security/authentication/certificate-management)
- [Common Errors and FAQ](../../../server/security/common-errors-and-faq)

### Client API

- [Setting up Authentication and Authorization](../../../client-api/setting-up-authentication-and-authorization)

### Installation

- [Secure Setup with a Let's Encrypt Certificate](../../../start/installation/setup-wizard#secure-setup-with-a-let)
