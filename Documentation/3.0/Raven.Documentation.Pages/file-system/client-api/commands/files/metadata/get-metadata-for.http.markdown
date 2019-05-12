#Commands: GetMetadata

The **HEAD** method is used to retrieve the file's metadata.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/files/{name}  \
	-X HEAD 
    -I
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **name** | Yes | The name of a file|


### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |
| `404` | The file was not found |

| Return Value | Description |
| ------------- | ------------- |
| **Headers** | The metadata are returned in the response's headers |

<hr />

## Example

Download metadata of the `/movies/intro.avi` file:

{CODE-BLOCK:json}
curl \
	-X HEAD http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi  \
	-I

HTTP/1.1 200 OK
Content-Length: 0
Content-MD5: 3501b7763d91fa9239f2ba64ff850a03
Last-Modified: Fri, 10 Apr 2015 11:56:22 GMT
ETag: "00000000-0000-0004-0000-000000000006"
Server: Microsoft-HTTPAPI/2.0
Raven-Creation-Date: 2015-04-10T11:56:17.7601842+00:00
Raven-Last-Modified: 2015-04-10T11:56:22.157373+00:00
Creation-Date: 2015-04-10T11:56:17.7601842Z
Raven-Synchronization-History: [{"Version":16385,"ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"},{"Version":16386,"ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d
3a08f"}]
Raven-Synchronization-Version: 49153
Raven-Synchronization-Source: d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f
Raven-Server-Build: 13
Temp-Request-Time: 1
Date: Fri, 10 Apr 2015 11:58:10 GMT

{CODE-BLOCK/}
