# Session: Storing Entities

To store entities inside the **session** object, use one of the three `Store` methods.

## Syntax

First overload: Stores the entity in a session, then extracts the ID from the entity or generates a new one if it's not available.

{CODE store_entities_1@ClientApi\Session\StoringEntities.cs /}

Second overload: Stores the entity in a session with given ID.

{CODE store_entities_2@ClientApi\Session\StoringEntities.cs /}

Third overload: Stores the entity in a session with given ID, forces concurrency check with given change vector.

{CODE store_entities_3@ClientApi\Session\StoringEntities.cs /}


| Parameters | | |
| ------------- | ------------- | ----- |
| **entity** | object | Entity that will be stored |
| **changeVector** | string | Entity changeVector, used for concurrency checks (`null` to skip check) |
| **id** | string | Entity will be stored under this ID, (`null` to generate automatically) |

## Example

{CODE store_entities_5@ClientApi\Session\StoringEntities.cs /}

## Related Articles

### Session

- [What is a Session and How Does it Work](../../client-api/session/what-is-a-session-and-how-does-it-work) 
- [Opening a Session](../../client-api/session/opening-a-session)
- [Loading Entities](../../client-api/session/loading-entities)
- [Saving Changes](../../client-api/session/saving-changes)

### Querying

- [Basics](../../indexes/querying/basics)

### Document Store

- [What is a Document Store](../../client-api/what-is-a-document-store)
