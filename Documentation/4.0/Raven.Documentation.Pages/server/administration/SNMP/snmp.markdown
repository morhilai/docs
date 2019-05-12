# Monitoring: SNMP Support

Simple Network Management Protocol (SNMP) is an Internet-standard protocol for collecting and organizing information 
about managed devices on IP networks. It is used primarily for monitoring network services. SNMP exposes management 
data in the form of variables (metrics) which describe the system status and configuration. These metrics can then be 
remotely queried (and, in some circumstances, manipulated) by managing applications.

In RavenDB we have support for SNMP which allows monitoring tools like [Zabbix](https://www.zabbix.com), [PRTG](https://www.paessler.com/prtg) 
and [Datadog](https://www.datadoghq.com/) direct access to the internal details of RavenDB. We expose a long list of metrics: CPU and memory usage,
server total requests, the loaded databases, and also database specific metrics like the number of indexed items per 
second, document writes per second, storage space each database takes, and so on. 

You can still monitor what is going on with RavenDB directly from the Studio, or by using one of our monitoring tools. However, using SNMP might be easier in some cases. 
As users start running large numbers of RavenDB instances, it becomes unpractical to deal with each of them individually and using a monitoring system that can watch many servers is advisable.

{NOTE:Note}
SNMP support is available for enterprise licenses only.
{NOTE/}

### Enabling SNMP in RavenDB

RavenDB is already configured to support SNMP. All you have to do is enable it and restart the server. 
This is done by adding the following key to your [settings.json](../../configuration/configuration-options#json) file:

{CODE-BLOCK:json}
{
    ...
    "Monitoring.Snmp.Enabled": true
    ...
}
{CODE-BLOCK/}

There are two configurable SNMP properties in RavenDB: the SNMP port and the community string.   
The default community string is "ravendb" and the default port is 161. 
You can change those with the following configuration keys:
{CODE-BLOCK:json}
{
    ...
    "Monitoring.Snmp.Port": 12345,
    "Monitoring.Snmp.Community": "YourString"
    ...
}
{CODE-BLOCK/}

The community string is used like a password. It is sent with each SNMP Get request and allows or denies access to the monitored device.

### The Metrics

It is usually easy to query the exposed metrics using a monitoring tool. ([Example](./setup-zabbix)).   
However, you should also be able to access those directly using any SNMP agent like [Net-SNMP](http://net-snmp.sourceforge.net/).   

The most basic SNMP commands are `snmpget`, `snmpset` and `snmptrapd` ([Read more](http://net-snmp.sourceforge.net/tutorial/tutorial-5/commands/)).   

Each metric has a unique identifier (OID) and can be accessed individually.   
For example, using the SNMP agent you could run the following snmpget command which gets the server up time metric:
{CODE-BLOCK:plain}
snmpget -v 2c -c ravendb live-test.ravendb.net 1.3.6.1.4.1.45751.1.1.1.1.1
snmpget -v 3 -l authNoPriv -u ravendb -a SHA -A ravendb live-test.ravendb.net 1.3.6.1.4.1.45751.1.1.1.2
{CODE-BLOCK/}

Where "ravendb" is the community string and "live-test.ravendb.net" is the host.

![Figure 7. Monitoring : How to setup Zabbix monitoring: snmpget result](images/monitoring-zabbix-snmpget.PNG) 

For your convenience we've also added the list of metrics and their associated OIDs here:   

{NOTE:Accessing a list of all available OIDs}
You can list all OIDs along with its description using `{serverUrl}/monitoring/snmp/oids` endpoint.
{NOTE/}

RavenDB's root OID id: 1.3.6.1.4.1.45751.1.1.

| OID | Metric |
| --- | ------ |
| 1.1. |Server |
| 1.1.1 |Server URL |
| 1.1.2 | Server Public URL |
| 1.1.3 | Server TCP URL |
| 1.1.4 | Server Public TCP URL |
| 1.2.1 | Server version |
| 1.2.2 | Server full version |
| 1.3 | Server up-time |
| 1.4 | Server process ID |
| 1.5.1 | Process CPU usage in % |
| 1.5.2 | Machine CPU usage in % |
| 1.6.1 | Server allocated memory in MB |
| 1.7.1 | Number of concurrent requests |
| 1.7.2 | Total number of requests since server startup |
| 1.7.3 | Number of requests per second (one minute rate) |
| 1.8 | Server last request time |
| 1.9.1 | Server license type |
| 1.9.2 | Server license expiration date |
| 1.9.3 | Server license expiration left |
| 3.1.1 | Current node tag |
| 3.1.2 | Current node state |
| 3.2.1 | Cluster term |
| 3.2.2 | Cluster index |
| 3.2.3 | Cluster ID |
| 5.1.1 | Number of all databases |
| 5.1.2 | Number of loaded databases |
| 5.2.X.1.1 | Database name |
| 5.2.X.1.2 | Number of indexes |
| 5.2.X.1.3 | Number of stale indexes |
| 5.2.X.1.4 | Number of documents |
| 5.2.X.1.5 | Number of revision documents |
| 5.2.X.1.6 | Number of attachments |
| 5.2.X.1.7 | Number of unique attachments |
| 5.2.X.1.10 | Number of alerts |
| 5.2.X.1.11 | Database ID |
| 5.2.X.1.12 | Database up-time |
| 5.2.X.1.14 | Number of rehabs |
| 5.2.X.1.13 | Indicates if database is loaded |
| 5.2.X.2.1 | Documents storage allocated size in MB |
| 5.2.X.2.2 | Documents storage used size in MB |
| 5.2.X.2.3 | Index storage allocated size in MB |
| 5.2.X.2.4 | Index storage used size in MB |
| 5.2.X.2.5 | Total storage size in MB |
| 5.2.X.2.6 | Remaining storage disk space in MB |
| 5.2.X.3.1 | Number of document puts per second (one minute rate) |
| 5.2.X.3.2 | Number of indexed documents per second for map indexes (one minute rate) |
| 5.2.X.3.3 | Number of maps per second for map-reduce indexes (one minute rate) |
| 5.2.X.3.4 | Number of reduces per second for map-reduce indexes (one minute rate) |
| 5.2.X.3.5 | Number of requests per second (one minute rate) |
| 5.2.X.3.6 | Number of requests from database start |
| 5.2.X.5.1 | Number of indexes |
| 5.2.X.5.2 | Number of static indexes |
| 5.2.X.5.3 | Number of auto indexes |
| 5.2.X.5.4 | Number of idle indexes |
| 5.2.X.5.5 | Number of disabled indexes |
| 5.2.X.5.6 | Number of error indexes |
| 5.2.X.4.Y.1 | Indicates if index exists |
| 5.2.X.4.Y.2 | Index name |
| 5.2.X.4.Y.4 | Index priority |
| 5.2.X.4.Y.5 | Index state |
| 5.2.X.4.Y.6 | Number of index errors |
| 5.2.X.4.Y.7 | Last query time |
| 5.2.X.4.Y.8 | Index indexing time |
| 5.2.X.4.Y.9 | Time since last query |
| 5.2.X.4.Y.10 | Time since last indexing |
| 5.2.X.4.Y.11 | Index lock mode |
| 5.2.X.4.Y.12 | Indicates if index is invalid |
| 5.2.X.4.Y.13 | Index status |
| 5.2.X.4.Y.14 | Number of maps per second (one minute rate) |
| 5.2.X.4.Y.15 | Number of reduces per second (one minute rate) |

### Templates

For easier setup we have prepared a few templates for monitoring tools which can be found [here](https://github.com/ravendb/ravendb/tree/v4.0/src/Raven.Server/Monitoring/Snmp/Templates).   
These templates include the metrics and their associated OIDs.

## Related Articles

- [Monitoring: How to setup Zabbix monitoring](./setup-zabbix)
