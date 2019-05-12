#Commands: StartsWith

The **GET** method with the **startsWith** parameter can be used to retrieve multiple file headers for the specified prefix name.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/files?startsWith={prefix}&matches={matches}\
    &start={start}&pageSize={pageSize}  \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **startsWith** | Yes | The prefix that the returned files need to match |
| **matches** | No | Pipe ('&#124;') separated values for which file name (after 'prefix') should be matched ('?' any single character; '*' any characters) |
| **start** | No | The number of files that will be skipped |
| **pageSize** | No | The maximum number of file headers that will be retrieved |


### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **Array** | The response consists of array of [file headers](../../../../../glossary/file-header) |

<hr />

## Example

The execution below command will return headers of files which names start with `/movies` and end with `.jpg`

{CODE-BLOCK:json}
curl -X PUT "http://localhost:8080/fs/NorthwindFS/files?startsWith=/movies&matches=*.avi"

< HTTP/1.1 200 OK
[
    {
        "Metadata":{
            "New":"Item",
            "Raven-Synchronization-History":[
                {
                    "Version":49153,
                    "ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"
                },
                {
                    "Version":4                    9155,
                    "ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"
                }
            ],
            "Raven-Synchronization-Version":49156,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Last-Modified":"2015-04-10T12:11:14.6915914+00:00",
            "Raven-Last-Modified":"2015-04-10T12:11:14.6915914+00:00",
            "Content-MD5":"3501b7763d91fa9239f2ba64ff850a03",
            "ETag":"00000000-0000-0004-0000-000000000009"
        },
        "OriginalMetadata":{
            "New":"Item",
            "Raven-Synchronization-History":[
                {
                    "Version":49153,
                    "ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"
                },
                {
                    "Version":4                    9155,
                    "ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"
                }
            ],
            "Raven-Synchronization-Version":49156,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Last-Modified":"2015-04-10T12:11:14.6915914+00:00",
            "Raven-Last-Modified":"2015-04-10T12:11:14.6915914+00:00",
            "Content-MD5":"3501b7763d91fa9239f2ba64ff850a03",
            "ETag":"00000000-0000-0004-0000-000000000009"
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

{CODE-BLOCK/}
