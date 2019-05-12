# Glossary: MoreLikeThisQuery

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **MinimumTermFrequency** | int? | Ignore terms with less than this frequency in the source doc. Default is `2`. |
| **MinimumDocumentFrequency** | int? | Ignore words which do not occur in at least this many documents. Default is `5`. |
| **MaximumDocumentFrequency** | int? | Ignore words which occur in more than this many documents. Default is `Int32.MaxValue`. |
| **MaximumDocumentFrequencyPercentage** | int ? | Ignore words which occur in more than this percentage of documents. |
| **Boost** | bool? | Boost terms in query based on score. Default is `false`. |
| **BoostFactor** | float? | Boost factor when boosting based on score. Default is `1`. |
| **MinimumWordLength** | int? | Ignore words less than this length or if 0 then this has no effect. Default is `0`. |
| **MaximumWordLength** | int? | Ignore words greater than this length or if 0 then this has no effect. Default is `0`. |
| **MaximumQueryTerms** | int? | Return a Query with no more than this many terms. Default is `25`. |
| **MaximumNumberOfTokensParsed** | int ? | The maximum number of tokens to parse in each example doc field that is not stored with TermVector support. Default is `5000`. |
| **StopWordsDocumentId** | string | The document id containing the custom stop words |
| **Fields** | string[] | The fields to compare |
| **DocumentId** | string | The document id to use as the basis for comparison |
| **IndexName** | string | The name of the index to use for this operation |
| **AdditionalQuery** | string | An additional query that the matching documents need to also match to be returned |
| **MapGroupFields** | NameValueCollection | Values for the the mapping group fields to use as the basis for comparison |
| **ResultsTransformer** | string | The results transformer |
| **Includes** | string[] | The includes |
| **TransformerParameters** | Dictionary&lt;string, RavenJToken&gt; | Additional transformer parameters |
