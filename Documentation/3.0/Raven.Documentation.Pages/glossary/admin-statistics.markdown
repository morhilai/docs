# Glossary: AdminStatistics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **ServerName** | string | The name of the server |
| **TotalNumberOfRequests** | int | Total number of requests that was made to server |
| **Uptime** | TimeSpan | Server uptime |
| **Memory** | [AdminMemoryStatistics](../glossary/admin-statistics#adminmemorystatistics) | Admin memory statistics (described below) |
| **LoadedDatabases** | IEnumerable&lt;[LoadedDatabaseStatistics](../glossary/admin-statistics#loadeddatabasestatistics)&gt; | Information about loaded databases (described below) |
| **LoadedFilesystems** | IEnumerable&lt;[FileSystemStats](../glossary/admin-statistics#filesystemstats)&gt; | Information about loaded filesystes (described below) |

<hr />

# AdminMemoryStatistics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **DatabaseCacheSizeInMB** | decimal | The size of database cache in MB |
| **ManagedMemorySizeInMB** | decimal | The size of managed memory in MB |
| **TotalProcessMemorySizeInMB** | decimal | The total memory size of progess in MB |

<hr />

# LoadedDatabaseStatistics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Name** | string | Database name |
| **LastActivity** | DateTime | Time of last activity |
| **TransactionalStorageAllocatedSize** | long | Allocated size of transactional store |
| **TransactionalStorageAllocatedSizeHumaneSize** | string | Allocated size of transactional store (formatted) |
| **TransactionalStorageUsedSize** | long | Used size of transactional store |
| **TransactionalStorageUsedSizeHumaneSize** | string | Used size of transactional store (formatted) |
| **IndexStorageSize** | long | The size of index storage |
| **IndexStorageHumaneSize** | string | The size of index storage (formatted) |
| **TotalDatabaseSize** | long | Total database size |
| **TotalDatabaseHumaneSize** | string | Total database size (formatted) |
| **CountOfDocuments** | long | The amount of documents in database |
| **CountOfAttachments** | long | The amount of attachments in database |
| **DatabaseTransactionVersionSizeInMB** | decimal | The database transaction version size in MB |
| **Metrics** | [DatabaseMetrics](../glossary/admin-statistics#databasemetrics) | Metrics Details |
| **StorageStats** | [StorageStats](../glossary/admin-statistics#storagestats) | Storage Details |

<hr />

# FileSystemStats

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Name** | string | Filesystem name |
| **FileCount**| long | The amount of files |
| **Metrics** | [FileSystemMetrics](../glossary/admin-statistics#filesystemmetrics) | Metrics Details |
| **ActiveSyncs** | IList&lt;[SynchronizationDetails](../glossary/admin-statistics#synchronizationdetails)&gt; | Information about active syncs |
| **PendingSyncs** | IList&lt;[SynchronizationDetails](../glossary/admin-statistics#synchronizationdetails)&gt; | Information about pending syncs |

<hr />

# DatabaseMetrics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **DocsWritesPerSecond** | double | Amount of documents writes per second |
| **IndexedPerSecond** | double | Amount of documents indexed per second |
| **ReducedPerSecond** | double | Amount of documents reduced per second |
| **RequestsPerSecond** | double | Requests per second |
| **Requests** | MeterData | Amount of requests statistics |
| **RequestsDuration** | HistogramData | Histogram of request duration |
| **StaleIndexMaps** | HistogramData | Histogram of stale index count (for map indexes) |
| **StaleIndexReduces** | HistogramData | Histogram of stale index count (for map/reduce indexes) |
| **Gauges** | Dictionary&lt;string, Dictionary&lt;string, string&gt;&gt; | Various statistics |
| **ReplicationBatchSizeMeter** | Dictionary&lt;string, MeterData&gt;  | Replication batch size statistics |
| **ReplicationDurationMeter** | Dictionary&lt;string, MeterData&gt;  | Replication duration statistics |
| **ReplicationBatchSizeHistogram** | Dictionary&lt;string, HistogramData&gt; | Replication batch size histogram |
| **ReplicationDurationHistogram** | Dictionary&lt;string, HistogramData&gt; | Replication duration histogram |

<hr />

# StorageStats

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| VoronStats | [VoronStorageStats](../glossary/admin-statistics#voronstoragestats) | Stats related to voron storage engine |
| EsentStats | EsentStorageStats | Stats related to esent storage engine |

<hr />

# VoronStorageStats

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **FreePagesOverhead** | long | Free pages overhead |
| **RootPages** | long | Amount of root pages |
| **UnallocatedPagesAtEndOfFile** | long | Unallocated pages at end of file |
| **UsedDataFileSizeInBytes** | long | Used data file size in bytes |
| **AllocatedDataFileSizeInBytes** | long | allocated data file size in bytes |
| **NextWriteTransactionId** | long | next write transaction id |
| **ActiveTransactions** | List&lt;VoronActiveTransaction&gt; | List of active voron's transactions |

<hr />

# FileSystemMetrics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **FilesWritesPerSecond** | double | Amount of file written per second |
| **RequestsPerSecond** | double | Amount of requests per second |
| **Requests** | MeterData | Request count statistics |
| **RequestsDuration** | HistogramData | Histogram of requests duration |

<hr />

# SynchronizationDetails

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **FileName** | string | File name |
| **FileETag** | Guid | File etag |
| **DestinationUrl** | string | Destination url |
| **Type** | [SynchornizationType](../glossary/admin-statistics#synchronizationtype-enum) | Synchronization type |

<hr />

# SynchronizationType (enum)

### Members

| Name | Value |
| ---- | ----- |
| **Unknown** | `0` |
| **ContentUpdate** | `1` |
| **MetadataUpdate** | `2` |
| **Rename** | `3` |
| **Delete** | `4` |
