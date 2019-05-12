#Glossary: Raft Command

In RavenDB 4.x, all cluster-level operations are essentially [Raft](./raft-algorithm) commands, which actually get executed only if they are applied to Raft log (which means that the commands reached the majority of cluster nodes).

###What is a command?
A Raft implementation is comprised of a state machine and a log. The idea is to ensure the same order of log entries in the state machine (eventually).
A command is an entry in the Raft log.
