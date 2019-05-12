# Administration: Statistics

## Server statistics

One of the options available for the RavenDB administrators enables them to retrive database statistics for the server. The statistics are available at `/admin/stats` endpoint or by the Client API (details [here](../../client-api/commands/how-to/get-database-and-server-statistics)).

{CODE-BLOCK:json}
	curl -X GET "http://localhost:8080/admin/stats"
{CODE-BLOCK/}

Document with the following format is retrieved:

{CODE-BLOCK:json}
    {
      "ServerName": null,
      "TotalNumberOfRequests": 212,
      "Uptime": "00:04:37.5452852",
      "Memory": {
        "DatabaseCacheSizeInMB": 0.00,
        "ManagedMemorySizeInMB": 568.88,
        "TotalProcessMemorySizeInMB": 838.39
      },
      "LoadedDatabases": [
        {
          "Name": "Northwind",
          "LastActivity": "2014-08-07T08:17:43.7246662Z",
          "TransactionalStorageAllocatedSize": 6356992,
          "TransactionalStorageAllocatedSizeHumaneSize": "6.06 MBytes",
          "TransactionalStorageUsedSize": 4509696,
          "TransactionalStorageUsedSizeHumaneSize": "4.3 MBytes",
          "IndexStorageSize": 307512,
          "IndexStorageHumaneSize": "300.3 KBytes",
          "TotalDatabaseSize": 6664504,
          "TotalDatabaseHumaneSize": "6.36 MBytes",
          "CountOfDocuments": 1059,
          "CountOfAttachments": 0,
          "DatabaseTransactionVersionSizeInMB": 0.00,
          "Metrics": {
            "DocsWritesPerSecond": 0.0,
            "IndexedPerSecond": 0.0,
            "ReducedPerSecond": 0.0,
            "RequestsPerSecond": 0.0,
            "Requests": {
              "Count": 23,
              "MeanRate": 0.096,
              "OneMinuteRate": 0.048,
              "FiveMinuteRate": 0.771,
              "FifteenMinuteRate": 1.253
            },
            "RequestsDuration": {
			  "Type": "Histogram",
              "Counter": 23,
              "Max": 2224.0,
              "Min": 0.0,
              "Mean": 184.95652173913044,
              "Stdev": 534.17859443353609,
              "Percentiles": {
                "50%": 3.0,
                "75%": 28.0,
                "95%": 2054.9999999999977,
                "99%": 2224.0,
                "99.9%": 2224.0,
                "99.99%": 2224.0
              }
            },
            "StaleIndexMaps": {
			  "Type": "Histogram",
              "Counter": 20,
              "Max": 4.0,
              "Min": 0.0,
              "Mean": 0.4,
              "Stdev": 1.2311740225021848,
              "Percentiles": {
                "50%": 0.0,
                "75%": 0.0,
                "95%": 4.0,
                "99%": 4.0,
                "99.9%": 4.0,
                "99.99%": 4.0
              }
            },
            "StaleIndexReduces": {
			  "Type": "Histogram",
              "Counter": 20,
              "Max": 2.0,
              "Min": 0.0,
              "Mean": 0.2,
              "Stdev": 0.52314836378059693,
              "Percentiles": {
                "50%": 0.0,
                "75%": 0.0,
                "95%": 1.9499999999999993,
                "99%": 2.0,
                "99.9%": 2.0,
                "99.99%": 2.0
              }
            },
            "Gauges": {
              "Raven.Database.Indexing.IndexBatchSizeAutoTuner": {
                "MaxNumberOfItems": "131072",
                "CurrentNumberOfItems": "1024",
                "InitialNumberOfItems": "512"
              },
              "Raven.Database.Indexing.WorkContext": {
                "RunningQueriesCount": "1"
              },
              "Raven.Database.Indexing.ReduceBatchSizeAutoTuner": {
                "InitialNumberOfItems": "256",
                "MaxNumberOfItems": "65536",
                "CurrentNumberOfItems": "1024"
              }
            },
            "ReplicationBatchSizeMeter": {},
            "ReplicationDurationMeter": {},
            "ReplicationBatchSizeHistogram": {},
            "ReplicationDurationHistogram": {}
          },
          "StorageStats": {
            "VoronStats": null,
            "EsentStats": {}
          }
        }
      ],
      "LoadedFileSystems": []
    }
{CODE-BLOCK/}

