#Commands: Upload

The **PUT** method is used to insert a new file or update the content of an existing one in a file system.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/files/{name}  \
	-X PUT \
	--data-binary @file  \
	--header "anyKey:anyValue" \
    --header "If-None-Match:{etag}" \
    --header "RavenFS-Size:{size}" \ 
    --header "Content-Length:{length}"
&nbsp;
curl \
	http://{serverUrl}/fs/{fileSystemName}/files/{name}  \
	-X PUT \
	--data-binary @file  \
	--header "anyKey:anyValue" \
    --header "If-None-Match:{etag}" \
    --header "RavenFS-Size:{size}" \ 
    --header "Transfer-Encoding:chunked"
{CODE-BLOCK/}

### Request

| Payload |
| ------- |
| The file's content|

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **name** | Yes | The name under which the file will be stored |

| Header | Required | Description |
| --------| ------- | --- |
| **If-None-Match** | No |  Used to pass the file `Etag` |
| **RavenFS-Size** | No |  Used to validate the number of bytes received on the server side. If there is a mismatch between the size reported in the header and the number of the bytes read on the server side, then `BadRequestException` is thrown. |
| **Content-Length** | Yes / No |  Used to specify the length if the request (actually the size of the uploaded file). If not specified then `Transfer-Encoding:chunked` must be set. |
| **Transfer-Encoding** | Yes / No |  Used to define how the file is sent. If you don't know the actual file size you can set it to `chunked`, then there is no need to specify `Content-Length` header. |
| Any other header | No | Used to pass metadata records |

### Response

| Status code | Description |
| ----------- | - |
| `201` | Created |
| `405` | The concurrency exception occurred |
| `420` | The synchronization exception occurred |

| Return Value | Description |
| ------------- | ------------- |
| **None** | The request does not return any message |

<hr />

## Examples

Put a file under name `/movies/intro.avi` with `AllowRead` metadata:

{CODE-BLOCK:json}
curl \
	-X PUT http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi  \
	--data-binary @C:\intro.avi
	--header "AllowRead:Everyone" \
	--header "Content-Length:1338" \
    --header "RavenFS-Size:1338"
< HTTP/1.1 201 Created

{CODE-BLOCK/}

If you don't know the exact file size you can take advantage of `Transfer-Encoding:chunked` header:

{CODE-BLOCK:json}
curl \
	-X PUT http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi  \
	--data-binary @C:\intro.avi
	--header "AllowRead:Everyone" \
	--header "Transfer-Encoding:chunked"
< HTTP/1.1 201 Created

{CODE-BLOCK/}


Attempting to put a file with an invalid `Etag` ends up with the concurrency error:

{CODE-BLOCK:json}
curl \
	-X PUT http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi  \
	--data-binary @C:\intro.avi
	--header "Content-Length:1338" \
    --header "If-None-Match:01000000-0000-0008-0000-0000000000CC"
 
< HTTP/1.1 405 Method Not Allowed
{
    "Url":"/fs/NorthwindFS/files/movies/intro.avi",
    "ActualETag":"00000000-0000-0003-0000-000000000006",
    "ExpectedETag":"01000000-0000-0008-0000-0000000000CC",
    "Error":"Operation attempted on file '/movies/intro.avi' using a non current etag"
}
{CODE-BLOCK/}

The put operation on the currently being synced file returns the synchronization error:

{CODE-BLOCK:json}
curl \
	-X PUT http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi  \
	--data-binary @C:\intro.avi
	--header "Content-Length:1338"
 
< HTTP/1.1 420
{
    "Url":"/fs/NorthwindFS/files/movies/intro.avi",
    "Error":"File /movies/intro.avi is being synced"
}
{CODE-BLOCK/}
