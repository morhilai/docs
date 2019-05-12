#Commands: GetConflicts

The **GET** method retrieves the existing conflict items.

{INFO: Conflicts location}
Conflicts always exist in a destination file system.
{INFO/}

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/synchronization/conflicts  \
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
| **JSON** | The `ItemsPage` object that contains the number of total results and the list of [`ConflictItem`](../../../../../glossary/conflict-item) objects that represent the synchronization conflict. |

<hr />

## Example

{CODE-BLOCK:json}
curl \
	-X GET http://localhost:8081/fs/SlaveNorthwindFS/synchronization/conflicts
< HTTP/1.1 200 OK
{
    "TotalCount":1,
    "Items":[
        {
            "RemoteHistory":[
                {
                    "Version":1,
                    "ServerId":"73bf7163-d29c-4c6b-9a52-e2347d51765d"
                },
                {
                    "Version":16385,
                    "ServerId":"73bf7163-d29c-4c6b-9a52-e2347d51765d"
                },
                {
                    "Version":16386,
                    "ServerId":"73bf7163-d29c-4c6b-9a52-e2347d51765d"
                }
            ],
            "CurrentHistory":[
                {
                    "Version":1,
                    "ServerId":"73bf7163-d29c-4c6b-9a52-e2347d51765d"
                },
                {
                    "Version":16385,
                    "ServerId":"73bf7163-d29c-4c6b-9a52-e2347d51765d"
                },
                {
                    "Version":1,
                    "ServerId":"59252a06-9673-4ddb-9e07-66831f879941"
                }
            ],
            "FileName":"/books/Inside.RavenDB.3.0.pdf",
            "RemoteServerUrl":"http://localhost:8080/fs/NorthwindFS"
        }
    ]
}
{CODE-BLOCK/}

## Related articles

- [Synchronization conflicts](../../../../synchronization/conflicts)
