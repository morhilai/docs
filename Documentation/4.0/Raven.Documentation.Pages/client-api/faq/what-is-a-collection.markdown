# FAQ: What is a Collection
---

{NOTE: }

* **A collection** in RavenDB is a set of documents tagged with the same `@collection` metadata property.  
  Every document belongs to exactly one collection.  

* Being a schemaless database, there is no requirement that documents in the same collection will share the same structure,  
  although typically, a collection holds similarly structured documents based on the entity type of the document.  

* The collection is just a virtual concept.  
  There is no influence on how or where documents within the same collection are physically stored.  

* Collections are used throughout many RavenDB features, such as defining indexes, setting revisions, and much more.

* In this page:  
  * [Collection Name Generation](../../client-api/faq/what-is-a-collection#collection-name-generation)
  * [Collection Usages](../../client-api/faq/what-is-a-collection#collection-usages)

* For more information see [Documents and Collections](../../studio/database/documents/documents-and-collections)
{NOTE/}

![Figure 1. What is a Collection](images/what-is-a-collection.png "A document in 'Users' collection")

---

{PANEL: Collection Name Generation}

**When storing an entity from the client:**  

* The document collection metadata is generated **based on the stored entity object type**.  

* By default, the client pluralizes the collection name based on the type name.  
  e.g. storing an entity of type `Order` will generate the collection name `Orders`.  

* The function that is responsible for tagging the documents can be overridden.  
  See: [Global Identifier Generation Conventions](../../client-api/configuration/identifier-generation/global#findtypetagname-and-finddynamictagname). 

----

**When creating a new document through the Studio:**  

* The collection metadata is generated **based on the document ID prefix**.  
  e.g  Documents that are created with the following IDs: `users|23` / `users/45` / `users/17`  
  will all belong to the same `Users` collection.  

* For more information see [Documents and Collections](../../studio/database/documents/documents-and-collections)  
{PANEL/}

{PANEL: Collection Usages}

* **A Collection Query**
  * RavenDB keeps an internal storage index per collection created.  
    This internal index is used to query the database and retrieve only documents from a specified collection.  

* **In Indexing**
  * Each [Map Index](../../indexes/map-indexes) is built against a single collection (or muliple collections when using a [Multi-Map Index](../../indexes/multi-map-indexes).  
    During the indexing process, the index function iterates only over the documents that belong to the specified collection(s).  

* **In Revisions**
  * Documents [Revisions](../../server/extensions/revisions) can be defined per collection.  

* **In Ongoing Tasks**
  * A [RavenDB ETL Task](../../server/ongoing-tasks/etl/raven) & [SQL ETL Task](../../server/ongoing-tasks/etl/sql) are defined on specified collections.  

* **The @hilo Collection**
  * The ranges of available IDs values returned by [HiLo algorithm](../../client-api/document-identifiers/hilo-algorithm) are per collection name.  
    Learn more in: [The @hilo Collection](../../studio/database/documents/documents-and-collections#the-@hilo-collection)  

* **The @empty Collection**
  * Learn more in: [The @empty Collection](../../studio/database/documents/documents-and-collections#the-@empty-collection)  

{PANEL/}

----

## Related Articles

### Studio
- [Documents and Collections](../../studio/database/documents/documents-and-collections)  

### Client API
- [Document ID Generation](../../client-api/document-identifiers/working-with-document-identifiers)  
- [Identifiers Generation - Summary](../../server/kb/document-identifier-generation)  
