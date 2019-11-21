﻿# Query the Database

---

{NOTE: }

* Use this endpoint with the **`POST`** method to query the database:  
`<server URL>/databases/<database name>/queries`  

* Queries are written in [RQL](../../../indexes/querying/what-is-rql), our user friendly SQL-like query language.  

* In this page:  
  * [Basic Example](../../../client-api/rest-api/queries/query-the-database#basic-example)  
  * [Request Format](../../../client-api/rest-api/queries/query-the-database#request-format)  
  * [Response Format](../../../client-api/rest-api/queries/query-the-database#response-format)  
  * [More Examples](../../../client-api/rest-api/queries/query-the-database#more-examples)  

{NOTE/}

---

{PANEL: Basic Example}

This cURL request queries the [collection](../../../client-api/faq/what-is-a-collection) `Shippers` in a database named 
"Example" on our [playground server](http://live-test.ravendb.net):  

{CODE-BLOCK: bash}
curl -X POST "http://live-test.ravendb.net/databases/Example/queries"
-d "{ \"Query\": \"from Shippers\" }"
{CODE-BLOCK/}
Linebreaks are added for clarity.  

Response:  

{CODE-BLOCK: http}
HTTP/1.1 200 OK
Date: Wed, 06 Nov 2019 15:54:15 GMT
Content-Type: application/json; charset=utf-8
Server: Kestrel
ETag: -786759538542975908
Vary: Accept-Encoding
Raven-Server-Version: 4.1.9.41023
Request-Time: 0
Content-Length: 1103

{
    "TotalResults": 3,
    "SkippedResults": 0,
    "DurationInMs": 0,
    "IncludedPaths": null,
    "IndexName": "collection/Shippers",
    "Results": [
        {
            "Name": "Speedy Express",
            "Phone": "(503) 555-9831",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:8529-+pXj/MXEzkeiuFCvLdipcw, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "shippers/1-A",
                "@last-modified": "2018-07-27T12:11:53.0317375Z"
            }
        },
        {
            "Name": "United Package",
            "Phone": "(503) 555-3199",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:8531-+pXj/MXEzkeiuFCvLdipcw, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "shippers/2-A",
                "@last-modified": "2018-07-27T12:11:53.0317596Z"
            }
        },
        {
            "Name": "Federal Shipping",
            "Phone": "(503) 555-9931",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:8533-+pXj/MXEzkeiuFCvLdipcw, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "shippers/3-A",
                "@last-modified": "2018-07-27T12:11:53.0317858Z"
            }
        }
    ],
    "Includes": {},
    "IndexTimestamp": "0001-01-01T00:00:00.0000000",
    "LastQueryTime": "0001-01-01T00:00:00.0000000",
    "IsStale": false,
    "ResultEtag": -786759538542975908,
    "NodeTag": "A"
}
{CODE-BLOCK/}

{PANEL/}

{PANEL: Request Format}

This is the general format of a cURL request that uses all query string parameters:

{CODE-BLOCK: batch}
curl -X POST "<server URL>/databases/<database name>/docs?
            &includeServerSideQuery=<boolean>
            &metadata=<boolean>
            &debug=<debug>"
--header "If-None-Match: <hash>"
-d "{ }"
{CODE-BLOCK/}
Linebreaks are added for clarity.  
<br/>
#### Query String Parameters

| Parameter | Description | Required |
| - | - | - |
| **includeServerSideQuery** | Adds the RQL query that is run on the server side, which may look slightly different than the query sent | No |
| **metadataOnly** | Set this parameter to `true` to retrieve only the document metadata from each result | No |
| **debug** | Takes various values, listed in the table below, that modify the results or add information | No |

| `debug` Values | Description |
| - | - |
| **entries** | Returns the index entries instead of the complete documents, meaning only those fields that are indexed by the queried index |
| **explain** | Can be used only for queries on [auto index](../../../indexes/creating-and-deploying#auto-indexes).<br/>Returns _only_ the name of the index that can be used to satisfy this query. If no appropriate index could be found, returns the next best index with an explanation of why it is not appropriate for this query, e.g. it does not index the necessary fields.<br/>If debug is set to `explain` and no index could be found, the query will _not_ trigger the creation of an auto index as it normally would. |
| **serverSideQuery** | Returns _only_ the RQL query that is run on the server side, which may look slightly different than the query sent |
| **graph** | Returns analyzed graph query results |
| **detailedGraphResult** | Results arranged according to parts of the query |

#### Headers

| Header | Description |Required|
| - | - | - |
| **If-None-Match** | This header takes a `long` int representing the previous results of an **identical** request. The value is found in the response header `ETag`. If the results were not modified since the previous request, the server responds with http status code `304`, and the requested documents are retrieved from a local cache rather than over the network. | No |

#### Body

This is the general format of the request body:

{CODE-BLOCK: powershell}
-d "{
    \"Query\": \"<RQL query referencing $<name>>\",
    \"QueryParameters\": {
        \"<name>\":\"<parameter>\",
        ...
    }
}"
{CODE-BLOCK/}
Depending on the shell you're using to run cURL, you will probably need to escape all 
double quotes within the request body using a backslash: `"` -> `\"`.  

| Parameter | Description |
| - | - |
| **Query** | A query in RQL. You can insert parameters from the `QueryParameters` object with `$<parameter name>` |
| **QueryParameters** | A list of values that can be used in the query, such as strings, ints, or documents IDs. Inputs from your users should always be passed as query parameters to avoid SQL injection attacks, and in general it's best practice to pass all your right-hand operands as parameters. |

{PANEL/}

{PANEL: Response Format}

#### Http Status Codes

| Code | Description |
| - | - |
| `200` | Results are successfully retrieved, including the case where there are 0 results |
| `304` | In response to a query with the `If-None-Match` header: the same index was used to satisfy the query, and none of the requested documents were modified since they were last loaded, so they were not retrieved from the server. (They are retrieved from the local cache instead). |
| `404` | The specified index could not be found. In the case where a specified collection could not be found, see status code `200`. |
| `500` | Invalid query |

#### Body

Retrieved documents are sorted in ascending order of their [change vectors](../../../server/clustering/replication/change-vector). 

{CODE-BLOCK: javascript}
{
    "TotalResults": <int>,
    "SkippedResults": <int>,
    "CappedMaxResults": <int>,
    "DurationInMs": <int>,
    "IncludedPaths": [
        "<path to document ID>",
        ...
    ],
    "IndexName": "<string>",
    "Results": [ 
        { 
            <document contents>
        },
        ...
    ],
    "Includes":
        "<document ID>": {
            <document contents>
        },
        "<document ID>": { },
        ...
    },
    "IndexTimestamp": "<DateTime>",
    "LastQueryTime": "<DateTime>",
    "IsStale": <boolean>,
    "ResultEtag": <long>,
    "NodeTag": "<node tag>",
    "Timings": { },
    "ServerSideQuery"
}
{CODE-BLOCK/}

