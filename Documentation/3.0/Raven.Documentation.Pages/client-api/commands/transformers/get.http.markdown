# Commands: Transformers: Get

There are few methods that allow you to retrieve transformers from a database:   
- [GetTransformer](../../../client-api/commands/transformers/get#gettransformer)   
- [GetTransformers](../../../client-api/commands/transformers/get#gettransformers)   

{PANEL:GetTransformer}

**GetTransformer** is used to retrieve a single transformer

### Syntax

{CODE-BLOCK:json}
curl \
	http://{serverName}/databases/{databaseName}/transformers/{transformerName} \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **transformerName** | Yes |   transformer name |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| payload | [TransformerDefinition](../../../glossary/transformer-definition)  |

<hr />

### Example

{CODE-BLOCK:json}
curl -X GET "http://localhost:8080/databases/NorthWind/transformers/Order/Statistics"
< HTTP/1.1 200 OK
{
	"Transformer":
	{
		"TransformResults":"from order in results select new { 
		    order.OrderedAt,     
			order.Status,     
			order.CustomerId,     
			CustomerName = LoadDocument(order.CustomerId).Name,     
			LinesCount = order.Lines.Count }",
		"TransfomerId":2,
		"Name":"Order/Statistics"
	}
}
{CODE-BLOCK/}

{PANEL/}

{PANEL:GetTransformers}

**GetTransformers** is used to retrieve a multiple transformers

### Syntax


{CODE-BLOCK:json}
curl \
	http://{serverName}/databases/{databaseName}/transformers? \
		&start={start} \
		&pageSize={pageSize} \
	-X GET
{CODE-BLOCK/}

### Request

| Query parameter | Required | Description |
| ------------- | -- | ---- |
| **start** | No | number of documents that should be skipped  |
| **pageSize** | No | maximum number of transformers that will be retrieved |

### Response

| Status code | Description |
| ----------- | - |
| `200` | OK |

| Return Value | Description |
| ------------- | ------------- |
| payload | array of [TransformerDefinition](../../../glossary/transformer-definition)  |

<hr />

### Example

{CODE-BLOCK:json}
curl -X GET "http://localhost:8080/databases/NorthWind/transformers?start=0&pageSize=10"
< HTTP/1.1 200 OK
[ transformerDefinition, transformerDefinition, ... ]
{CODE-BLOCK/}

{PANEL/}

## Related articles

- [PutTransformer](../../../client-api/commands/transformers/put)  
- [DeleteTransformer](../../../client-api/commands/transformers/delete)  
