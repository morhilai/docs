# Cluster: How a Client Integrates with Replication and the Cluster

{PANEL:**Failover Behavior**}

* In RavenDB, the replication is _not_ a bundle and is always enabled if there are two nodes or more in the cluster. 
  This means that the failover mechanism is always turned on by default.  

* The client contains a list of cluster nodes per database group.  
  Each time the client needs to do a request to a database, it will choose a node that contains this database from this list to send the request to. 
  If the node is down and the request fails, it will select another node from this list.  

* The choice of which node to select depends on the value of `ReadBalanceBehavior`, which is taken from the current conventions. 
  For more information about the different values and the node selection process, see [Load balance & Failover Conventions](../../client-api/configuration/load-balance-and-failover). 
  
{NOTE Each failure to connect to a node spawns a health check for that node. For more information see [Cluster Node Health Check](health-check)./}

{PANEL/}

{PANEL:**Cluster Topology In The Client**}

When the client is initialized, it fetches the topologies and populates the nodes list for the load-balancing and failover functionality.
During the lifetime of a RavenDB Client object, it periodically receives the cluster and the databases topologies from the server.  

The topology is updated with the following logic:

* Each topology has an etag, which is a number
* Each time the topology has changed, the etag is incremented
* For each request, the client adds the latest topology etag it has to the header
* If the current topology etag at the server is higher than the one in the client, the server adds `"Refresh-Topology:true"` to the response header
* If a client detects the `"Refresh-Topology:true"` header in the response, the client will fetch the updated topology from the server
  Note: if `ReadBalanceBehavior.FASTEST_NODE` is selected, the client will schedule a speed test to determine the fastest node

The client configuration is handled in a similar way:

* Each client configuration has an etag attached
* Each time the configuration has changed at the server-side, the server adds `"Refresh-Client-Configuration"` to the response
* When the client detects the aforementioned header in the response, it schedules fetching the new configuration
{PANEL/}

{PANEL:**Topology Discovery**}
In RavenDB 4.x, cluster topology has an etag which increments after each topology change.

### How and When the Topology is Updated

* The first time any request is sent to RavenDB server, the client fetches cluster topology
* Each subsequent request happens with a fetched topology etag in the HTTP headers, under the key 'Topology-Etag'
* If the response contains the 'Refresh-Topology: true' header, then a thread responsible for updating the topology will be spawned

{PANEL/}

{PANEL:**Configuring Topology Nodes**}

Listing any node in the initialization of the cluster in the client is enough to be able to properly connect to the specified database. 
Each node in the cluster contains the full topology of all databases and all nodes that are in the cluster.
Nevertheless, it is possible to specify multiple node urls at the initialization. But why list multiple the nodes in the cluster, if url of any cluster node will do?

By listing multiple the nodes in the cluster, we can ensure that if a single node is down and we bring a new client up, we'll still be able to get the initial topology. If the cluster sizes are small (three to five nodes), we'll typically list all the nodes in the cluster. But for larger clusters, we'll usually just list enough nodes that having them all go down at once will mean that you have more pressing concerns then a new client coming up.

{CODE:java InitializationSample@ClientApi\Cluster\HowClientApiIntegratesWithReplicationAndCluster.java /}

{PANEL/}

{PANEL:**Write assurance and database groups**}

In RavenDB clusters, the databases are hosted in database groups. 
Since there is a master-master replication configured between database group members, a write to one of the nodes will be replicated to all other instances of the group.
If there are some writes that are important, it is possible to make the client wait until the transaction data gets replicated to multiple nodes. It is called a 'write assurance', and it is available with the `WaitForReplicationAfterSaveChanges()` method.

{CODE:java WriteAssuranceSample@ClientApi\Cluster\HowClientApiIntegratesWithReplicationAndCluster.java /}

{PANEL/}


## Related articles

### Cluster

- [Clustering Overview](../../server/clustering/overview)
- [Client Speed Test](../../client-api/cluster/speed-test)
- [Cluster Node Health Check](../../client-api/cluster/health-check)

### Configuration

- [Load Balance & Failover](../../client-api/configuration/load-balance-and-failover)
