# Administration: Index Administration

RavenDB indexes can be administrated easily by the user with the [Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view) or via maintenance operations in the Client API.

## Stop & Start 

Stopping the indexing for a database will result in pausing all indexes. You can do that using [the Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) 
or [the Client API](../../client-api/operations/maintenance/indexes/stop-indexing). 
The same way you can resume it (the operation to start indexing can be found [here](../../client-api/operations/maintenance/indexes/start-indexing)).

You can also stop and start a single index. The Client API operations are [StopIndex](../../client-api/operations/maintenance/indexes/stop-index) and 
[StartIndex](../../client-api/operations/maintenance/indexes/start-index).

{NOTE: }
Indexing will be resumed automatically after a server restart.
{NOTE /}

Operation scope: Local node

## Disable & Enable

Disabling an index can be done via [the Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) 
or the Client API operations: [DisableIndex](../../client-api/operations/maintenance/indexes/disable-index), [EnableIndex](../../client-api/operations/maintenance/indexes/enable-index). 

{NOTE: }
Querying a disabled index is allowed but it may return stale results. Unlike stopping the index (pausing), disabling is a persistent operation so the index remains disabled 
even after a server restart.
{NOTE /}

Operation scope: Local node

## Reset

An index usually needs to be reset once it reached its error quota and its state was changed to `Error`. Resetting an index means forcing RavenDB to re-index all documents
matched by the index definition (can be a lengthy process on large databases).

You can reset an index using [the Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) or [the Client API](../../client-api/operations/maintenance/indexes/reset-index).

Operation scope: Local node

## Delete

You can delete an index by using [the Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) 
or [the Client API](../../client-api/operations/maintenance/indexes/delete-index).

Operation scope: Cluster

## Lock Mode

This feature applies to changing the index definition on a production server.  

An index can be in one of the following locking modes:  
* ***Unlocked*** - Any change to the index defintion is applied.  
* ***LockedIgnore*** - Modifications to the index definition will _not_ be applied. Changes are ignored and no error is thrown.  
* ***LockedError*** - Modifications are ignored but an _error_ is raised.  

A typical flow can be:

1. Update the index definition on RavenDB server (from studio or from a new application version),  
   and then set the index Lock Mode to `LockedIgnore` or `LockedError`.  

2. A side-by-side index is created on the server. It indexes your dataset according to the new definition.  

3. While the original index is locked, if any instance of your previous application version (that has the older definition) is restarted, 
   calling IndexCreation.CreateIndexes() on start up, this will ***not*** have any effect on the new index definition.  
   Note: If 'LockedError' was set, then an error will be raised.  

4. Once the side-by-side index is done indexing, the original index will be replaced and you can safely deploy your new application to production.  

To lock the index you can use the [Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) 
or the [Client API](../../client-api/operations/maintenance/indexes/set-index-lock).  
Note: This is not a security feature, an index can be unlocked at any time.  

Operation scope: Cluster  

## Priority

Each index has a dedicated thread that handles all the work for the index. RavenDB uses thread priorities at the operating system level to hint what
should be done first. You can increase or lower the index priority and RavenDB will update the indexing thread accordingly:


| RavenDB Index Priority | OS Thread Priority |
| --- | ------ |
| Low | Lowest |
| Normal (default) | BelowNormal |
| High | Normal |

You can change the index priority by using [the Studio](../../studio/database/indexes/indexes-list-view#indexes-list-view---actions) 
or [the Client API](../../client-api/operations/maintenance/indexes/set-index-priority).

{NOTE:Expert configuration options}

You can control the affinity of indexing threads and number of cores that _won't_ be used by indexes via the following configurations:

- [Server.IndexingAffinityMask](../../server/configuration/server-configuration#server.indexingaffinitymask)
- [Server.NumberOfUnusedCoresByIndexes](../../server/configuration/server-configuration#server.numberofunusedcoresbyindexes)

Operation scope: Cluster

{NOTE/}

## Related Articles

### Indexes

- [Indexes Overview](../../studio/database/indexes/indexes-overview#indexes-overview)
- [What are Indexes](../../indexes/what-are-indexes)

### Troubleshooting

- [Debugging Index Errors](../../indexes/troubleshooting/debugging-index-errors)