where    

* **TotalNumberOfRequests** - number of requests that have been executed against the server   
* **Uptime** - uptime of a server      
* **Memory** - memory information   
    * **DatabaseCacheSizeInMB** - size of cache
    * **ManagedMemorySizeInMB** - size of managed memory taken by server   
    * **TotalProcessMemorySizeInMB** - total size of memory taken by server    
* **LoadedDatabases** - list of current active databases containing:    
   * **Name** - database name   
   * **LastActivity** - database last activity time   
   * **TransactionalStorageAllocatedSize** - number of bytes allocated by data storage engine
   * **TransactionalStorageAllocatedSizeHumaneSize** - number of bytes allocated by data storage engine in a more readable form
   * **TransactionalStorageUsedSize** - number of bytes used by data storage engine
   * **TransactionalStorageUsedSizeHumaneSize** - number of bytes used by data storage engine in a more readable form
   * **IndexStorageSize** - number of bytes taken by index storage
   * **IndexStorageHumaneSize** - number of bytes taken by index storage in a more readable form
   * **TotalDatabaseSize** - total number of bytes taken by both data and index storages
   * **TotalDatabaseHumaneSize** - total number of bytes taken by both data and index storages in a more readable form
   * **CountOfDocuments** - number of documents in a database
   * **CountOfAttachments** - number of attachments in a database
* **Metrics**
    * **DocsWritesPerSecond** - number of document writes per second
    * **IndexedPerSecond** - number of indexed documents per second
    * **ReducedPerSecond** - number of reductions per second
    * **RequestsPerSecond** - number of requests per second
    * **Requests** - detailed request statistics
    * **RequestsDuration** - detailed request duration statistics
    * ...many more

## Database statistics

To obtain the database statistics you have to use `/stats` endpoint or access them by the Client API (details [here](../../client-api/commands/how-to/get-database-and-server-statistics)).

{CODE-BLOCK:json}
	curl -X GET "http://localhost:8080/stats" //statistics for 'system' database
curl -X GET "http://localhost:8080/databases/Northwind/stats" //statistics for 'Northwind' database
{CODE-BLOCK/}

Executing one of the above actions will end up in getting a document in the following format:

