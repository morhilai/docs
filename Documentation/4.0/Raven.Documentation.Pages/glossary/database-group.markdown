#Glossary: Database Group

### What is a database group?
When a database is created in a [RavenDB Cluster](./ravendb-cluster), we can choose a subset of nodes it would exist on.
Between the nodes of a database group, there is an active master-master replication.

For example:
Assuming we have three-node RavenDB Cluster - nodes A, B and C, we can create a database with replication factor 2, and
it can be located on B and C nodes. In this setup, between the database on B and C a master-master replication will be active.
