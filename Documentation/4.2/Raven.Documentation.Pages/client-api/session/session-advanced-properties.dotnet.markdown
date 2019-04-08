{PANEL: `session.Advanced`}

The session.Advanced properties

| Method | Return Value | Description |
|---|---|---|
| Clear | void | Removes all entities from the delete queue and stops tracking changes for all entities |
| Defer | void | Defer commands to be executed on `SaveChanges()` |
| DocumentQuery<> | IDocumentQuery<T> | Query the specified index using Lucene syntax |
| Evict<> | void | Removes the specified entity from the delete queue and stops tracking changes for that entity |
| Exists | boolean | Checks whether a document exists in the database |
| GetChangeVectorFor<> | string | Gets the current change-vector for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetCountersFor<> | List<string> | Gets all the counter names for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetCurrentSessionNode | Task<ServerNode> | Gets the server node this session is associated with, as determined by the read balance behavior |
| GetDocumentId | string | Gets the document id for the specified entity. May return `null` if the entity is not tracked by the session, or if the entity doesn't have an id yet |
| GetLastModifiedFor<> | DateTime? | Gets last modified date for the specified entity. Throws an exception if the entity is not tracked by the session. |
| GetMetadataFor<> | IMetadataDictionary | Gets the metadata for the specified entity. Throws an exception if the entity is not tracked by the session. |
| HasChanged | boolean | Determines whether the specified entity has changed |
| IgnoreChangesFor | void | Stops change tracking for the specified entity and skips it when `SaveChanges` is called |
| Increment<> | void | _**TODO**_ |
| IsLoaded | boolean | Checks whether a document with the specified id is loaded in the current session |
| LoadIntoStream | void | Loads the entities with the specified ids directly into a given stream |
| LoadStartingWith<> | T[] | Loads multiple entities that contain the specified prefix |
| LoadStartingWithIntoStream | void | Loads multiple entities that contain the specified prefix into a given stream |
| Patch<> |
| RawQuery<>
| Refresh<>
| SetTransactionMode
| Stream<>
| StreamInto<>
| WaitForIndexesAfterSaveChanges
| WaitForReplicationAfterSaveChanges
| WhatChanged



{PANEL/}
