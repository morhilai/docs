# Commands: Querying: How to query a database?

Use **Query** method to fetch results of a selected index according to a specified query.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverName}/databases/{databaseName}/indexes/{indexName}? \
		&metadata-only={metadataOnly} \
		&include={include} \
		[Other indexQuery parameters] \
	-X GET
{CODE-BLOCK/}

{SAFE:IndexQuery parameters}
This endpoint accepts [IndexQuery](../../../glossary/index-query) object. All possible [IndexQuery](../../../glossary/index-query) parameters are listed [here](../../../client-api/commands/querying/how-to-query-a-database#indexquery-parameters)
{SAFE/}

## IndexQuery parameters

The table below descibes allowed request parameters which can be passed as a part on IndexQuery.

| Query parameter | Required | Allow multiple | Default value | Description |
| --------------- | -------- | ------------- | ----------- |
| **query** | no | no | `&quot;&quot;` | Index query (in lucene syntax) |
| **start** | no | no | `0` | The start of records to read |
| **cutoff** | no | no | `null` | The cutoff date |
| **waitForNonStaleResultsAsOfNow** | no | no | `false` | the WaitForNonStaleResultsAsOfNow |
| **cutOffEtag** | no | no | `null` | Cutoff etag is used to check if the index has already process a document with the given etag. Unlike Cutoff, which uses dates and is susceptible to clock synchronization issues between machines, cutoff etag doesn't rely on both the server and client having a synchronized clock and can work without it. However, when used to query map/reduce indexes, it does NOT guarantee that the document that this etag belong to is actually considered for the results. What it does it guarantee that the document has been mapped, but not that the mapped values has been reduce. Since map/reduce queries, by their nature,tend to be far less susceptible to issues with staleness, this is considered to be an acceptable tradeoff. If you need absolute no staleness with a map/reduce index, you will need to ensure synchronized clocks and use the Cutoff date option, instead. |
| **pageSize** | no | no | `25` | The page size |
| **fetch** | no | yes | `null` | The fields names to fetch |
| **defaultField** | no | no | `null` | The default field to use when querying directly on the Lucene query |
| **operator** | no | no | `or` | Changes the default operator mode we use for queries. When set to Or a query such as 'Name:John Age:18' will be interpreted as: Name:John OR Age:18 When set to And the query will be interpreted as: Name:John AND Age:18 |
| **sort** | no | yes | `null` | The sort fields by sort by |
| **highlight** | no | yes | `null` | The options to highlight the fields |
| **preTags** | no | yes | `null` | The highlighter pre tags |
| **postTags** | no | yes | `null` | The highlighter post tags |
| **resultsTransformer** | no | no | `null` |  The results transformer |
| tp-{param}={value} | no | yes | `null` | Additional transformer parameters |
| **explainScores** | no | no | `false` | Whatever a query result should contains an explanation about how docs scored against query |
| SortHint-{param}={value} | no | yes | `null` | The sort hints |
| **distinct** | no | no | `false` | Whatever we should apply distinct operation to the query on the server side |
| **allowMultiple IndexEntriesForSameDocument ToResultTransformer** | no | no | `true` | If set to true, this property will send multiple index entries from the same document (assuming the index project them) to the result transformer function. Otherwise, those entries will be consolidate an the transformer will be called just once for each document in the result set |
| **showTimings** | no | no | `false` | Indicates if detailed timings should be calculated for various query parts (Lucene search, loading documents, transforming results) |
| **spatialField** | no | no | `__spatial` | Spatial field name |
| **queryShape** | no | no | `null` | Spatial query shape |
| **spatialUnits** | no | no | `Kilometers` | Spatial units |
| **distErrPrc** | no | no | `0.025` | Distance error percentage |
| **spatialRelation** | no | no | `null` | Spatial relation |

### Request

| Query parameter | Required | Description  |
| ------------- | -- | ---- |
| **indexName** | Yes | A name of an index to query |
| **include** | No | An array of relative paths that specify related documents ids which should be included in a query result. |
| **metadataOnly** | No | True if returned documents should include only metadata without a document body. |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **Results** | List of requested documents |
| **Includes** | List of included documents |

<hr />

## Example I

A sample **Query** method call that returns orders for a company specified:

{CODE-BLOCK:json}
curl -X GET "http://localhost:8080/databases/NorthWind/indexes/Orders/Totals?&query=Company%3Acompanies%2F1&pageSize=128" 
< HTTP/1.1 200 OK
{"Results":[...results ...],"Includes":[]}
{CODE-BLOCK/}

## Example II

If a model of your documents is such that they reference others and you want to retrieve them together in a single query request, then you need to specify paths to properties that contain IDs of referenced documents:

{CODE-BLOCK:json}
curl -X GET "http://localhost:8080/databases/NorthWind/indexes/Orders/Totals?&pageSize=128&include=Company&include=Employee" 
< HTTP/1.1 200 OK
{"Results":[...results ...],"Includes":[... includes ...]}
{CODE-BLOCK/}

## Related articles

- [Full RavenDB query syntax](../../../indexes/querying/full-query-syntax) 
- [How to **stream query** results?](../../../client-api/commands/querying/how-to-stream-query-results)
