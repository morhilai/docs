# Session : Deleting Entities
---
{NOTE: }

* To mark an entity for deletion, use one of the three overloaded `Delete` methods.  

* The server will not receive the instruction to delete the corresponding document until `SaveChanges()` is called.  

* In this page:  
  * [Syntax](../../client-api/session/deleting-entities#syntax)  
  * [Examples - Delete Document](../../client-api/session/deleting-entities#examples---delete-document)  
    * [With a Known Change Vector](../../client-api/session/deleting-entities#deleting-a-document-with-a-known-change-vector)
    * [Without a Known Change Vector](../../client-api/session/deleting-entities#deleting-a-document-without-a-known-change-vector)
{NOTE/}

---
{PANEL:Syntax}

The three overloads of `Delete`:

{CODE deleting_1@ClientApi\Session\DeletingEntities.cs /}

| Parameter | Type | Description |
| ------------- | ------------- | ----- |
| **entity** | `T` - the class of the entity | Instance of an entity to be deleted |
| **id** | string | Id of an entity to be deleted |
| **expectedChangeVector** | string | The change vector to be used for a concurrency check |
{PANEL/}

{PANEL:Examples - Delete Document}

####Deleting a Document With a Known Change Vector:  

{CODE-TABS}
{CODE-TAB:csharp:Sync deleting_2@ClientApi\Session\DeletingEntities.cs /}
{CODE-TAB:csharp:Async deleting_2_async@ClientApi\Session\DeletingEntities.cs /}
{CODE-TABS/}

If `UseOptimisticConcurrency` is set to `true`, Delete will use the change vector loaded with `"employees/1"` for a concurrency check and might throw a `ConcurrencyException`.  

By default, `UseOptimisticConcurrency` is set to `false`; in the event of a concurrency conflict, the write operation with the most recent time stamp takes effect (Last Write Wins strategy).  
<br/>
####Deleting a Document Without a Known Change Vector:  

{CODE-TABS}
{CODE-TAB:csharp:Sync deleting_3@ClientApi\Session\DeletingEntities.cs /}
{CODE-TAB:csharp:Async deleting_3_async@ClientApi\Session\DeletingEntities.cs /}
{CODE-TABS/}

In this overload, regardless of whether optimistic concurrency is being used, `Delete` will not do any change vector based concurrency checks because the change vector for `"employees/1"` isn't known.  
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
