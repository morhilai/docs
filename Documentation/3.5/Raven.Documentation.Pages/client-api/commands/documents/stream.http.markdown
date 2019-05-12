# Commands: Documents: Stream

**StreamDocs** is used to stream documents which match chosen criteria from a database.


### Syntax

{CODE-BLOCK:json}
 curl \
	http://{serverName}/databases/{databaseName}/streams/docs? \
		etag={etag}& \
		startsWith={startsWith}& \
		matches={matches}& \
		exclude={exclude}& \
		skipAfter={skipAfter}& \
		start={start}& \
		pageSize={pageSize} \
	-X GET 
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **etag** | No | ETag of a document from which stream should start (mutually exclusive with 'startsWith') |
| **startsWith** | No | prefix for which documents should be streamed (mutually exclusive with 'etag') |
| **matches** | No | pipe ('&#124;') separated values for which document keys (after 'keyPrefix') should be matched ('?' any single character, '*' any characters) |
| **exclude** | No | pipe ('&#124;') separated values for which document keys (after 'keyPrefix') should **not** be matched ('?' any single character, '*' any characters) |
| **skipAfter** | No | skip document fetching until given key is found and return documents after that key |
| **start** | No | number of documents that should be skipped |
| **pageSize** | No | maximum number of documents that will be retrieved |

| Header | Required | Description |
| --------| ------- | --- |
| **Single-Use-Auth-Token** | No | Required if authentication is enabled. |


### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **Results** | list of json documents |

<hr />

### Example

Streams products.

{CODE-BLOCK:json}
curl -X GET "http://localhost:8080/databases/NorthWind/streams/docs?startsWith=products%2F"
< HTTP/1.1 200 OK
{"Results": [ jsonDocument, jsonDocument, ... ] }

{CODE-BLOCK/}

## Related articles

- [How to use **startsWith**, **matches** and **exclude**?](../../../client-api/commands/documents/get#startswith)  
- [Get](../../../client-api/commands/documents/get)  
