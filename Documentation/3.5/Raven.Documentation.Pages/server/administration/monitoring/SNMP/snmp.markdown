# Monitoring: SNMP Support

Simple Network Management Protocol (SNMP) is an Internet-standard protocol for collecting and organizing information 
about managed devices on IP networks, and is used primarily for monitoring network services. SNMP exposes management 
data in the form of variables (metrics) which describe the system status and configuration. These metrics can then be 
remotely queried (and, in some circumstances, manipulated) by managing applications.

In RavenDB 3.5 we added support for SNMP which allows monitoring tools like [Zabbix](https://www.zabbix.com), [PRTG](https://www.paessler.com/prtg) 
and [Datadog](https://www.datadoghq.com/) direct access to the internal details of RavenDB. We expose a long list of metrics: CPU and memory usage,
server total requests, the loaded databases... And also database specific metrics like the number of indexed items per 
second, document writes per second, storage space each database takes and so on. The full list can be found [here](https://github.com/ravendb/ravendb/blob/v3.5/Raven.Database/Plugins/Builtins/Monitoring/Snmp/Templates/RAVENDB-MIB.txt).

You can still monitor what is going on with RavenDB directly from the studio, or by using one of our monitoring tools, 
but using SNMP might be easier in some cases. As users start running large numbers of RavenDB instances, it 
becomes unpractical to deal with each of them individually and using a monitoring system that can watch many servers 
is preferable.

{NOTE:Note}
SNMP support is available for enterprise licenses only.
{NOTE/}


### Enabling SNMP in RavenDB

RavenDB 3.5 is already configured to support SNMP and all you have to do is enable it and restart the server. 
This is done by adding the following key to your app.config/web.config in the appSettings section:
{CODE-BLOCK:plain}
<configuration>
    <appSettings>
        <add key="Raven/Monitoring/Snmp/Enabled" value="true" />
{CODE-BLOCK/}

There are two configurable SNMP properties in RavenDB: the SNMP port and the community string.   
The default community string is "ravendb" and the default port is 161. 
You can change those with the following configuration keys:
{CODE-BLOCK:plain}
<add key="Raven/Monitoring/Snmp/Port" value="12345" />
<add key="Raven/Monitoring/Snmp/Community" value="YourString" />
{CODE-BLOCK/}

The community string is used like a password. It is sent with each SNMP Get request and 
allows or denies access to the monitored device.

### The Metrics

It is usually easy to query the exposed metrics using a monitoring tool. ([Example](./setup-zabbix)).   
However, you should also be able to access those directly using any SNMP agent like [Net-SNMP](http://net-snmp.sourceforge.net/).   

The most basic SNMP commands are `snmpget`, `snmpset` and `snmptrapd` ([Read more](http://net-snmp.sourceforge.net/tutorial/tutorial-5/commands/)).   

Each metric has a unique identifier (OID) and can be accessed individually.   
For example, using the SNMP agent you could run the following snmpget command which gets the server up time metric:
{CODE-BLOCK:plain}
snmpget -v 2c -c ravendb live-test.ravendb.net 1.3.6.1.4.1.45751.1.1.1.2
snmpget -v 3 -l authNoPriv -u ravendb -a SHA -A ravendb live-test.ravendb.net 1.3.6.1.4.1.45751.1.1.1.2
{CODE-BLOCK/}

Where "ravendb" is the community string and "live-test.ravendb.net" is the host.

![Figure 7. Monitoring : How to setup Zabbix monitoring: snmpget result](images/monitoring-zabbix-snmpget.PNG) 

For your convenience we've also added the list of metrics and their associated OIDs here:   

RavenDB's root OID id: 1.3.6.1.4.1.45751.1.1.

| OID | Metric |
| --- | ------ |
|1. |Server |  
|1.1. |Server name |
|1.2. |Server up time |
|1.3. |Server build version |
|1.4. |Server product version |
|1.5. |Server PID |
|1.6.1. |Server concurrent requests |
|1.6.2. |Server total requests |
|1.7. |Server CPU |
|1.8.1 |Server total memory |
|1.9. |Server url |
|1.10 |Server indexing errors (global) |
|5. |Resources | 
|5.1.1 |Database total count |
|5.1.2 |Database loaded count |
|5.2.X |Database |
|5.2.X.1. |Database statistics |
|5.2.X.1.1 |Database name |
|5.2.X.1.2 |Database count of indexes |
|5.2.X.1.3 |Database stale count |
|5.2.X.1.4 |Database count of transformers |
|5.2.X.1.5 |Database approximate task count |
|5.2.X.1.6 |Database count of documents |
|5.2.X.1.7 |Database count of attachments |
|5.2.X.1.8 |Database CurrentNumberOfItemsToIndexInSingleBatch |
|5.2.X.1.9 |Database CurrentNumberOfItemsToReduceInSingleBatch |
|5.2.X.1.10 |Database errors (count) |
|5.2.X.1.11 |Database id |
|5.2.X.1.12 |Database active bundles |
|5.2.X.1.13 |Database loaded |
|5.2.X.2. |Database storage statistics |
|5.2.X.2.1. |Database transactional storage allocated size |
|5.2.X.2.2. |Database transactional storage used size |
|5.2.X.2.3. |Database index storage size |
|5.2.X.3.4. |Database total size |
|5.2.X.2.5. |Database transactional storage drive remaining space |
|5.2.X.2.6. |Database index storage drive remaining space |
|5.2.X.3. |Database metrics |
|5.2.X.3.1. |Database docs write per second |
|5.2.X.3.2. |Database indexed per second |
|5.2.X.3.3. |Database reduced per second |
|5.2.X.3.4. |Database requests |
|5.2.X.3.4.1. |Database requests per second |
|5.2.X.3.4.2. |Database requests duration |
|5.2.X.3.4.2.1. |Database requests duration last minute avg |
|5.2.X.3.4.2.2. |Database requests duration last minute max |
|5.2.X.3.4.2.3. |Database requests duration last minute min |
|5.2.X.4. |Database indexes |
|5.2.X.4.Y. |Index |
|5.2.X.4.Y.1. |Index exists |
|5.2.X.4.Y.2. |Index name |
|5.2.X.4.Y.3. |Index id |
|5.2.X.4.Y.4. |Index priority |
|5.2.X.4.Y.5. |Indexing attempts |
|5.2.X.4.Y.6. |Indexing successes |
|5.2.X.4.Y.7. |Indexing errors |
|5.2.X.4.Y.8. |Reduce indexing attempts |
|5.2.X.4.Y.9. |Reduce indexing successes |
|5.2.X.4.Y.10. |Reduce indexing errors |
|5.2.X.4.Y.11. |Time since last query |
|5.2.X.5. |Database index statistics |
|5.2.X.5.1. |Number of indexes |
|5.2.X.5.2. |Number of static indexes |
|5.2.X.5.3. |Number of auto indexes |
|5.2.X.5.4. |Number of idle indexes |
|5.2.X.5.5. |Number of abandoned indexes |
|5.2.X.5.6. |Number of disabled indexes |
|5.2.X.5.7. |Number of error indexes |
|5.2.X.6. |Database bundles |
|5.2.X.6.1. |Replication bundle |
|5.2.X.6.1.1. |Replication active |
|5.2.X.6.1.2.Y. |Replication destinations |
|5.2.X.6.1.2.Y.1. |Replication destination enabled |
|5.2.X.6.1.2.Y.2. |Replication destination url |
|5.2.X.6.1.2.Y.3. |Time since last replication |

### Templates

For easier setup, we have prepared a few templates for monitoring tools which can be found [here](https://github.com/ravendb/ravendb/tree/v3.5/Raven.Database/Plugins/Builtins/Monitoring/Snmp/Templates).   
These templates include the metrics and their associated OIDs.

## Related articles

- [Monitoring: How to setup Zabbix monitoring](./setup-zabbix)
