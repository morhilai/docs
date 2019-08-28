# Batches: How to Send Multiple Commands Using a Batch

---

{NOTE: }

To send **multiple commands** in a **single request**, reducing the number of remote calls and allowing several operations to share **same transaction**, `BatchCommand` should be used.

{NOTE/}

---

## Syntax

{CODE-BLOCK: bash}
curl -X POST \
    'http[server URL]/databases/[database name]/bulk_docs?[batch options] \
    -d {
        [list of commands]
    }
{CODE-BLOCK/}

The following commands can be sent using a batch:  

* [DeleteAttachmentCommandData](../../../client-api/commands/batches/how-to-send-multiple-commands-using-a-batch#delete-attachment-command)  
* [DeleteCommandData]()  
* [DeletePrefixedCommandData]()  
* [PatchCommandData]()  
* [PutAttachmentCommandData]()  
* [PutCommandData]()  

---

### Delete Attachment Command

| Parameter | Description | Required |
| - | - | - |
| Id | ID of document for which to delete the attachment | Required |
| Name | Name of the attachment to delete | Required |
| ChangeVector | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| Type | Set to `AttachmentDELETE` | Required |

### DeleteCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | ID of document to delete (only one can be deleted per command) | Required |
| ChangeVector | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| Type | Set to `DELETE` | Required |

### DeletePrefixedCommandData

| Parameter | Description | Required |
| - | - | - |
| prefix | Documents whose IDs begin with this prefix will all be deleted | Required |
| IdPrefixed | Set to `true`. Indicates that this command is delete by prefix rather than delete by whole document ID. | Required |
| Type | Set to `DELETE` | Required |

#### PatchCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | ID of document on which to execute the patch | Required |
| ChangeVector | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| Patch | Script that modifies the specified document | Required |
| PatchIfMissing | Type: `PatchRequest` - An alternative script to be executed if no document with the given ID is found. This will create a new document with the given ID. | Optional |
| Type | Set to `PATCH` | Required |

### PutAttachmentCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID | Required |
| Name | Name of attachment to create | Required |
| Stream | Type: binary stream - the content of the attachment | Required |
| ContentType | Mime type of attachment |
| ChangeVector | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| Type | Set to `AttachmentPUT`  | Required |

#### Format

{CODE-BLOCK: bash}
curl \
    'http://{server URL}/databases/{database name}/bulk_docs \
    -X POST \
    -H Content-Type: multipart/mixed; boundary={separator}
    -d
    --{separator}
    {list of command data in JSON format}
    --{separator}
    Command-Type: AttachmentStream

    {binary stream}
    --{separator}
{CODE-BLOCK/}

Binary streams come at the end of the body, in the same order as the put attachment commands in the command list.

### PutCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID | Required |
| ChangeVector | The document's expected change vector. If it does not match the server-side change vector a concurrency exception is thrown. | Optional |
| Document | JSON Document to put | Required |
| Type | Set to `PUT` - the which operation to perform on the specified document(s) | Required |
| ForceRevisionStrategy | Either none or Before | Optional |

### Batch Options

{CODE batch_2@ClientApi\Commands\Batches\HowToSendMultipleCommandsUsingBatch.cs /}


## Example

{PANEL}
{CODE-TABS}
{CODE-TAB:csharp:Sync batch_3@ClientApi\Commands\Batches\HowToSendMultipleCommandsUsingBatch.cs /}
{CODE-TAB:csharp:Async batch_3_async@ClientApi\Commands\Batches\HowToSendMultipleCommandsUsingBatch.cs/}
{CODE-TABS/}
{PANEL/}

{NOTE All the commands in the batch will succeed or fail as a **transaction**. Other users will not be able to see any of the changes until the entire batch completes./}

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
