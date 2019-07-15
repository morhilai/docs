﻿# Create Multi-Map Index
---

{NOTE: }

* A **Multi-Map index** allows to index data from _multiple_ different collections.  

* RavenDB will generate a _single_ Multi-Map index.  
  The results of querying the Multi-Map index will include data from _all_ these collections.  

* Multi-Map indexes require that all the Map functions defined have the _same_ output structure.  

* In this page:  
  * [Creating Multi-Map index](../../../studio/database/indexes/create-map-index#edit-index-view)  
{NOTE/}

---

{PANEL: Creating Multi-Map index}

**Define a Map Function:**  
![Figure 1. Initial Map Function](images/create-multi-map-index-1.png)  

{NOTE: }

The `Collection` field indexed in the above example is not mandatory but can be useful upon querying.
{NOTE/}
<br/>

**Add another Map Function:**  
![Figure 2. Add Another Map Function](images/create-multi-map-index-2.png)  

{NOTE: }

* Any number of additional Map functions can be added.  

* Each added Map should have the **same** output fields.  
  i.e. In the above example, the common indexed fields are: `Name` & `Collection`.  

* So when querying on this Multi-Map index, results will come from **both** Employees collection and Companies collection.  

* [Index field options](../../../studio/database/indexes/create-map-index#index-fields-options), 
  [Configuration](../../../studio/database/indexes/create-map-index#configuration) & 
  [Additional Sources](../../../studio/database/indexes/create-map-index#additional-sources) 
  can be defined for the Multi-Map index in the same way as done for a [Simple Map Index](../../../studio/database/indexes/create-map-index#create-multi-map-index).  
{NOTE/}
{PANEL/}


## Related Articles

### Indexes
- [Map Indexes](../../../indexes/map-indexes)
- [Multi-Map Indexes](../../../indexes/multi-map-indexes)
- [Map-Reduce Indexes](../../../indexes/map-reduce-indexes)

### Studio
- [Indexes Overview](../../../studio/database/indexes/indexes-overview)
- [Indexes List View](../../../studio/database/indexes/indexes-list-view)
- [Create Map Index](../../../studio/database/indexes/create-map-index)
- [Create Map-Reduce Index](../../../studio/database/indexes/create-map-reduce-index)

