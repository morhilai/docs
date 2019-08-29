# Send Multiple Commands in a Batch

---

{NOTE: }

* Use this endpoint with the `POST` method to send multiple commands in one request:  
`http://[server URL]/databases/[database name]/bulk_docs`  

* All the commands in the batch will either succeed or fail as a **single transaction**. Changes will not be visible until the entire batch completes.  

* Options are available for server to wait for indexing and replication to complete before responding.  

* In this page:  
  * [Basic Example](../../../client-api/rest-api/document-commands/batch-commands#basic-example)  
  * [Request Format](../../../client-api/rest-api/document-commands/batch-commands#request-format)  
  * [Response Format](../../../client-api/rest-api/document-commands/batch-commands#response-format)  
  * [More Examples](../../../client-api/rest-api/document-commands/batch-commands#more-examples)  
      * [Get Multiple Documents](../../../client-api/rest-api/document-commands/get-documents-by-id#get-multiple-documents)  
      * [Get Related Documents](../../../client-api/rest-api/document-commands/get-documents-by-id#get-related-documents)  
      * [Get Document Metadata Only](../../../client-api/rest-api/document-commands/get-documents-by-id#get-document-metadata-only)  
      * [Get Document Counters](../../../client-api/rest-api/document-commands/get-documents-by-id#get-document-counters)  
{NOTE/}

---

{PANEL: Basic Example}

This is a cURL request to our [playground server](http://live-test.ravendb.net) to a database named "Example".  
It batches two commands:  

1. Upload a new document called "person/1".  
2. Execute a [patch](../../../client-api/operations/patching/single-document) on that same document.  

{CODE-BLOCK: bash}
curl -X POST http://live-test.ravendb.net/databases/Example/bulk_docs
-H 'Content-Type: application/json'
-d '{
    "Commands": [
        {
            "Id": "person/1",
            "ChangeVector": null,
            "Document": {
                "Name": "John Smith"
            },
            "Type": "PUT"
        },
        {
            "Id": "person/1",
            "ChangeVector": null,
            "Patch": {
                "Script": "this.Name = 'Jane Doe';",
                "Values": {}
            },
            "Type": "PATCH"
        }
    ]
}'
{CODE-BLOCK/}

Linebreaks are added for clarity.  

Response:  

{CODE-BLOCK: http}
HTTP/1.1 201 Created
Server: nginx
Date: Sun, 15 Sep 2019 14:12:30 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Type": "PUT",
            "@id": "person/1",
            "@collection": "@empty",
            "@change-vector": "A:1-urx5nDNUT06FCpCon1wCyA",
            "@last-modified": "2019-09-15T14:12:30.0425811"
        },
        {
            "Id": "person/1",
            "ChangeVector": "A:2-urx5nDNUT06FCpCon1wCyA",
            "LastModified": "2019-09-15T14:12:30.0495095",
            "Type": "PATCH",
            "PatchStatus": "Patched",
            "Debug": null
        }
    ]
}
{CODE-BLOCK/}

{PANEL/}

{PANEL: Request Format}

This is the general form of a cURL request that does _not_ include a Put Attachment Command (See the Put Attachment Command format 
[below](../../../client-api/rest-api/document-commands/batch-commands#put-attachment-command)):  

{CODE-BLOCK: bash}
curl -X POST 'http[server URL]/databases/[database name]/bulk_docs?[batch options]'
-H 'Content-Type: application/json'
-d '{
    "Commands": [
        { },
        ...
    ]
}'
{CODE-BLOCK/}

Linebreaks are added for clarity.  

The header `Content-Type` is required and takes one of two values:  

* `application/json` - if the batch _does not_ include a Put Attachment Command.  
* `multipart/mixed; boundary=[separator]` - if the batch _does_ include a Put Attachment Command. The `separator` is used to demarcate the attachment 
streams.  

The following commands can be sent using the batch command:  

* [Put Document Command](../../../client-api/rest-api/document-commands/batch-commands#put-document-command)  
* [Patch Document Command](../../../client-api/rest-api/document-commands/batch-commands#patch-document-command)  
* [Delete Document Command](../../../client-api/rest-api/document-commands/batch-commands#delete-document-command)  
* [Delete by Prefix Command](../../../client-api/rest-api/document-commands/batch-commands#delete-by-prefix-command)  
* [Put Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#put-attachment-command)  
* [Delete Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#delete-attachment-command)  

The query string takes [batch options](../../../client-api/rest-api/document-commands/batch-commands#batch-options), which can make the server wait for 
indexing and replication to finish before responding.  

---

### Put Document Command

Upload a new document or update an existing document.  

Format within the `Commands` array in the request body:  

{CODE-BLOCK: json}
{
    "Id": "[document ID]",
    "ChangeVector": "[expected change vector]",
    "Document": {
        [document content]
    },
    "Type": "PUT",
    "ForceRevisionCreationStrategy": "[none / before]"
}
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **Id** | ID of document to create or update | Required |
| **ChangeVector** | If updating an existing document - that document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| **Document** | JSON Document to create, or to replace existing document | Required |
| **Type** | Set to `PUT` | Required |
| **ForceRevisionStrategy** | Can be set to either `none` or `before` | Optional |

---

### Patch Document Command

Update a document. A [patch](../../../client-api/operations/patching/single-document) is executed on the server side and does not involve loading the 
document, thus avoiding the cost of sending the entire document in a round trip over the network.  

Format within the `Commands` array in the request body:  

{CODE-BLOCK: json}
{
    "Id": "[document ID]",
    "ChangeVector": "[expected change vector]",
    "Patch": {
        "Script": "[javascript code]",
        "Values": {
            [arguments]
        }
    },
    "Type": "PATCH"
}
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **Id** | ID of document on which to execute the patch | Required |
| **ChangeVector** | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| **Patch** | Script that modifies the specified document | Required |
| **PatchIfMissing** | Type: `PatchRequest` - An alternative script to be executed if no document with the given ID is found. This will create a new document with the given ID. | Optional |
| **Script** | Commands in javascript to perform on the document. | Required |
| **Values** | Arguments that can be used in the script. | Optional |
| **Type** | Set to `PATCH` | Required |

---

### Delete Document Command

Delete a document by its ID.  

Format within the `Commands` array in the request body:  

{CODE-BLOCK: json}
{
    "Id": "[document ID]",
    "ChangeVector": "[expected change vector]",
    "Type": "DELETE"
}
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **Id** | ID of document to delete (only one can be deleted per command) | Required |
| **ChangeVector** | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| **Type** | Set to `DELETE` | Required |

---

### Delete by Prefix Command

Delete all documents whose IDs begin with a certain prefix.  

Format within the `Commands` array in the request body:  

{CODE-BLOCK: json}
{
    "prefix": "[document ID prefix]",
    "IdPrefixed": true,
    "Type": "DELETE"
}
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **prefix** | Documents whose IDs begin with this prefix will all be deleted | Required |
| **IdPrefixed** | Set to `true`. Distinguishes this as a delete by prefix command rather than the [delete by document ID command](../../../client-api/rest-api/document-commands/batch-commands#delete-command). | Required |
| **Type** | Set to `DELETE` | Required |

---

### Put Attachment Command

Add an [attachment](../../../client-api/session/attachments/what-are-attachments) to a document.  

If a batch contains a Put Attachment Command, the cURL format of the request is slightly different from a batch that doesn't.  
The `Content-Type` header takes `multipart/mixed; boundary="[separator]"` instead of the default `application/json`.  
The body contains the `Commands` array followed by each of the attachments, passed in the form of binary streams. The attachment streams come in the 
same order as their respective Put Attachment Commands within the `Commands` array. The `separator` demarcates these sections.  

The general form of a cURL request:  

{CODE-BLOCK: bash}
curl -X POST http://[server URL]/databases/[database name]/bulk_docs
-H Content-Type: multipart/mixed; boundary="[separator]"
-d
--[separator]
{
    "Commands":[ 
        {
            "Id": "[document ID]",
            "Name": "[attachment name]",
            "ContentType": "[attachment MIME type]"
            "ChangeVector": "[expected change vector]",
            "Type": "AttachmentPUT"
        },
        ...
    ]
}
--[separator]
Command-Type: AttachmentStream

[binary stream]
--[separator]
...
--[separator]--
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **Id** | Document ID | Required |
| **Name** | Name of attachment to create | Required |
| **ContentType** | Mime type of attachment |
| **ChangeVector** | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| **Type** | Set to `AttachmentPUT` | Required |
| **separator** | Any string that does not appear in the contents of the body | Required |

---

### Delete Attachment Command

Delete an attachment in a certain document.  

Format within the `Commands` array in the request body:  

{CODE-BLOCK: json}
{
    "Id": "[document ID]",
    "Name": "[attachment name]",
    "ChangeVector": "[expected change vector]",
    "Type": "AttachmentDELETE"
}
{CODE-BLOCK/}

| Parameter | Description | Required |
| - | - | - |
| **Id** | ID of document for which to delete the attachment | Required |
| Name | Name of the attachment to delete | Required |
| **ChangeVector** | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| **Type** | Set to `AttachmentDELETE` | Required |

---

### Batch Options

These options make the server wait until indexing or replication have completed before responding. If these have not completed before a specified 
amount of time has passed, the server can either respond as normal, or throw an exception.  

{CODE-BLOCK: bash}
curl -X POST 'http[server URL]/databases/[database name]/bulk_docs?[option]=[value]&[option]=[value]&...
    -d '{ }'
{CODE-BLOCK/}

#### Index Options

| Query Parameter | Type | Description |
| - | - | - |
| **waitForIndexesTimeout** | `TimeSpan` | The amount of time to wait for indexing to complete. [Format of `TimeSpan`](https://docs.microsoft.com/en-us/dotnet/api/system.timespan). |
| **waitForIndexThrow** | `boolean` | Set to `true` to throw an exception if the the indexing doesn't complete before `waitForIndexesTimeout`.<br/>Set to `false` to recieve the normal response body. |
| **waitForSpecificIndex** | `string[]` | If this parameter is used, wait only for the listed indexes to finish updating, rather than all indexes. |

#### Replication Options

| Query Parameter | Type | Description |
| - | - | - |
| **waitForReplicasTimeout** | `TimeSpan` | The amount of time to wait for replication to complete. [Format of `TimeSpan`](https://docs.microsoft.com/en-us/dotnet/api/system.timespan). |
| **throwOnTimeoutInWaitForReplicas** | `boolean` | Set this parameter to `true` to throw an exception if the the replication doesn't complete before `waitForReplicasTimeout`.<br/>Set to `false` to recieve the normal response body. |
| **numberOfReplicasToWaitFor** | `int` | The number of replicas that should be made before `waitForReplicasTimeout`. Set this parameter to `majority` to wait until the data has been replicated to a majority of the nodes in the database group. Default = `1`. |

If the request is configured to wait both for indexing and replication, the timeout is determined **only** by `waitForReplicasTimeout`, and not by `waitForIndexesTimeout`.

{PANEL/}

{PANEL: Response Format}

###Http Status Codes

| Code | Description |
| - | - |
| `201` | The transaction was successfully completed. |
| `408` | The time specified by the options `waitForIndexThrow` or `waitForReplicasTimeout` passed before indexing or replication completed respectively, and an exception was thrown. This only happens if `throwOnTimeoutInWaitForReplicas` or `waitForIndexThrow` are set to `true`. |
| `409` | The specified change vector did not match the server-side change vector, or a change vector was specified for a document that does not exist. A concurrency exception is thrown. |

###Response Body

{CODE-BLOCK: json}
{
    "Results":[
        { },
        ...
    ]
}
{CODE-BLOCK/}

* In this section:  
  * [Put Document Command](../../../client-api/rest-api/document-commands/batch-commands#put-document-command-1)  
  * [Patch Document Command](../../../client-api/rest-api/document-commands/batch-commands#patch-document-command-1)  
  * [Delete Document Command](../../../client-api/rest-api/document-commands/batch-commands#delete-document-command-1)  
  * [Delete by Prefix Command](../../../client-api/rest-api/document-commands/batch-commands#delete-by-prefix-command-1)  
  * [Put Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#put-attachment-command-1)  
  * [Delete Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#delete-attachment-command-1)  

### Put Document Command

Format within the `Results` array in the response body:  

{CODE-BLOCK: JSON}
{
    "Type": "PUT",
    "@id": "[document ID]",
    "@collection": "[collection name]",
    "@change-vector": "[current change vector]",
    "@last-modified": "[date and time UTC]"
}
{PANEL/}

### Patch Document Command

| Http Status Code | Description |
| - | - |
| `201` | The document was successfully created or updated. |
| `409` | The change vector did not match the server-side change vector, or a change vector was specified for a document that does not exist. A concurrency exception is thrown. |

Format within the results array:

{CODE-BLOCK: JSON}
{
    "@id": "[document ID]",
    "@change-vector": "[current change vector]",
    "@last-modified": "[date and time UTC]",
    "Type": "PATCH",
    "PatchStatus": "[patch status]",
    "Debug": 
}
{PANEL/}

### Delete Document Command

| Http Status Code | Description |
| - | - |
| `201` | The document was successfully created or updated. |
| `409` | The change vector did not match the server-side change vector, or a change vector was specified for a document that does not exist. A concurrency exception is thrown. |

Format within the results array:

{CODE-BLOCK: JSON}
{
    "Results": [
        {
            "Id": "[document ID]",
            "Type": "DELETE",
            "Deleted": [boolean]
        }
    ]
}
{PANEL/}

{PANEL: More Examples}
* In this section:  
  * [Put Document Command](../../../client-api/rest-api/document-commands/batch-commands#put-document-command-2)  
  * [Patch Document Command](../../../client-api/rest-api/document-commands/batch-commands#patch-document-command-2)  
  * [Delete Document Command](../../../client-api/rest-api/document-commands/batch-commands#delete-document-command-2)  
  * [Delete by Prefix Command](../../../client-api/rest-api/document-commands/batch-commands#delete-by-prefix-command-2)  
  * [Put Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#put-attachment-command-2)  
  * [Delete Attachment Command](../../../client-api/rest-api/document-commands/batch-commands#delete-attachment-command-2)  

---

###Put Document Command

{
HTTP/1.1 201 Created
Server: nginx
Date: Sun, 15 Sep 2019 17:02:11 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Type": "PUT",
            "@id": "person/2",
            "@collection": "@empty",
            "@change-vector": "A:3-urx5nDNUT06FCpCon1wCyA",
            "@last-modified": "2019-09-15T17:02:11.6265671"
        }
    ]
}

{PANEL/}

## Related articles

### Transactions

- [Transaction Support](../../../client-api/faq/transaction-support)

### Commands

- [Put](../../../client-api/commands/documents/put)   
- [Delete](../../../client-api/commands/documents/delete)
- [How to Get Document Metadata Only](../../../client-api/commands/documents/how-to/get-document-metadata-only)

### Patching

- [How to Perform Single Document Patch Operations](../../../client-api/operations/patching/single-document)   

### Attachments

- [What are Attachments](../../../client-api/session/attachments/what-are-attachments)
