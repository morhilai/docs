# Configuration: Replication Options

{PANEL:Replication.ActiveConnectionTimeoutInSec}

Threshold in seconds under which an incoming replication connection is considered active. If an incoming connection receives messages within this time-span, a new connection coming from the same source will be rejected (as the existing connection is considered active).

- **Type**: `int`
- **Default**: `30`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:Replication.ReplicationMinimalHeartbeatInSec}

Minimal time in seconds before sending another heartbeat.  

- **Type**: `int`
- **Default**: `15`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:Replication.RetryReplicateAfterInSec}

This option determines how often the queue for retry attempts is updated. It does _not_ determine the timeout between retry attempts. To configure that,
use `Replication.RetryMaxTimeoutInSec` below.

- **Type**: `int`
- **Default**: `15`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:Replication.RetryMaxTimeoutInSec}

Maximum timeout in seconds for successive retry attempts.  
If a replication fails, the server will retry after a timeout, and will continue to retry until it succeeds. The timeout value increases between each 
attempt, so the attempts become less frequent. The timeout continues to increase until it reaches this maximum value.  

- **Type**: `int`
- **Default**: `300`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:Replication.MaxItemsCount}

Maximum number of items sent in a single batch during replication. If set to `null`, the number of items in the batch is not limited.

- **Type**: `int`
- **Default**: `16 * 1024`
- **Scope**: Server-wide or per database

{PANEL/}

{PANEL:Replication.MaxSizeToSendInMb}

Maximum size in Mb of a single batch sent during replication. If set to `null`, the size of the batch is not limited.

- **Type**: `int`
- **Default**: `64`
- **Scope**: Server-wide or per database

{PANEL/}
