# Pull Replication

Pull replication is especially useful for deployments that involve many RavenDB instances which are required to be synchronized with the main server.

Mainly, it is simplifies the required security configuration for such use case, because the main server has to open only a single communication port for incoming connections.

## Configure the Hub

The Hub is resides on the main server and is configured only once. 

![Figure 1. Hub configuration](images/pull-replication-hub-config.png "Configure the Hub")

1. `Hub Definition Name` - Is the unique name for the pull replication, it is required later for the sink to use this specific name in order to pull from this hub.
2. `Delay` - Document will be replicated only after this time period has passed, since the this document was written.
3. `Preferred Node` - The preferred node that will push the data to the sink. 
4. `Certificates` - The certificates are used internally by RavenDB for authorization and authentication, this certificate _doesn't_ have to be signed by a trusted CA, since in this case we rely on the thumbprint to allow the connection, so it could a self-generated certificate or any other one.
5. `Export Configuration` - After all settings are saved and filled, you can click on the export button to generate a `json` file which can be later imported into any sink to quickly enable the pull replication from this hub.

## Configure the Sink

The Sink will initiate the connection to the hub and receive the data from him. 

![Figure 2. Sink configuration](images/pull-replication-sink-config.png "Configure the Sink")

1. `Task Name` - An optional name for this task.
2. `Hub Definition Name` - The hub definition name from which this sink should pull from.
3. `Preferred Node` - The node the will be preferred to received the data.
4. `Connection String` - Define the connection string to the hub cluster.
5. `Certificate` - The certificate here is required to include also the private key, since the sink initiate the communication.
6. `Import Configuration` - Import the configuration file created by the hub and it will fill all the necessary fields for you.

{WARNING: }

Upon failure the sink will try to reconnect every 15 seconds, it is a good practice to disable the pull replication on the Sink side if no sync with the main server is in the horizon.

{WARNING/}