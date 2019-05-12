# Ongoing Tasks: External Replication

We call the task of replicating between two different database groups _external replication_.  
There is actually no difference in the implementation of an _external replication_ and a regular replication process.  
The reason we define them differently is because of the default behavior of a cluster to setup well connected _database groups_.  
This may be limiting if you wish to design your own replication topology and _external replication_ is the solution for those unique cases.  

## Delayed Replication

In RavenDB we introduced a new kind of replication, _delayed replication_, what it does is replicating data that is delayed by `X` amount of time.  
The _delayed replication_ works just like normal replication but instead of sending data right away it waits `X` amount of time.  
Having a delayed instance of a database allows you to "go back in time" and undo contamination to your data due to a faulty patch script or other human errors.  
While you can and should always use backup for those cases, having a live database makes it super fast to failover to and prevent business lose while you take down the faulty databases and restore them.  

## Related articles

### Replication

- [How Replication Works](../../server/clustering/replication/replication)
