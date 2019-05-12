#Commands: Search

Use the **GET** method on `/search` endpoint to fetch the list of files matching the specified query.


## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/search?query={query}&start={start}&pageSize={pageSize}&sort={sort}  \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **query** | Yes | The query containing search criteria (you can use the [built-in fields](../../../../indexing) or metadata entries) consistent with [Lucene syntax](http://lucene.apache.org/core/3_0_3/queryparsersyntax.html) |
| **sort** | No | The fields to sort by |
| **start** | No | The start number to read index results |
| **pageSize** | No | The max number of results that will be returned  (Default: 25)|


### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| **JSON** | JSON object representing [search results](../../../../../glossary/search-results)|

<hr />

## Example

{CODE-BLOCK:json}
curl \
	-X GET http://localhost:8080/fs/NorthwindFS/search?query=AllowRead:Everyone&sort=__key
< HTTP/1.1 200 OK
{
    "Files":[
        {
            "Metadata":{
                // ...
            },
            "OriginalMetadata":{
                // ...
            },
            "TotalSize":1202187,
            "UploadedSize":1202187,
            "LastModified":"2015-04-11T08:22:35.5854653+00:00",
            "CreationDate":"2015-04-10T12:34:04.5128067+00:00",
            "Etag":"00000000-0000-0007-0000-000000000001",
            "FullPath":"/books/Inside.RavenDB.3.0.pdf",
            "Name":"Inside.RavenDB.3.0.pdf",
            "Extension":".pdf",
            "Directory":"/books",
            "IsTombstone":false,
            "HumaneTotalSize":"1.15 MBytes"
        }
    ],
    "FileCount":1,
    "Start":0,
    "PageSize":25
}

{CODE-BLOCK/}
