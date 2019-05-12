#Commands: Get

The **GET** method with **fileNames** parameters is used to retrieve headers of multiple files.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/files?fileNames={name1}&fileNames={name2}...  \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **fileNames** | Yes | One or many names of the files you want to get headers for |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **Array** | The response consists of array of [file headers](../../../../../glossary/file-header) |

<hr />

## Example

The execution below command will return headers for `/pdfs/DZone_DatabasePersistenceMgmt.pdf` and `/books/Inside.RavenDB.3.0.pdf` files.

{CODE-BLOCK:json}
curl -X PUT "http://localhost:8080/fs/NorthwindFS/files?fileNames=/pdfs/DZone_DatabasePersistenceMgmt.pdf&fileNames=/books/Inside.RavenDB.3.0.pdf"

< HTTP/1.1 200 OK
[
    {
        "Metadata":{
            "DNT":"1",
            "RavenFS-Size":"3604201",
            "Raven-Creation-Date":"2015-04-10T12:33:52.0906196+00:00",
            "Last-Modified":"2015-04-10T12:33:52.4096380+00:00",
            "Raven-Last-Modified":"2015-04-10T12:33:52.409638+00:00",
            "Creation-Date":"2015-04-10T12:33:52.0906196Z",
            "Raven-Synchronization-History":[],
            "Raven-Synchronization-Version":49158,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Content-MD5":"8bd93049361ad54a14feb57067fad0db",
            "ETag":"00000000-0000-0004-0000-00000000000D"
        },
        "OriginalMetadata":{
            "DNT":"1",
            "RavenFS-Size":"3604201",
            "Raven-Creation-Date":"2015-04-10T12:33:52.0906196+00:00",
            "Last-Modified":"2015-04-10T12:33:52.4096380+00:00",
            "Raven-Last-Modified":"2015-04-10T12:33:52.409638+00:00",
            "Creation-Date":"2015-04-10T12:33:52.0906196Z",
            "Raven-Synchronization-History":[],
            "Raven-Synchronization-Version":49158,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Content-MD5":"8bd93049361ad54a14feb57067fad0db",
            "ETag":"00000000-0000-0004-0000-00000000000D"
        },
        "TotalSize":3604201,
        "UploadedSize":3604201,
        "LastModified":"2015-04-10T12:33:52.4096380+00:00",
        "CreationDate":"2015-04-10T12:33:52.0906196+00:00",
        "Etag":"00000000-0000-0004-0000-00000000000D",
        "FullPath":"/pdfs/DZone_DatabasePersistenceMgmt.pdf",
        "Name":"DZone_DatabasePersistenceMgmt.pdf",
        "Extension":".pdf",
        "Directory":"/pdfs",
        "IsTombstone":false,
        "HumaneTotalSize":"3.44 MBytes"
    },
    {
        "Metadata":{
            "DNT":"1",
            "RavenFS-Size":"1202187",
            "Raven-Creation-Date":"2015-04-10T12:34:04.5128067+00:00",
            "Last-Modified":"2015-04-10T12:34:06.5749425+00:00",
            "Raven-Last-Modified":"2015-04-10T12:34:06.5749425+00:00",
            "Creation-Date":"2015-04-10T12:34:04.5128067Z",
            "Raven-Synchronization-History":[],
            "Raven-Synchronization-Version":49159,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Content-MD5":"da94078c848eb5eb85e934e34133c768",
            "ETag":"00000000-0000-0004-0000-00000000000F"
        },
        "OriginalMetadata":{
            "DNT":"1",
            "RavenFS-Size":"1202187",
            "Raven-Creation-Date":"2015-04-10T12:34:04.5128067+00:00",
            "Last-Modified":"2015-04-10T12:34:06.5749425+00:00",
            "Raven-Last-Modified":"2015-04-10T12:34:06.5749425+00:00",
            "Creation-Date":"2015-04-10T12:34:04.5128067Z",
            "Raven-Synchronization-History":[],
            "Raven-Synchronization-Version":49159,
            "Raven-Synchronization-Source":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f",
            "Content-MD5":"da94078c848eb5eb85e934e34133c768",
            "ETag":"00000000-0000-0004-0000-00000000000F"
        },
        "TotalSize":1202187,
        "UploadedSize":1202187,
        "LastModified":"2015-04-10T12:34:06.5749425+00:00",
        "CreationDate":"2015-04-10T12:34:04.5128067+00:00",
        "Etag":"00000000-0000-0004-0000-00000000000F",
        "FullPath":"/books/Inside.RavenDB.3.0.pdf",
        "Name":"Inside.RavenDB.3.0.pdf",
        "Extension":".pdf",
        "Directory":"/books",
        "IsTombstone":false,
        "HumaneTotalSize":"1.15 MBytes"
    }
]

{CODE-BLOCK/}
