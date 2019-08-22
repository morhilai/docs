# Batches: How to Send Multiple Commands Using a Batch

To send **multiple commands** in a **single request**, reducing the number of remote calls and allowing several operations to share **same transaction**, `BatchCommand` should be used.

## Syntax

{CODE-BLOCK: bash}
curl \
    'http://{server URL}/databases/{database name}/bulk_docs \
    -X POST \
    -d {list of command data in JSON format}
{CODE-BLOCK/}

### The following commands can be sent using a batch

* DeleteAttachmentCommandData
* DeleteCommandData
* DeletePrefixedCommandData
* PatchCommandData
* PutAttachmentCommandData
* PutCommandData

#### DeleteAttachmentCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID for which to delete the attachment | Yes |
| Name | Name of attachment to delete | Yes |
| ChangeVector | Concurrency check | No |
| Type | Set to `AttachmentDELETE` - the operation to perform on the specified document(s) | Yes |

#### DeleteCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID | Yes |
| ChangeVector | Concurrency check | No |
| Type | Set to `DELETE` - the operation to perform on the specified document(s) | Yes |

#### DeletePrefixedCommandData

| Parameter | Description | Required |
| - | - | - |
| prefix | Documents whose IDs begin with this prefix will all be deleted. An example of a prefix would be a collection name. | Yes |
| IdPrefixed | Value: `true`. Indicates that this command is delete-by-prefix rather than by whole document ID | Yes |
| Type | Set to `DELETE` - the operation to perform on the specified document(s) | Yes |

#### PatchCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | ID of document on which to execute the patch | Yes |
| ChangeVector | Concurrency check | No |
| Patch | Type: `PatchRequest` - JavaScript script to use to patch the specified document | Yes |
| PatchIfMissing | Type: `PatchRequest` - An alternative script to use if no document with the given Id exists. It will create a new document with given Id | No |
| Type | Set to `PATCH` - the operation to perform on the specified document(s) | Yes |

#### PutAttachmentCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID | Yes |
| Name | Name of attachment to create | Yes |
| Stream | Type: binary stream - the content of the attachment | Yes |
| ContentType | Mime type of attachment |
| ChangeVector | Concurrency check | No |
| Type | Set to `AttachmentPUT` - the operation to perform on the specified document(s) | Yes |

##### Format

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

Binary streams come at the end of the body, in an order corresponding to the order of put attachment commands in the command list.

#### PutCommandData

| Parameter | Description | Required |
| - | - | - |
| Id | Document ID | Yes |
| ChangeVector | Concurrency check | No |
| Document | JSON Document to put | Yes |
| Type | Set to `PUT` - the which operation to perform on the specified document(s) | Yes |
| ForceRevisionStrategy | Either none or Before | No |

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
