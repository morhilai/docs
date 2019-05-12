# Glossary: PatchCommandData

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Patches** | [PatchRequest](../client-api/commands/patches/how-to-work-with-patch-requests)[] | Patches to apply |
| **PatchesIfMissing** | [PatchRequest](../client-api/commands/patches/how-to-work-with-patch-requests)[] | Patches to apply if document is missing |
| **Key** | string | Document key |
| **Method** | string | The HTTP method (`PATCH`) |
| **Etag** | Etag | Document etag (used for concurrency checking) |
| **TransactionInformation** | TransactionInformation | Transactional information |
| **Metadata** | RavenJObject | Document metadata |
| **AdditionalData** | RavenJObject | Additional metadata |

### Methods

| Signature | Description |
| ---------- | ----------- |
| **RavenJObject ToJson()** | Translate this instance to a Json object. |
