# Indexes: Indexing Basics

To achieve very fast response times, RavenDB handles **indexing in the background** whenever data is added or changed. This approach allows the server to respond quickly even when large amounts of data have changed. The only drawback of this choice is that results might be stale (more about staleness in next section). Underneath, the server is using [Lucene](http://lucene.apache.org/) to perform indexation and [Raven Query Language](../indexes/querying/what-is-rql) for querying.

## Stale Indexes

The notion of stale indexes comes from an observation deep in RavenDB's design, assuming that the user should never suffer from assigning the server big tasks. As far as RavenDB is concerned, it is better to be stale than offline, and as such it will return results to queries even if it knows they may not be as up-to-date as possible.

RavenDB returns quickly for every client request, even if involves re-indexing hundreds of thousands of documents. Since the previous request has returned so quickly, the next query can be made a millisecond after that. and results will be returned but they will be marked as `Stale`.

{INFO You can read more about stale indexes [here](../indexes/stale-indexes). /}

## Querying

RavenDB uses `Raven Query Language (RQL)`, an SQL-like querying language for querying. The easiest way for us would be to expose a method in which you could pass your RQL-flavored query as a string (we [did](../client-api/session/querying/how-to-query#session.advanced.rawquery) that) and do not bother about anything else.

The fact is that we did not stop at this point. We went much further, by exposing querying methods that hides all Lucene syntax complexity:

{CODE-TABS}
{CODE-TAB:java:Java indexes_2@Indexes/IndexingBasics.java /}
{CODE-TAB-BLOCK:sql:RQL}
from index 'Employees/ByFirstName'
where FirstName = 'Robert'
{CODE-TAB-BLOCK/}
{CODE-TABS/}

You can also create queries by using [RawQuery](../client-api/session/querying/how-to-query#session.advanced.rawquery). It is available as a part of advanced session operations:

{CODE-TABS}
{CODE-TAB:java:RawQuery indexes_4@Indexes/IndexingBasics.java /}
{CODE-TAB-BLOCK:sql:RQL}
from index 'Employees/ByFirstName'
where FirstName = 'Robert'
{CODE-TAB-BLOCK/}
{CODE-TABS/}

## Types of Indexes

You probably know that indexes can be divided by their source of origin to the `static` and `auto` indexes (if not, read about it [here](../indexes/creating-and-deploying)), but a more interesting division is by functionality. For this case we have `Map` and `Map-Reduce` indexes.

`Map` indexes (sometimes referred as simple indexes) contain one (or more) mapping functions that indicate which fields from documents should be indexed. They indicate which documents can be searched by which fields.

`Map-Reduce` indexes allow complex aggregations to be performed in a two-step process. First by selecting appropriate records (using the Map function), then by applying a specified reduce function to these records to produce a smaller set of results.

{INFO:Map Indexes}
You can read more about `Map` indexes [here](../indexes/map-indexes).
{INFO/}

{INFO:Map-Reduce Indexes}
More detailed information about `Map-Reduce` indexes can be found [here](../indexes/map-reduce-indexes).
{INFO/}

## Related Articles

### Indexes

- [Map Indexes](../indexes/map-indexes)
- [Stale Indexes](../indexes/stale-indexes)
- [What are Indexes](../indexes/what-are-indexes)
- [Creating and Deploying Indexes](../indexes/creating-and-deploying)

### Querying

- [Basics](../indexes/querying/basics)
- [What is RQL](../indexes/querying/what-is-rql)

### Studio

- [Indexes Overview](../studio/database/indexes/indexes-overview#indexes-overview)
- [Studio Indexes List View](../studio/database/indexes/indexes-list-view)
