# Session : Storing Entities
---
{NOTE: }

* To store an entity in a session, use one of the three overloaded `Store` methods.

* That session will track all changes made to the entity.

* The entity, and any changes made to it, will be saved to the database as a new document upon next call to `SaveChanges()`.

* In this page:
  * [Syntax](../../client-api/session/storing-entities#syntax)
  * [Example - Store Entity](../../client-api/session/storing-entities#example---store-entity)
{NOTE/}

---
{PANEL:Syntax}

The three overloads of `Store`:

{CODE store_entities_1@ClientApi\Session\StoringEntities.cs /}

| Parameter | Type | Description |
| --- | --- | --- |
| **entity** | object | The entity to be stored |
| **changeVector** | string | An entity changeVector, used for concurrency checks (`null` to skip check) |
| **id** | string | An entity ID (`null` to generate automatically) |
{PANEL/}

{PANEL:Example - Store Entity}

{CODE store_entities_5@ClientApi\Session\StoringEntities.cs /}
{PANEL/}

## Related Articles

### Client API

- [What is a Session and How Does it Work](../../client-api/session/what-is-a-session-and-how-does-it-work) 
- [Opening a Session](../../client-api/session/opening-a-session)
- [Loading Entities](../../client-api/session/loading-entities)
- [Saving Changes](../../client-api/session/saving-changes)

### Indexes

- [Querying Basics](../../indexes/querying/basics)

### Getting Started

- [What is a Document Store](../../client-api/what-is-a-document-store)
