# Installation: Deployment Considerations

Deployment of a RavenDB cluster requires some thought about how to setup the network and the cluster and the databases you'll use. 
In terms of hardware, while obviously more is generally better, RavenDB can do quite well on small instances (such as a resource
limited Docker container) and scale upward to machines with hundreds of GB of RAM and a large number of cores.

## Performance Considerations

For read-mostly scenarios, the more cores the machine have, the faster RavenDB will be since reads take no locks and require no 
coordination from RavenDB. For write-heavy scenarios, faster cores are better than more cores generally, but the usual limit is 
the speed of the storage. For both reads & writes, given the choice between more cores and more memory, the typical answer would
be to get more memory. 

RavenDB does just fine when the size of the databases exceed the size of the physical memory. It will
make use of all the memory that it can to ensure speedy queries and fast responses. So the more memory it has available, the better
things are.

In a cluster environment, avoid using a SAN or NAS to store the data from multiple RavenDB nodes in the same physical location.
It is much better to have each node use its local disks because this way there is no contention between the different nodes on the
same storage resources. 

Storage latency is also a very important factor in RavenDB's performance. If you are running on cloud infrastructure, you should 
ensure that you are using high IOPS disks. Avoid options such as burstable performance, since under load RavenDB may consume all the
burst capacity available and suffer because it is being throttled. If this happens, you'll usually get a warning about slow I/O in 
the studio. If you are running on physical hardware, use an SSD or NVMe drives. Drives using HDD will work, but may result in high
latencies under load because of the rotational disk seek times.

Advanced scenarios may call to splitting I/O among multiple disks. Having separate drives for data, journals and indexes. You can
read more about it in the document about the [customizing RavenDB Data files location](../../server/storage/customizing-raven-data-files-locations).

## Storage Considerations

The requirements of the storage can be found in the article describing [Voron](../../server/storage/storage-engine#requirements), the storage engine used by RavenDB.

{NOTE: SMB / CIFS is not supported for production scenarios}

[SMB / CIFS](https://en.wikipedia.org/wiki/Server_Message_Block) is a protocol that can be used to access remote files over then network, between machines running different operating systems.
It is widely used in two scenarios:

-  Azure File Storage service aka [CloudStor:Azure](https://azure.microsoft.com/en-us/services/storage/files/)   
-  Linux Docker container running under Windows Docker host with [sharing volumes](https://docs.docker.com/storage/volumes/#share-data-among-machines)

What is supported:

- On Windows, Linux and any Docker instance: NTFS, ext4 and other non NFS volumes mounts
- Azure: using dedicated storage such as NTFS and ext4   

_Note_: RavenDB does operate with ext2 and other lack of journaling mechanism file systems, however ungraceful restart (or catastrophic failure) might enter database into corrupted state, and therefor not supported.

{NOTE /}

## Network Considerations

RavenDB can be deployed either internally in your organization (secured network, only known good actors), or on the public Internet.
Any deployment, aside from maybe on a developer machine, should use the secured mode. See the 
[Setup Wizard](../../start/installation/setup-wizard) for the details on how to do that. 

RavenDB will typically use two ports. One for HTTPS traffic, for clients and browsers and one for TCP, used by the cluster nodes to
communicate with each other. Both the HTTPS and TCP traffic are encrypted by default (unless you explicitly specify the unsecured setup)
using TLS 1.2. Be sure to open both ports in the firewall to allow the cluster node to talk to one another. 

RavenDB should _not_ typically be deployed behind a reversed proxy. The typical advantages of reverse proxies are based on their ability
to load balance, cache responses, etc. These features are great when proxying a web application, but actively harmful when you are talking
to a stateful system like a database. Your application should be talking to RavenDB directly, given the URLs of the cluster nodes and let
RavenDB itself handle issues such as high availability, load balancing and security. 

## Running RavenDB

On Windows, RavenDB is usually run as a service. Make sure that the user running the RavenDB service has permissions to the RavenDB directory
and the specified data directory. You can setup RavenDB as a service using the `setup-as-service.ps1` script. 

On Linux, you'll typically run RavenDB as a daemon. The `install-daemon.sh` can handle the daemon registration for you (Ubuntu only).

In either case, you can configure RavenDB using the [settings.json](../../server/configuration/configuration-options#json) file. The most important configurations are the data directory and the 
IPs and ports RavenDB will listen to. It is recommended that you'll pick the fastest drives for RavenDB's data directory, while the binaries
for RavenDB can reside anywhere in the system.

## Related Articles

### Installation

- [System Requirements](../../start/installation/system-requirements)
- [System Configuration Recommendations](../../start/installation/system-configuration-recommendations)
- [Upgrading to New Version](../../start/installation/upgrading-to-new-version)

### Server

- [Configuration Options](../../server/configuration/configuration-options)
- [Structure of Data on Disk](../../server/storage/directory-structure)
- [Customizing RavenDB Data Files Locations](../../server/storage/customizing-raven-data-files-locations)

### Security

- [Security in RavenDB](../../server/security/overview)



