# Glossary: IndexQuery

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **PageSizeSet** | bool | Whatever the page size was explicitly set or still at its default value |
| **IsDistinct** | bool | Whatever we should apply distinct operation to the query on the server side |
| **Query** | string | The query |
| **TotalSize** | Reference&lt;int&gt; | The total size |
| **SortHints** | Dictionary&lt;string, SortOptions&gt; | The sort hints |
| **TransformerParameters** | Dictionary&lt;string, RavenJToken&gt; | Additional transformer parameters |
| **Start** | int | The start of records to read |
| **PageSize** |  int | The page size |
| **FieldsToFetch** | string[] | The fields names to fetch |
| **SortedFields** | SortedField[] | The fields to sort by |
| **Cutoff** | DateTime? | The cutoff date |
| **WaitForNonStaleResultsAsOfNow** | bool | the WaitForNonStaleResultsAsOfNow |
| **WaitForNonStaleResults** | bool | the WaitForNonStaleResults |
| **CutoffEtag** | Etag | Cutoff etag is used to check if the index has already process a document with the given etag. Unlike Cutoff, which uses dates and is susceptible to clock synchronization issues between machines, cutoff etag doesn't rely on both the server and client having a synchronized clock and  can work without it. However, when used to query map/reduce indexes, it does NOT guarantee that the document that this etag belong to is actually considered for the results. What it does it guarantee that the document has been mapped, but not that the mapped values has been reduce.  Since map/reduce queries, by their nature,tend to be far less susceptible to issues with staleness, this is  considered to be an acceptable tradeoff. If you need absolute no staleness with a map/reduce index, you will need to ensure synchronized clocks and  use the Cutoff date option, instead. |
| **DefaultField** | string | The default field to use when querying directly on the Lucene query |
| **DefaultOperator** | QueryOperator | Changes the default operator mode we use for queries. When set to Or a query such as 'Name:John Age:18' will be interpreted as:  Name:John OR Age:18 When set to And the query will be interpreted as: Name:John AND Age:18 |
| **AllowMultipleIndexEntriesForSameDocumentToResultTransformer** | bool | If set to true, this property will send multiple index entries from the same document (assuming the index project them) to the result transformer function. Otherwise, those entries will be consolidate an the transformer will be  called just once for each document in the result set |
| **SkippedResults** | Reference&lt;int&gt; | the number of skipped results. |
| **DebugOptionGetIndexEntries** | bool |  Whatever we should get the raw index queries |
| **HighlightedFields** | HighlightedField[] | The options to highlight the fields |
| **HighlighterPreTags** | string[] |  The highlighter pre tags |
| **HighlighterPostTags** | string[] | The highlighter post tags |
| **ResultsTransformer** | string | The results transformer |
| **DisableCaching** | bool | Whatever we should disable caching of query results |
| **SkipDuplicateChecking** | bool | Allow to skip duplicate checking during queries |
| **ExplainScores** | bool | Whatever a query result should contains an explanation about how docs scored against query |
| **ShowTimings** | bool | Indicates if detailed timings should be calculated for various query parts (Lucene search, loading documents, transforming results). Default: `false` |
	
