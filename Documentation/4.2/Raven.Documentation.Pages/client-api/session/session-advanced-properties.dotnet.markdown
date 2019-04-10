{PANEL: `session.Advanced`}

The session.Advanced properties

| Method | Return Value | Description |
|---|---|---|
| [Clear](../../client-api/session/how-to/clear-a-session) | void | Removes all entities from the delete queue and stops tracking changes for all entities |
| [Defer](../../client-api/session/how-to/defer-operations) | void | Defer commands to be executed on `SaveChanges()` |
| [DocumentQuery<>](../../client-api/session/querying/document-query/what-is-document-query) | IDocumentQuery<T> | Query the specified index using Lucene syntax |
| Evict<> | void | Removes the specified entity from the delete queue and stops tracking changes for that entity |
| Exists | boolean | Checks whether a document exists in the database |
| GetChangeVectorFor<> | string | Gets the current change-vector for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetCountersFor<> | List<string> | Gets all the counter names for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetCurrentSessionNode | Task<ServerNode> | Gets the server node this session is associated with, as determined by the read balance behavior |
| GetDocumentId | string | Gets the document id for the specified entity. May return `null` if the entity is not tracked by the session, or if the entity doesn't have an id yet |
| GetLastModifiedFor<> | DateTime? | Gets last modified date for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetMetadataFor<> | IMetadataDictionary | Gets the metadata for the specified entity. Throws an exception if the entity is not tracked by the session. |
| HasChanged * boolean | Determines whether the specified entity has changed |
| IgnoreChangesFor | void | Stops change tracking for the specified entity and skips it when `SaveChanges` is called |
| Increment<> | void | Without loading a document from the server into the session, sends a request to increment the specified field in the specified document by a given value. If the field is a string the given value will be concatenated onto the field's current value. Request is sent when `SaveChanges()` is called. |
| IsLoaded | boolean | Checks whether a document with the specified id is loaded in the current session |
| LoadIntoStream | void | Loads the entities with the specified ids directly into a given stream |
| LoadStartingWith<> | T[] | Loads multiple entities that contain the specified prefix |
| LoadStartingWithIntoStream | void | Loads multiple entities that contain the specified prefix into a given stream |
| Patch<> | void | Without loading a document from the server into the session, sends a request to modify the specified field in the specified document according to a given lambda expression. Request is sent when `SaveChanges()` is called. |
| RawQuery<> | void | Query the specified index using the provided [Raw Query](../../client-api/session/querying/how-to-query#session.advanced.rawquery) written in [RQL](../../indexes/querying/what-is-rql) |
| Refresh<> | void | Updates entity with latest changes from server |
| SetTransactionMode | void | Choose between `SingleNode` and `ClusterWide` transaction modes for the current session |
| Stream<> | IEnumerator<StreamResult<T>> | Stream the results of documents search to the client, converting them to CLR types along the way. |
| StreamInto<> | void | Returns the results of a query directly into a given stream |
| WaitForIndexesAfterSaveChanges | void | `SaveChanges()` will wait for the indexes to catch up with the saved changes before returning |
| WaitForReplicationAfterSaveChanges |void | `SaveChanges()` will wait for all changes made to be replicated to `replicas` of the database in other nodes |
| WhatChanged | IDictionary<string, DocumentsChanges[]> | Returns all changes for each entity stored within session. Including name of the field/property that changed, its old and new value and change type. |



{PANEL/}
