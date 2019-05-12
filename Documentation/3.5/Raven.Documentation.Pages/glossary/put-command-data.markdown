# Glossary: PutCommandData

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **Key** | string | Document key |
| **Method** | string | The HTTP method (`PUT`) |
| **Etag** | Etag | Document etag (used for concurrency checking) |
| **Document** | RavenJObject | Document to put |
| **TransactionInformation** | TransactionInformation | Transactional information |
| **Metadata** | RavenJObject | Document metadata |
| **AdditionalData** | RavenJObject | Additional metadata |

### Methods

| Signature | Description |
| ---------- | ----------- |
| **RavenJObject ToJson()** | Translate this instance to a Json object. |
