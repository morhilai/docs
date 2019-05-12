# Commands: Indexes: Put


{PANEL:PutIndex}

**PutIndex** is used to insert an index into a database.

### Syntax

{CODE-BLOCK:json}
curl \
	http://{serverName}/databases/{databaseName}/indexes/{indexName}?definition=yes \
	-X PUT \
	-d @indexDefinition.txt
{CODE-BLOCK/}

| Payload |
| ------- |
| [Index Definition](../../../glossary/index-definition) |

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **indexName** | Yes | Name of an index |

### Response

| Status code | Description |
| ----------- | - |
| `201` | Created |

| Return Value | Description |
| ------------- | ----- |
| **Index** | Index **name** |

<hr />

### Example

{CODE-BLOCK:json}
curl -X PUT "http://localhost:8080/databases/NorthWind/indexes/Orders/Totals?definition=yes" \
 -d " {\"MaxIndexOutputsPerDocument\":null, \
	\"IndexId\":0, \
	\"Name\":null, \
	\"LockMode\":\"Unlock\", \
	\"Maps\":[\" from order in docs.Orders  select new  {     order.Employee,    order.Company,    Total = order.Lines.Sum(l => (l.Quantity * l.PricePerUnit) * (1 - l.Discount))}\"], \
	\"Reduce\":null, \
	\"Stores\":{}, \
	\"Indexes\":{}, \
	\"SortOptions\":{}, \
	\"Analyzers\":{}, \
	\"Fields\":[], \
	\"Suggestions\":{}, \
	\"TermVectors\":{}, \
	\"SpatialIndexes\":{}, \
	\"DisableInMemoryIndexing\":false, \
	\"Type\":\"Map\", \
	\"Map\":\" from order in docs.Orders  select new  {     order.Employee,    order.Company,    Total = order.Lines.Sum(l => (l.Quantity * l.PricePerUnit) * (1 - l.Discount))}\", \
	\"IsCompiled\":false, \
	\"IsMapReduce\":false} "
< HTTP/1.1 201 Created
{"Index":"Orders/Totals"}
{CODE-BLOCK/}

{PANEL/}

{PANEL:PutIndexes}

**PutIndexes** creates multiple indexes with specified names, using given index definitions and priorities.

### Syntax

{CODE-BLOCK:json}
curl \
	http://{serverName}/databases/{databaseName}/indexes \
	-X PUT \
	-d @indexesToAdd.txt
{CODE-BLOCK/}

| Payload |
| ------- |
| Array of [IndexToAdd](../../../glossary/index-to-add) objects |

### Response

| Status code | Description |
| ----------- | - |
| `201` | Created |

| Return Value | Description |
| ------------- | ----- |
| **Indexes[]** | Array of names of created indexes |

<hr />

### Example

{CODE-BLOCK:json}
curl -X PUT "http://localhost:8080/databases/NorthWind/indexes" \
 -d "[{'Name':'Orders/Totals', \
    'Definition':{ \
    'MaxIndexOutputsPerDocument':null, \
    'IndexId':0, \
    'Name':null, \
    'LockMode':'Unlock', \
    'Maps':['from order in docs.Orders  select new  {     order.Employee,    order.Company,    Total = order.Lines.Sum(l => (l.Quantity * l.PricePerUnit) * (1 - l.Discount))}'], \
    'Reduce':null, \
    'Stores':{}, \
    'Indexes':{}, \
    'SortOptions':{}, \
    'Analyzers':{}, \
    'Fields':[], \
    'Suggestions':{}, \
    'TermVectors':{}, \
    'SpatialIndexes':{}, \
    'DisableInMemoryIndexing':false, \
    'Type':'Map', \
    'Map':' from order in docs.Orders  select new  {     order.Employee,    order.Company,    Total = order.Lines.Sum(l => (l.Quantity * l.PricePerUnit) * (1 - l.Discount))}', \
    'IsCompiled':false, \
    'IsMapReduce':false \
    }, \
'Priority':'Normal'}, \
{'Name':'Product/Sales', \
    'Definition':{ \
    'MaxIndexOutputsPerDocument':null, \
    'IndexId':0, \
    'Name':null, \
    'LockMode':'Unlock', \
    'Maps':['from order in docs.Orders from line in order.Lines select new { Product = line.Product, Count = 1, Total = ((line.Quantity * line.PricePerUnit) *  ( 1 - line.Discount)) }'], \
    'Reduce':null, \
    'Stores':{}, \
    'Indexes':{}, \
    'SortOptions':{}, \
    'Analyzers':{}, \
    'Fields':[], \
    'Suggestions':{}, \
    'TermVectors':{}, \
    'SpatialIndexes':{}, \
    'DisableInMemoryIndexing':false, \
    'Type':'MapReduce', \
    'Map':'from order in docs.Orders from line in order.Lines select new { Product = line.Product, Count = 1, Total = ((line.Quantity * line.PricePerUnit) *  ( 1 - line.Discount)) }', \
    'IsCompiled':false, \
    'IsMapReduce':false \
    }, \
'Priority':'Normal'}]"
< HTTP/1.1 201 Created
{"Indexes":["Orders/Totals", "Product/Sales"]}
{CODE-BLOCK/}

{PANEL/}

## Related articles

- [How to **reset index**?](../../../client-api/commands/indexes/how-to/reset-index)  
- [GetIndex](../../../client-api/commands/indexes/get)  
- [DeleteIndex](../../../client-api/commands/indexes/delete)  
