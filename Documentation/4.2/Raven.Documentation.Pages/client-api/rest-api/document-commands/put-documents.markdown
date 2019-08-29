# Commands: Documents: Put

---
{NOTE: }  

* Use this endpoint with the `PUT` method to update or upload new documents to the database:  
`http://[server URL]/databases/[database name]/docs`  

* In this page:  
  * [Examples](../../../client-api/rest-api/document-commands/put-documents#examples)  
  * [Request Format](../../../client-api/rest-api/document-commands/put-documents#request-format)  
  * [Response Format](../../../client-api/rest-api/document-commands/put-documents#response-format)  

{NOTE/}  

---

{PANEL: }

### Examples

Example requests sent to the RavenDB [playground server](http://live-test.ravendb.net):  

1) Store new document "person/1-A" in the collection "People".  

{CODE-BLOCK: bash}
curl -X PUT http://live-test.ravendb.net/databases/Example/docs?id=person/1-A
    -d { 
    "FirstName":"Jane", 
    "LastName":"Doe",
    "Age":42,
    "@metadata":{
		"@collection": "People"
	}
}
{CODE-BLOCK/}

Linebreaks are added for clarity.  

Actual response:  

{CODE-BLOCK: Http}
HTTP/1.1 201
status: 201
Server: nginx
Date: Tue, 27 Aug 2019 10:58:28 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
Vary: Accept-Encoding
Raven-Server-Version: 4.2.3.42

{
    "Id":"person/1-A",
    "ChangeVector":"A:1"
}
{CODE-BLOCK/}

2) Update that same document.  

{CODE-BLOCK: bash}
curl \
    'http://live-test.ravendb.net/databases/Example/docs?id=person/1-A' \
    -X PUT \
    --header 'If-Match: A:1' \
    -d '{ 
    "FirstName":"John", 
    "LastName":"Smith",
    "Age":24,
}'
{CODE-BLOCK/}

Response is identical except for the updated change vector:  

{CODE-BLOCK: Http}
HTTP/1.1 201
status: 201
Server: nginx
Date: Tue, 27 Aug 2019 10:59:54 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
Vary: Accept-Encoding
Raven-Server-Version: 4.2.3.42

{
    "Id":"person/1-A",
    "ChangeVector":"A:3"
}

{CODE-BLOCK/}

---

### Request Format

{CODE-BLOCK: bash}
curl -X PUT \
    http://[server URL]/databases/[database name]/docs?id=[document ID] \
    --header If-Match: [expected change vector] \
    -d [JSON document]
{CODE-BLOCK/}

| Query Parameters | Description | Required |
| - | - | - |
| **id** | Unique ID under which the new document will be stored, or the ID of an existing document to be updated. | Required |

| Headers | Description | Required |
| - | - | - |
| **If-Match** | When updating an existing document, this header passes the document's expected [change vector](../../../server/clustering/replication/change-vector). If this change vector doesn't match the document's server-side change vector, a concurrency exception is thrown. | Optional |

---

### Response Format

The response body is JSON and contains the document ID and current change vector.

| Header | Description |
| - | - |
| **status** | Http status code |
| **Server** | Web server |
| **Date** | Date and time of response (UTC) |
| **Content-Type** | MIME media type and character encoding |
| **Raven-Server-Version** | Version or RavenDB the responding server is running |

| HTTP Status Code | Description |
| - | - |
| `201` | The document was successfully stored / the *existing* document was successfully updated |
| `409` | The change vector submitted did not match the server-side change vector. A concurrency exception was thrown. |

{PANEL/}

## Related Articles

### Client API

- [Get](../../../client-api/commands/documents/get)  
- [Delete](../../../client-api/commands/documents/delete)
- [How to Send Multiple Commands Using a Batch](../../../client-api/commands/batches/how-to-send-multiple-commands-using-a-batch)

### Server

- [Change Vector](../../../server/clustering/replication/change-vector)
