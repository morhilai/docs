# Glossary: RavenQueryStatistics

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **IsStale** | bool | Whatever the query returned potentially stale results |
| **DurationMilliseconds** | long | The duration of the query _server side_ |
| **TotalResults** | int | What was the total count of the results that matched the query |
| **SkippedResults** | int | The amount of skipped results |
| **Timestamp** | DateTime | The time when the query results were unstale |
| **IndexName** | string | The name of the index queried |
| **IndexTimestamp** | DateTime | The timestamp of the queried index |
| **IndexEtag** | Etag | The etag of the queried index |
| **NonAuthoritativeInformation** | bool | A value indicating whether any of the documents returned by this query are non authoritative (modified by uncommitted transaction) |
| **LastQueryTime** | DateTime |  The timestamp of the last time the index was queried |
| **TimingsInMilliseconds** | Dictionary&lt;string, double&gt; |  Detailed timings for various parts of a query (Lucene search, loading documents, transforming results) |
| **ResultSize** | long | The size of the request which were sent from the server. This value is the _uncompressed_ size. |
| **ScoreExplanations** | Dictionary&lt;string, string&gt; | Explanations of document scores |