| Field | Description |
| - | - |
| **TotalResults** | The total number of results of the query |
| **CappedMaxResults** | The page size, if paging was used. If not, this field will not appear. |
| **SkippedResults** | The number of results that were skipped, e.g. because there were [duplicates](../../../indexes/querying/distinct) |
| **DurationInMs** | Number of milliseconds it took to satisfy the query on the server side |
| **IncludedPaths** | Array of the paths within the queried documents to the [included document](../../../client-api/how-to/handle-document-relationships#includes) IDs. Default: `null` |
| **IndexName** | Name of the index used to satify the query |
| **Results** | List of documents returned by the query |
| **Includes** | List of included documents returned by the query |
| **IndexTimestamp** | The last time the index was updated |
| **LastQueryTime** | The timestamp of the last time the index was queried |
| **IsStale** | Whether the results are [stale](../../../indexes/stale-indexes) |
| **ResultEtag** | The ETag value for this index current state, which include what docs were indexed, what document were deleted, etc. |
| **NodeTag** | The timestamp of the last time the index was queried |
| **Timings** | If [requested](../../../client-api/session/querying/debugging/query-timings), the amount of time the query operation took to complete on the server side, and a breakdown of the duration of each stage of the operation. See the structure of the `Timings` object below. |

#### The `Timings` object

`Timings` has a hierarchical structure representing the different stages and sub-stages of the query operation, and the amount of 
time each of them took to complete. Examples of these stages might be the query itself or the amount of time the server waited for 
an index not to be stale. Stages are listed in alphabetical order. Each stage contains a `DurationInMs` field with the total 
number of milliseconds the stage took, and _another_ `Timings` field containing a list of sub-stages. If a stage has no sub-stages, 
the value of its `Timings` field is `null`. The duration values are rounded to the nearest whole number, and the durations of 
sub-stages roughly add up to the duration of the parent stage.  

{CODE-BLOCK: javascript}
"Timings": {
    "DurationInMs": <int>,
    "Timings": {
        "<stage name>": {
            "DurationInMs": <int>,
            "Timings": {
                "<sub-stage name>": { },
                ...
            },
        "<stage name>": { },
        ...
    }
}
{CODE-BLOCK/}

{PANEL/}

{PANEL: More Examples}

[About Northwind](../../../getting-started/about-examples), the database used in our examples.

In this section:  

* [Include Related Documents](../../../client-api/rest-api/queries/query-the-database#include-related-documents)  
* [Page Results](../../../client-api/rest-api/queries/query-the-database#page-results)  
* [Get Timing Details](../../../client-api/rest-api/queries/query-the-database#get-timing-details)  

---

### Include Related Documents

Request:

{CODE-BLOCK: bash}
curl -X POST "http://live-test.ravendb.net/databases/Example/queries"
-d "{ \"Query\": \"from Products where Name = 'Chocolade' include Supplier, Category\" }"
{CODE-BLOCK/}

Response:

{CODE-BLOCK: HTTP}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 21 Nov 2019 14:55:59 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: -829128196141269816
Vary: Accept-Encoding
Raven-Server-Version: 4.2.5.42
Request-Time: 166

{
    "TotalResults": 1,
    "SkippedResults": 0,
    "DurationInMs": 165,
    "IncludedPaths": [
        "Supplier",
        "Category"
    ],
    "IndexName": "Auto/Products/ByName",
    "Results": [
        {
            "Name": "Chocolade",
            "Supplier": "suppliers/22-A",
            "Category": "categories/3-A",
            "QuantityPerUnit": "10 pkgs.",
            "PricePerUnit": 12.7500,
            "UnitsInStock": 22,
            "UnitsOnOrder": 15,
            "Discontinued": false,
            "ReorderLevel": 25,
            "@metadata": {
                "@collection": "Products",
                "@change-vector": "A:285-axxGtO/AJUGOLMLrpcu8hA",
                "@id": "products/48-A",
                "@index-score": 4.65065813064575,
                "@last-modified": "2018-07-27T12:11:53.0300420Z"
            }
        }
    ],
    "Includes": {
        "suppliers/22-A": {
            "Contact": {
                "Name": "Dirk Luchte",
                "Title": "Accounting Manager"
            },
            "Name": "Zaanse Snoepfabriek",
            "Address": {
                "Line1": "Verkoop Rijnweg 22",
                "Line2": null,
                "City": "Zaandam",
                "Region": null,
                "PostalCode": "9999 ZZ",
                "Country": "Netherlands",
                "Location": null
            },
            "Phone": "(12345) 1212",
            "Fax": "(12345) 1210",
            "HomePage": null,
            "@metadata": {
                "@collection": "Suppliers",
                "@change-vector": "A:399-axxGtO/AJUGOLMLrpcu8hA",
                "@id": "suppliers/22-A",
                "@last-modified": "2018-07-27T12:11:53.0335729Z"
            }
        },
        "categories/3-A": {
            "Name": "Confections",
            "Description": "Desserts, candies, and sweet breads",
            "@metadata": {
                "@attachments": [
                    {
                        "Name": "image.jpg",
                        "Hash": "1QxSMa3tBr+y8wQYNre7E9UJFFVTNWGjVoC+IC+gSSs=",
                        "ContentType": "image/jpeg",
                        "Size": 47955
                    }
                ],
                "@collection": "Categories",
                "@change-vector": "A:2092-axxGtO/AJUGOLMLrpcu8hA",
                "@flags": "HasAttachments",
                "@id": "categories/3-A",
                "@last-modified": "2018-07-27T12:16:44.1738714Z"
            }
        }
    },
    "IndexTimestamp": "2019-11-21T14:55:59.4797461",
    "LastQueryTime": "2019-11-21T14:55:59.4847597",
    "IsStale": false,
    "ResultEtag": -829128196141269816,
    "NodeTag": "A"
}
{CODE-BLOCK/}

#### Paging Results

This request uses the `limit` keyword to skip the first 5 results and retrieve the next 2:

{CODE-BLOCK: bash}
curl -X POST "http://live-test.ravendb.net/databases/Example/queries"
-d "{ \"Query\": \"from index 'Product/Search' limit 5, 2 \" }"
{CODE-BLOCK/}

Response:

{CODE-BLOCK: HTTP}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 21 Nov 2019 15:25:45 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: 7666904607700231125
Vary: Accept-Encoding
Raven-Server-Version: 4.2.5.42
Request-Time: 0

{
    "TotalResults": 77,
    "CappedMaxResults": 2,
    "SkippedResults": 0,
    "DurationInMs": 0,
    "IncludedPaths": null,
    "IndexName": "Product/Search",
    "Results": [
        {
            "Name": "Grandma's Boysenberry Spread",
            "Supplier": "suppliers/3-A",
            "Category": "categories/2-A",
            "QuantityPerUnit": "12 - 8 oz jars",
            "PricePerUnit": 25.0000,
            "UnitsInStock": 3,
            "UnitsOnOrder": 120,
            "Discontinued": false,
            "ReorderLevel": 25,
            "@metadata": {
                "@collection": "Products",
                "@change-vector": "A:201-axxGtO/AJUGOLMLrpcu8hA",
                "@id": "products/6-A",
                "@index-score": 1,
                "@last-modified": "2018-07-27T12:11:53.0274169Z"
            }
        },
        {
            "Name": "Uncle Bob's Organic Dried Pears",
            "Supplier": "suppliers/3-A",
            "Category": "categories/7-A",
            "QuantityPerUnit": "12 - 1 lb pkgs.",
            "PricePerUnit": 30.0000,
            "UnitsInStock": 3,
            "UnitsOnOrder": 15,
            "Discontinued": false,
            "ReorderLevel": 10,
            "@metadata": {
                "@collection": "Products",
                "@change-vector": "A:203-axxGtO/AJUGOLMLrpcu8hA",
                "@id": "products/7-A",
                "@index-score": 1,
                "@last-modified": "2018-07-27T12:11:53.0275119Z"
            }
        }
    ],
    "Includes": {},
    "IndexTimestamp": "2019-11-21T14:55:01.6473995",
    "LastQueryTime": "2019-11-21T15:25:45.7308416",
    "IsStale": false,
    "ResultEtag": 7666904607700231125,
    "NodeTag": "A"
}
{CODE-BLOCK/}

### Get Timing Details

In this request we see a query on the `Orders` collection, filtering by the fields `Employee` and `Company` (incidentally, both point to related documents), and a projection that selects only the `Freight` and `ShipVia` fields to be retrieved from the server. Finally, using the same syntax as for related documents shown above, it asks for `timings()`.

{CODE-BLOCK: bash}
curl -X POST "http://live-test.ravendb.net/databases/Example/queries?"
-d "{\"Query\": \"from Orders 
              where Employee = 'employees/1-A' 
              and Company = 'companies/91-A' 
              select Freight, ShipVia 
              include timings()\"}"
{CODE-BLOCK/}

Response:
[Skip to `Timings`]()

{CODE-BLOCK: http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 21 Nov 2019 16:58:32 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: -1802145387109965474
Vary: Accept-Encoding
Raven-Server-Version: 4.2.5.42
Request-Time: 214

{
    "TotalResults": 2,
    "SkippedResults": 0,
    "DurationInMs": 213,
    "IncludedPaths": null,
    "IndexName": "Auto/Orders/ByCompanyAndEmployee",
    "Results": [
        {
            "Freight": 3.94,
            "ShipVia": "shippers/3-A",
            "@metadata": {
                "@projection": true,
                "@change-vector": "A:45767-axxGtO/AJUGOLMLrpcu8hA, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@flags": "HasRevisions",
                "@id": "orders/127-A",
                "@index-score": 6.3441801071167,
                "@last-modified": "2018-07-27T12:11:53.0677162Z"
            }
        },
        {
            "Freight": 23.79,
            "ShipVia": "shippers/3-A",
            "@metadata": {
                "@projection": true,
                "@change-vector": "A:46603-axxGtO/AJUGOLMLrpcu8hA, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@flags": "HasRevisions",
                "@id": "orders/545-A",
                "@index-score": 6.3441801071167,
                "@last-modified": "2018-07-27T12:11:53.1390160Z"
            }
        }
    ],
    "Includes": {},
    "IndexTimestamp": "2019-11-21T16:58:32.8180797",
    "LastQueryTime": "2019-11-21T16:58:32.8179978",
    "IsStale": false,
    "ResultEtag": -1802145387109965474,
    "NodeTag": "A",
{CODE-BLOCK/}

At the end of the response body we see the `Timings` object which shows all the stages of the operation listed in alphabetical order. In this case there was an `Optimizer` stage, during which a new dynamic index was created to satisfy the query. The name of this new index is shown at the top of the body: `Auto/Orders/ByCompanyAndEmployee`. Next came a `Staleness` stage during which the indexing itself took place. Lastly came the `Query` stage itself. This included a [Lucene search engine](https://lucene.apache.org/) substage and a `Retriever` substage. As you can see, since the index has already done all the work, the query itself takes less than a millisecond. Now all future queries on this index will also take the server a millisecond or less to complete.

{CODE-BLOCK: javascript}
    "Timings": {
        "DurationInMs": 213,
        "Timings": {
            "Optimizer": {
                "DurationInMs": 46,
                "Timings": null
            },
            "Query": {
                "DurationInMs": 0,
                "Timings": {
                    "Lucene": {
                        "DurationInMs": 0,
                        "Timings": null
                    },
                    "Retriever": {
                        "DurationInMs": 0,
                        "Timings": {
                            "Projection": {
                                "DurationInMs": 0,
                                "Timings": {
                                    "Storage": {
                                        "DurationInMs": 0,
                                        "Timings": null
                                    }
                                }
                            }
                        }
                    }
                }
            },
            "Staleness": {
                "DurationInMs": 165,
                "Timings": null
            }
        }
    }
}
{CODE-BLOCK/}

{PANEL/}
