#Commands: GetPending

The **GET** method returns the information about the files that wait for a synchronization slot to a destination file system.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/synchronization/pending?start={start}&pageSize={pageSize}  \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **start** | No | The number of results that should be skipped |
| **pageSize** | No | The maximum number of results that will be returned |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **JSON** | The `ItemsPage` object that contains the number of total results and the list of the [`SynchronizationDetails`](../../../../../glossary/synchronization-details) objects, which contains info about pending file synchronizations. |

<hr />

## Example

{CODE-BLOCK:json}
curl \
	-X GET http://localhost:8080/fs/NorthwindFS/synchronization/pending  \
< HTTP/1.1 200 OK

{
    "TotalCount":0,
    "Items":[]
}

{CODE-BLOCK/}

