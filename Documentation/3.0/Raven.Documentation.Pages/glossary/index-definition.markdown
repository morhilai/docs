# Glossary: IndexDefinition

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **IndexId** | int | The id of this index |
| **Name** | string | This is the means by which the outside world refers to this index defiintion |
| **LockMode** | IndexLockMode |  The index lock mode |
| **Map** | string | The map function, if there is only one |
| **Maps** | HashSet&lt;string&gt; | All the map functions for this index |
| **Reduce** | string | The reduce function |
| **IsMapReduce** | bool | Gets a value indicating whether this instance is map reduce index definition |
| **IsCompiled** | bool | Whether this instance is compiled |
| **Stores** |  IDictionary&lt;string, FieldStorage&gt; | The stores options |
| **Indexes** | IDictionary&lt;string, FieldIndexing&gt; | The indexing options |
| **SortOptions** | IDictionary&lt;string, SortOptions&gt; | The sort options |
| **Analyzers** | IDictionary&lt;string, string&gt; | The analyzers options |
| **Fields** | IList&lt;string&gt; | The fields that are queryable in the index |
| **Suggestions** | IDictionary&lt;string, SuggestionOptions&gt; | The suggest options |
| **TermVectors** | IDictionary&lt;string, FieldTermVector&gt; | The term vectors options |
| **SpatialIndexes** | IDictionary&lt;string, SpatialOptions&gt; | The spatial options  |
| **MaxIndexOutputsPerDocument** | int? | Index specific setting that limits the number of map outputs that an index is allowed to create for a one source document. If a map operation applied to the one document produces more outputs than this number then an index definition will be considered as a suspicious and the index will be marked as errored. Default value: null means that the global value from Raven configuration will be taken to detect if number of outputs was exceeded. |
| **Type** | string | Index type: `Auto`, `Compiled` or `MapReduce` |
| **DisableInMemoryIndexing** | bool | Prevent index from being kept in memory. Default: false |


