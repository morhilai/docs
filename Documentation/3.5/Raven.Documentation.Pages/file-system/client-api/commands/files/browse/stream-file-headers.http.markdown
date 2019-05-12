#Commands: StreamFileHeaders

The **GET** method is used to stream the headers of files which match the criteria chosen from a file system.


## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/streams/files?etag={etag}&pageSize={pageSize}  \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **etag** | Yes | The `ETag` of a file from which the stream should start |
| **pageSize** | No | The maximum number of file headers that will be retrieved (Default: 1024)|

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **Results** | The array of [file headers](../../../../../glossary/file-header) |

<hr />

## Example

Retrieve first two files in `Etag` order by using streaming (note that the first one is a tombstone, streaming returns them too):

{CODE-BLOCK:json}
curl \
	-X GET "http://localhost:8080/fs/NorthwindFS/streams/files?etag=00000000-0000-0000-0000-000000000000&pageSize=2"
< HTTP/1.1 200 OK
{
    "Results":[
        {
            "Metadata":{
                // ...
            },
            "OriginalMetadata":{
               // ...
            },
            "TotalSize":0,
            "UploadedSize":0,
            "LastModified":"2015-04-10T11:07:22.2312711+00:00",
            "CreationDate":"0001-01-01T00:00:00.0000000+00:00",
            "Etag":"00000000-0000-0004-0000-000000000004",
            "FullPath":"/movies/introduction.avi",
            "Name":"introduction.avi",
            "Extension":".avi",
            "Directory":"/movies",
            "IsTombstone":true,
            "HumaneTotalSize":" Bytes"
        },
        {
            "Metadata":{
                // ...
            },
            "OriginalMetadata":{
               // ...
            },
            "TotalSize":1338,
            "UploadedSize":1338,
            "LastModified":"2015-04-10T12:11:14.6915914+00:00",
            "CreationDate":"0001-01-01T00:00:00.0000000+00:00",
            "Etag":"00000000-0000-0004-0000-000000000009",
            "FullPath":"/movies/intro.avi",
            "Name":"intro.avi",
            "Extension":".avi",
            "Directory":"/movies",
            "IsTombstone":false,
            "HumaneTotalSize":"1.31 KBytes"
        }
    ]
}
{CODE-BLOCK/}
