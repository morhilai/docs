# Configuration: Hot Spare License

One of the most important features in RavenDB is replication, and the ability to use a 
replica node to get high availability and load balancing across all nodes.

Some users choose to run on a single instance, or want to have a hot backup, but don't need 
the high availability mode - that's what hot spare is for.

A hot spare is a RavenDB node that is available only as a replication target. It cannot be 
used for answering queries or talking with clients, but it will get all the data from your 
server and keep it safe.

If there is a failure of the main node , an admin can activate the hot spare, 
which will turn the hot spare license into a normal license for a period of 96 hours. At that 
point, the RavenDB server will behave normally as a standard server, clients will be able to 
failover to it, etc. After the 96 hours are up, it will revert back to hot spare mode, but the 
administrator will not be able to activate it again without purchasing another hot spare license.

{NOTE: Remarks}
- Server can be only be used as a replication destination (master-slave scenario)  
- There is a one-time option to activate the license, which will enable all features for a period of 96 hours  
- The license includes an option of testing the activiation for a short period, for operational testing  
{NOTE/}

{NOTE: Hot Spare behaviour under clustering}
- If not activated, the hot spare node will not have voting priviliges, thus it cannot be considered for a quorum.   
- After activation, the hot spare node becomes promotable and can be elected as a leader. When activation expires, 
if the hot spare node is the leader, it will gracefully (notifying the other cluster nodes) step down.   
{NOTE/}

## Related articles

- [Studio: Activating the Hot Spare](../../studio/management/hot-spare)
