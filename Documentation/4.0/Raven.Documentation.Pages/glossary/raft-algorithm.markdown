# Glossary: Raft Consensus Algorithm

### What is Raft?

Raft is a [distributed consensus](https://en.wikipedia.org/wiki/Consensus_(computer_science)) algorithm designed to be understandable and durable. 

In general, the algorithm is useful when we want to order the events that happen in a distributed system on different nodes.

In RavenDB, Raft is used to coordinate the execution of cluster-wide operations over the nodes. 

If we want to create a database in a cluster, creating the database on all cluster nodes, the Raft will be used to make sure that the database creation is executed in at least (n/2) + 1 nodes. (quorum of nodes)

### Additional Reading

 * A website with visualization and links to publications -> [https://raft.github.io/](https://raft.github.io/)
 * A link to the original PhD dissertation on Raft Algorithm -> [https://github.com/ongardie/dissertation](https://github.com/ongardie/dissertation)
 * Visualization and simple tutorial on how Raft works -> [http://thesecretlivesofdata.com/raft/](http://thesecretlivesofdata.com/raft/)
