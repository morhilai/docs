# Migration: SNMP

{NOTE The complete list of OID can be found [here](../../server/administration/SNMP/snmp) /}

The table below shows mapping of RavenDB 3.X OIDS to version 4.0.


RavenDB's root OID id: 1.3.6.1.4.1.45751.1.1.

| OID in v3.X | OID in v4.X | Metric |
| --- | --- | ------ |
|1. | 1. | Server |
|1.1. | 1.1.1| Server name |
|1.2 | 1.3 | Server up time |
|1.3 | 1.2.1 | Server build version |
|1.4 | 1.2.2 | Server product version |
|1.5 | 1.4 | Server PID |
|1.6.1 | 1.7.1 | Server concurrent requests |
|1.6.2 | 1.7.2 | Server total requests |
|1.7 | 1.5.1 | Server CPU |
|1.8.1 | n/a | Server total memory |
|1.9. | 1.1.2 or 1.1.4 | Server url |
|1.10 | n/a | Server indexing errors (global) |
|5. | 5. |Resources |
|5.1.1 | 5.1.1 |Database total count |
|5.1.2 | 5.1.2 | Database loaded count |
|5.2.X | 5.2.X |Database |
|5.2.X.1. | 5.2.X.1. | Database statistics |
|5.2.X.1.1 | 5.2.X.1.1 | Database name |
|5.2.X.1.2 | 5.2.X.1.2 | Database count of indexes |
|5.2.X.1.3 | 5.2.X.1.3 | Database stale count |
|5.2.X.1.4 | n/a | Database count of transformers |
|5.2.X.1.5 | n/a | Database approximate task count |
|5.2.X.1.6 | 5.2.X.1.4 | Database count of documents |
|5.2.X.1.7 | 5.2.X.1.6 | Database count of attachments |
|5.2.X.1.8 | n/a | Database CurrentNumberOfItemsToIndexInSingleBatch |
|5.2.X.1.9 | n/a | Database CurrentNumberOfItemsToReduceInSingleBatch |
|5.2.X.1.10 | 5.2.X.1.10 | Database errors (count) |
|5.2.X.1.11 | 5.2.X.1.11 | Database id |
|5.2.X.1.12 | n/a | Database active bundles |
|5.2.X.1.13 | 5.2.X.1.13 | Database loaded |
|5.2.X.2. | 5.2.X.2. | Database storage statistics |
|5.2.X.2.1 | 5.2.X.2.1 | Database transactional storage allocated size |
|5.2.X.2.2 | 5.2.X.2.2 | Database transactional storage used size |
|5.2.X.2.3 | 5.2.X.2.3 or 5.2.X.2.4 | Database index storage size |
|5.2.X.3.4 | 5.2.X.2.5 | Database total size |
|5.2.X.2.5 | 5.2.X.2.6 | Database transactional storage drive remaining space |
|5.2.X.2.6 | 5.2.X.2.6 | Database index storage drive remaining space |
|5.2.X.3. | 5.2.X.3. | Database metrics |
|5.2.X.3.1 | 5.2.X.3.1 | Database docs write per second |
|5.2.X.3.2 | 5.2.X.3.2 or 5.2.X.3.3 | Database indexed per second |
|5.2.X.3.3 | 5.2.X.3.4 | Database reduced per second |
|5.2.X.3.4 | 5.2.X.3 | Database requests |
|5.2.X.3.4.1 | 5.2.X.3.5 | Database requests per second |
|5.2.X.3.4.2. | n/a | Database requests duration |
|5.2.X.3.4.2.1 | n/a | Database requests duration last minute avg |
|5.2.X.3.4.2.2 | n/a | Database requests duration last minute max |
|5.2.X.3.4.2.3 | n/a | Database requests duration last minute min |
|5.2.X.4. | 5.2.X.4 | Database indexes |
|5.2.X.4.Y. | 5.2.X.4.Y. | Index |
|5.2.X.4.Y.1 | 5.2.X.4.Y.1 | Index exists |
|5.2.X.4.Y.2 | 5.2.X.4.Y.2 | Index name |
|5.2.X.4.Y.3 | 5.2.X.4.Y.3 | Index id |
|5.2.X.4.Y.4 | 5.2.X.4.Y.4 | Index priority |
|5.2.X.4.Y.5 | n/a | Indexing attempts |
|5.2.X.4.Y.6 | n/a | Indexing successes |
|5.2.X.4.Y.7 | 5.2.X.4.Y.6 | Indexing errors |
|5.2.X.4.Y.8 | n/a | Reduce indexing attempts |
|5.2.X.4.Y.9 | n/a | Reduce indexing successes |
|5.2.X.4.Y.10 | n/a | Reduce indexing errors |
|5.2.X.4.Y.11 |  5.2.X.4.Y.9 | Time since last query |
|5.2.X.5. | 5.2.X.5. | Database index statistics |
|5.2.X.5.1 | 5.2.X.5.1 | Number of indexes |
|5.2.X.5.2 | 5.2.X.5.2 | Number of static indexes |
|5.2.X.5.3 | 5.2.X.5.3 | Number of auto indexes |
|5.2.X.5.4 | 5.2.X.5.4 | Number of idle indexes |
|5.2.X.5.5 | n/a | Number of abandoned indexes |
|5.2.X.5.6 | 5.2.X.5.5 | Number of disabled indexes |
|5.2.X.5.7 | 5.2.X.5.6 | Number of error indexes |
|5.2.X.6. | n/a | Database bundles |
|5.2.X.6.1. | n/a | Replication bundle |
|5.2.X.6.1.1. | n/a | Replication active |
|5.2.X.6.1.2.Y. | n/a | Replication destinations |
|5.2.X.6.1.2.Y.1 | n/a | Replication destination enabled |
|5.2.X.6.1.2.Y.2 | n/a | Replication destination url |
|5.2.X.6.1.2.Y.3 | n/a | Time since last replication |
