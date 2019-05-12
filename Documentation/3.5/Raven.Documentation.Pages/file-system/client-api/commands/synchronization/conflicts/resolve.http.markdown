#Commands: ResolveConflict

The **PATCH** method resolves the conflict according to the specified conflict resolution strategy.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/synchronization/ResolveConflict/{fileName}?strategy={strategy}  \
	-X PATCH 
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **fileName** | Yes | The file path |
| **strategy** | Yes | The strategy -  `1` (RemoteVersion) or `2` (CurrentVersion) |

### Response

| Status code | Description |
| ----------- | - |
| `204` | NoContent |

<hr />


## Example I

If you want to keep the destination file version, you need to resolve the conflict by using a `CurrentVersion` strategy. 
That will force the history of remote file to be incorporated into the local one, so the next attempt to synchronize the file will result in no operation, as it will appear that the file was already synchronized.

{CODE-BLOCK:json}
curl \
	-X PATCH http://localhost:8081/fs/SlaveNorthwindFS/synchronization/ResolveConflict/books/Inside.RavenDB.3.0.pdf?strategy=2
< HTTP/1.1 204 NoContent

{CODE-BLOCK/}

## Example II

The second option is to resolve the conflict in favor of the source file version. In this case, you need to set a `RemoveVersion` strategy.
In contrast to the usage of the `CurrentVersion` strategy, the conflict will not disappear right after applying the `RemoveVersion` resolution, as the destination file system never requests any data from the source file system.

This operation will simply add an appropriate metadata record to the conflicted file (`Raven-Synchronization-Conflict-Resolution`) to allow the source file system to synchronize its version in next synchronization run (periodic or triggered manually).

{CODE-BLOCK:json}
curl \
	-X PATCH http://localhost:8081/fs/SlaveNorthwindFS/synchronization/ResolveConflict/books/Inside.RavenDB.3.0.pdf?strategy=1
< HTTP/1.1 204 NoContent

{CODE-BLOCK/}

## Related articles

- [Synchronization conflicts](../../../../synchronization/conflicts)
