# Glossary: QueryResult

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Results** | List&lt;RavenJObject&gt; | The document resulting from this query |
| **Includes** | List&lt;RavenJObject&gt; | The document included in the result |
| **IsStale** | bool | A value indicating whether the index is stale |
| **IndexTimestamp** | DateTime | The last time the index was updated |
| **TotalResults** | int | The total results for this query |
| **SkippedResults** | int | The skipped results |
| **IndexName** | string | The index used to answer this query |
| **IndexEtag** | Etag | The last etag indexed by the index. This can be used to determine whatever the results can be cached. |
| **ResultEtag** | Etag |  The ETag value for this index current state, which include what we docs we indexed, what document were deleted, etc. |
| **Highlightings** | Dictionary&lt;string, Dictionary&lt;string, string[]&gt;&gt; | The highlighter results |
| **NonAuthoritativeInformation** | bool | A value indicating whether any of the documents returned by this query are non authoritative (modified by uncommitted transaction). |
| **LastQueryTime** | DateTime | The timestamp of the last time the index was queried |
| **DurationMilliseconds** | long | The duration of actually executing the query server side |
| **ScoreExplanations** | Dictionary&lt;string, string&gt; | The explanations of document scores |
| **TimingsInMilliseconds** |  Dictionary&lt;string, double&gt; | Detailed timings for various parts of a query (Lucene search, loading documents, transforming results) |
| **ResultSize** | long | The size of the request which were sent from the server. This value is the _uncompressed_ size.  |