{CODE-BLOCK:json}
	{
	  "StorageEngine": "Esent",
	  "LastDocEtag": "01000000-0000-0001-0000-000000000423",
	  "LastAttachmentEtag": "00000000-0000-0000-0000-000000000000",
	  "CountOfIndexes": 4,
	  "CountOfResultTransformers": 1,
	  "InMemoryIndexingQueueSizes": [
		0
	  ],
	  "ApproximateTaskCount": 0,
	  "CountOfDocuments": 1059,
	  "CountOfAttachments": 0,
	  "StaleIndexes": [],
	  "CountOfStaleIndexesExcludingDisabledAndAbandoned": 0,
	  "CurrentNumberOfItemsToIndexInSingleBatch": 1024,
	  "CurrentNumberOfItemsToReduceInSingleBatch": 1024,
	  "DatabaseTransactionVersionSizeInMB": 0.09,
	  "Indexes": [
		{
		  "Id": 1,
		  "Name": "Raven/DocumentsByEntityName",
		  "IndexingAttempts": 1051,
		  "IndexingSuccesses": 1051,
		  "IndexingErrors": 0,
		  "LastIndexedEtag": "01000000-0000-0001-0000-000000000423",
		  "IndexingLag": 0,
		  "LastIndexedTimestamp": "2014-11-28T09:39:20.6516199Z",
		  "LastQueryTimestamp": "2014-11-28T09:39:20.2775050Z",
		  "TouchCount": 0,
		  "Priority": "Normal",
		  "ReduceIndexingAttempts": null,
		  "ReduceIndexingSuccesses": null,
		  "ReduceIndexingErrors": null,
		  "LastReducedEtag": null,
		  "LastReducedTimestamp": null,
		  "CreatedTimestamp": "2014-11-28T09:39:13.6699995Z",
		  "LastIndexingTime": "2014-11-28T09:39:24.5560252Z",
		  "IsOnRam": "false",
		  "LockMode": "LockedIgnore",
		  "IsMapReduce": false,
		  "ForEntityName": [],
		  "Performance": [
			{
			  "Operation": "Index",
			  "ItemsCount": 512,
			  "InputCount": 512,
			  "OutputCount": 507,
			  "Started": "2014-11-28T09:39:21.0626773Z",
			  "Completed": "2014-11-28T09:39:24.4020158Z",
			  "Duration": "00:00:03.3393385",
			  "DurationMilliseconds": 3339.34,
			  "Operations": [
               {
                  "$type": "Raven.Abstractions.Data.PerformanceStats, Raven.Abstractions",
                  "Name": "Lucene_DeleteExistingDocument",
                  "DurationMs": 0
               },
               {
                  "$type": "Raven.Abstractions.Data.ParallelPerformanceStats, Raven.Abstractions",
                  "NumberOfThreads": 2,
                  "BatchedOperations": [
                    {
                      "StartDelay": 0,
                      "Operations": [
                       {
                         "Name": "LoadDocument",
                         "DurationMs": 0
                       },
                      ...
					  ]
                    },
					...
                  ]
              ],
			  "WaitingTimeSinceLastBatchCompleted": "00:00:00"
			}
	      ],
		  "DocsCount": 1051,
		  "IsInvalidIndex": false
		},
		{
		  "Id": 2,
		  "Name": "Orders/ByCompany",
		  ...
		},
		{
		  "Id": 3,
		  "Name": "Orders/Totals",
		  ...
		},
		{
		  "Id": 4,
		  "Name": "Product/Sales",
		  ...
		}
	  ],
	  "Errors": [],
	  "Prefetches": [
		{
		  "Timestamp": "2014-11-28T09:39:20.7856472Z",
		  "Duration": "00:00:01.4209922",
		  "Size": 512,
		  "Retries": 0,
		  "PrefetchingUser": "Indexer"
		},
		...
	  ],
	  "DatabaseId": "e9c73b04-c787-496a-abf7-7dbef8dde431",
	  "SupportsDtc": true,
	  "Is64Bit": true,
      "IsMemoryStatisticThreadRuning": true
	}
{CODE-BLOCK/}

where

* **StorageEngine** - configured storage engine used by the database (Esent or Voron)
* **LastDocEtag** - last added document Etag   
* **LastAttachmentEtag** - last added attachment Etag   
* **CountOfIndexes** - number of indexes in database
* **CountOfIndexesExcludingDisabledAndAbandoned** - number of indexes excluding disabled and abandoned   
* **CountOfResultTransformers** - number of transformers in database
* **ApproximateTaskCount** - approximate number of current database tasks   
* **InMemoryIndexingQueueSizes** - number of docs in prefetching queues used by indexer
* **CountOfDocuments** - number of documents in database   
* **CountOfAttachments** - number of attachments in database
* **StaleIndexes** - index names of stale indexes   
* **CurrentNumberOfItemsToIndexInSingleBatch** - initial value is 512 for 64-bit systems and 256 for 32-bit. Depending on the load can be auto-adjusted. Used by database indexer.   
* **CurrentNumberOfItemsToReduceInSingleBatch** - initial value is 512 for 64-bit systems and 256 for 32-bit. Depending on the load can be auto-adjusted. Used by database reducer.     
* **DatabaseTransactionVersionSizeInMB** - current size (in MB) of Esent's version store (in memory modified data, relevant for Esent storage only, it returns -1 for Voron)
* **Indexes**    
   * **Id** - index identifier
   * **Name** - index name
   * **IndexingAttempts** - number of indexing attempts    
   * **IndexingSuccesses** - number of indexing successes   
   * **IndexingErrors** - number of indexing errors  
   * **LastIndexedEtag** - GUID representing last indexed Etag  
   * **IndexingLag** - lag between the last indexed etag and the last document etag in the database
   * **LastIndexedTimestamp** - timestamp of last indexed document
   * **LastQueryTimestamp** - last query timestamp 
   * **TouchCount** - number of index touches used to calculate index Etag properly,  
   * **Priority** - controls how much indexing processing resources index can consume. More information [here](../../server/administration/index-administration#index-prioritization).
   * **ReduceIndexingAttempts** - number of reduce attempts. Null if not applicable.   
   * **ReduceIndexingSuccesses** - number of reduce successes. Null if not applicable.   
   * **ReduceIndexingErrors** - number of reduce errors. Null if not applicable.   
   * **LastReducedEtag** - GUID representing last reduced Etag. Null if not applicable.     
   * **LastReducedTimestamp** - last reduce timestamp       
   * **CreatedTimestamp** - indicates when index was created
   * **LastIndexingTime** - time of last indexing run
   * **IsOnRam** - indicates if index is stored only in memory (new and small indexes are stored in memory at first)
   * **LockMode** - indicates what is the current lock mode for index. More information [here](../../server/administration/index-administration#index-locking).
   * **IsMapReduce** - indicates if index is Map-Reduce index
   * **ForEntityName** - names of relevant collections that index processes
   * **Performance** - index performance information
		* **Operation** - operation type:
			* `Map` or `Reduce Level level_number` for Map-Reduce indexes
			* `Index` for Map-only indexes
		* **ItemsCount** - number of documents in processed batch
		* **InputCount**   
			* for `Map` and `Index` operations this is a number of documents sent for processing   
			* for `Reduce Level level_number` operation this is a number of documents that came from `Map` operation.   
		* **OutputCount** - number of produced index entries
		* **Started** - operation start time    
		* **Completed** - operation complete time
		* **Duration** - operation duration 
		* **DurationInMilliseconds** - duration in milliseconds
		* **LoadDocumentCount** - number of loaded documents by using [`LoadDocument`](../../indexes/indexing-related-documents) call
		* **LoadDocumentDurationMs** - total duration of loading documents in milliseconds
		* **WritingDocumentsToLuceneDurationMs** - time spent on writing documents to Lucene index
		* **LinqExecutionDurationMs** - time executing Linq statement (Map or Reduce definition)
		* **FlushToDiskDurationMs** - time calling Flush on the index writer
		* **WaitingTimeSinceLastBatchCompleted** - time between the completion of a previous batch and a start of the current one
   * **DocsCount** - number of indexes documents
   * **IsInvalidIndex** - `true` if index index is invalid, otherwise `false`
* **Errors**
   * **Index** - name of index that caused error    
   * **Error** - error message    
   * **Timestamp** - error timestamp   
   * **Document** - key of document that caused error     
* **Prefetches** - prefetched indexing statistics        
   * **Timestamp** - prefetching start time     
   * **Duration** - prefetching duration      
   * **Size** - number of documents prefetched      
   * **Retries** - number of prefetching retries  
   * **PrefetchingUser** - prefetching user name
* **DatabaseId** - unique Id for database
* **SupportsDtc** - indicates if database (transactional storage) supports DTC transactions    
* **Is64Bit** - indicates whether the system is 64-bit system
* **IsMemoryStatisticThreadRuning** - indicates if the statistic thread is running
