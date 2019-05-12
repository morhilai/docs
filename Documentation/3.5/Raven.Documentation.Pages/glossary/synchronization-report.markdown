# Glossary: SynchronizationReport

RavenFS client API class contains info about a finished file synchronization.

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **FileName** | string | The file name |
| **FileETag** | Etag | The file `Etag` |
| **BytesTransfered** | long | The number of file bytes sent by a source file system during the synchronization process |
| **BytesCopied** | long | The number of bytes copied from the file on the destination file system during the synchronization process |
| **NeedListLength** | long | The number of elements in the need list (see [RDC overview](../file-system/synchronization/synchronization-types#file-system/synchronization/synchronization-types#remote-differential-compression)) |
| **Exception** | Exception | The exception that happened during the synchronization or `null` if the operation finished successfully |
| **Type** | SynchronizationType | The type of performed synchronization: ContentUpdate, MetadataUpdate, Rename or Delete |
