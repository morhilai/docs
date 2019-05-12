# Glossary: Etags

### What are Etags?

RavenDB uses etags to track changes of data. Etags are 64-bit numbers which always increase with each change.
If comparing etags for two versions of the same document on a specific RavenDB instance, the version with a higher etag is more up-to-date.
{NOTE Etags are local to each node and are meaningless in the context of the cluster. /}

### Etags vs. Change Vectors

Both etags and change vectors are used to track document changes. Etags have meaning local to cluster nodes, and change vectors have meaning cluster-wide.

* An etag is only incremented when a document is modified locally
* [Change Vector](../server/clustering/replication/change-vector) may be changed when a document is modified locally or replicated

### Etags In-Depth

In RavenDB, etags track changes on many different types of server entities. 

Etags are used to track changes to the following:

* Documents
* Indexes
* Cluster Topology
* ETL

For developing with the RavenDB client API, etags are not needed. Etags are used as a "building block" of a [Change Vector](../server/clustering/replication/change-vector).

### Etags and Clustering

When looking at etags in the context of a RavenDB cluster, etags are only meaningful within a single database on a specific node.
This means etags are _not_ universally unique per different databases on a single node and are not unique across cluster nodes.
