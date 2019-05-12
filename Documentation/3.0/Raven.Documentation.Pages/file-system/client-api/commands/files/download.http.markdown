#Commands: Download

The **GET** method is used to retrieve the file's content and metadata.

## Syntax

{CODE-BLOCK:json}
curl \
	http://{serverUrl}/fs/{fileSystemName}/files/{name}  \
	-X GET \
    --header "Range:bytes={from}-{to}"
    > {localFileName}
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **name** | Yes | The name of the file to download |

| Header | Required | Description |
| --------| ------- | --- |
| **Range** | No |  Used to retrieve partial content. If not specified, the the entire file is downloaded. |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |
| `404` | Not found |

| Return Value | Description |
| ------------- | ------------- |
| **Binary data** | The requested bytes of the file's content are returned |
| **Metadata** | The files' metadata is returned in the response headers |

<hr />

## Examples

In order to download the `/movies/intro.avi` file and store it locally under `intro.avi` name, use the following command:

{CODE-BLOCK:json}
curl \
	-v -X GET http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi > intro.avi
HTTP/1.1 200 OK
< Content-Length: 1338
< Content-MD5: 3501b7763d91fa9239f2ba64ff850a03
< Last-Modified: Fri, 10 Apr 2015 09:07:29 GMT
< ETag: "00000000-0000-0003-0000-000000000006"
< AllowRead: Everyone
< RavenFS-Size: 1338
< Raven-Creation-Date: 2015-04-10T09:07:26.8940842+00:00
< Raven-Last-Modified: 2015-04-10T09:07:29.6474663+00:00
< Creation-Date: 2015-04-10T09:07:26.8940842Z
< Raven-Synchronization-History: [{"Version":16385,"ServerId":"d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f"}]
< Raven-Synchronization-Version: 16385
< Raven-Synchronization-Source: d7bfdb4c-a463-4f75-93fb-cb60e4d3a08f
< Raven-Server-Build: 3.0.3660

{CODE-BLOCK/}

If you are interested in retrieving just the range of bytes, you need to provide `Range` header. The below command will return just 40 bytes:

{CODE-BLOCK:json}
curl \
	-v -X GET http://localhost:8080/fs/NorthwindFS/files/movies/intro.avi \ 
    --header "Range:bytes=10-50" > partial_intro.avi
HTTP/1.1 200 OK
< Content-Range: bytes 10-49/1338

{CODE-BLOCK/}
