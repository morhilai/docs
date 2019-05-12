# KB: Replication: Advanced replication details

An activation of the replication bundle has an impact on how your database acts. There are some internal procedures that are executed only if this module is enabled. Note that is it enough if the bundle is active, it doesn't have to be configured to indicate any destination node. Below the implications of active replication that you should be aware of are listed.

## Activating bundle

The replication bundle provides a mechanism to detect if a document was modified and if there is a need to propagate it to a destination, but it also handles the replication on a destination database. So you have to remember about an activation of the replication bundle in both databases.

## Influence on metadata

The replication module arrives with triggers performed on every PUT operation. They take care of tracking an ancestry of a document (or an attachment) and building its history when it moves between database instances. 
This information is stored in metadata under special system keys:

* *Raven-Replication-Version* that describes a file version in a database,
* *Raven-Replication-Source* which is a database identifier where a file was put,
* *Raven-Replication-History* where old pairs of source and version are collected.

As already mentioned, these values are added to metadata only if the replication is active.
The scenario for enabling database replication when documents are already there is not supported.

## History

A destination RavenDB instance uses history of a replicated document to detect if there is a conflict. The more edits of the document are made, the longer history it has. RavenDB tracks history of last 50 document's modifications. After exceeding this value history is trimmed. Notice that might cause document conflicts even if Master/Slave configuration was applied. Each edit of a document pushes a last history item out of a history list. When it happens more than 50 times to the same document between two replication cycles, history will contain only information about new changes that the destination database has never seen. The destination will not be able to detect that its document is an ancestor of a replicated document and will make the conflict.

## Tombstones

In RavenDB there is a concept of tombstone that represents a deleted document. Every document delete operation entails to store a tombstone document. This mechanism is used by the replication and it works only if the replication bundle is active. The stored tombstone documents are used to reflect a delete document operation on a destination database. Although the tombstones are created in a different storage area than the documents, they are still included in database statistics, that's why the document count does not decrease after a delete if the replication is enabled.

## Related articles

- [Replication](../scaling-out/replication/how-replication-works)
