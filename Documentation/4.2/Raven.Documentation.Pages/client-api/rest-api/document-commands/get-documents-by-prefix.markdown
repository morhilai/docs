﻿# Get Documents by Prefix

---
{NOTE: }  

* Use this endpoint with the `GET` method to retrieve documents from the database:  
`http://[server URL]/databases/[database name]/docs?startsWith=[document ID prefix]`  

* A request with no query string retrieves all documents from the database.  

* There are various query parameters for further filtering the results.  

* In this page:  
  * [Basic Example](../../../client-api/rest-api/document-commands/get-documents-by-prefix#basic-example)  
  * [Request Format](../../../client-api/rest-api/document-commands/get-documents-by-prefix#request-format)  
  * [Response Format](../../../client-api/rest-api/document-commands/get-documents-by-prefix#response-format)  
  * [More Examples](../../../client-api/rest-api/document-commands/get-documents-by-prefix#more-examples)  
      * [Get Using `matches`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-using)  
      * [Get Using `matches` and `exclude`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-usingand)  
      * [Get Using `startAfter`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-using-1)  
      * [Page Results](../../../client-api/rest-api/document-commands/get-documents-by-prefix#page-results)  
      * [Get Document Metadata Only](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-document-metadata-only)
{NOTE/}  

---

{PANEL:Basic Example}

This is a cURL request to our [playground server](http://live-test.ravendb.net), to a database named "Example", to retrieve all documents 
whose IDs begin with the prefix "ship":  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?startsWith=ship
{CODE-BLOCK/}

Actual response:  

{CODE-BLOCK: http}
HTTP/1.1 200 OK
Server: nginx
Date: Tue, 10 Sep 2019 15:25:34 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:2137-pIhs+72n6USJoZ5XIvTHvQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Name": "Speedy Express",
            "Phone": "(503) 555-9831",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:349-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/1-A",
                "@last-modified": "2018-07-27T12:11:53.0317375Z"
            }
        },
        {
            "Name": "United Package",
            "Phone": "(503) 555-3199",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:351-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/2-A",
                "@last-modified": "2018-07-27T12:11:53.0317596Z"
            }
        },
        {
            "Name": "Federal Shipping",
            "Phone": "(503) 555-9931",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:353-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/3-A",
                "@last-modified": "2018-07-27T12:11:53.0317858Z"
            }
        }
    ]
}
{CODE-BLOCK/}

{PANEL/}

{PANEL: Request Format}

This is the general form of a cURL request that uses all parameters:  

{CODE-BLOCK: bash}
curl -X GET http://[server URL]/databases/[database name]/docs?
            startsWith=[prefix]
            &matches=[suffix]|[suffix]|...
            &exclude=[suffix]|[suffix]|...
            &startAfter=[document ID]
            &start=[integer]
            &pageSize=[integer]
            &metadata=[boolean]
--header If-None-Match: [hash]
{CODE-BLOCK/}

####Query String Parameters

A request with no query string retrieves all documents from the database.  
Results are sorted in ascending [lexical order](https://en.wikipedia.org/wiki/Lexicographical_order)

| Parameter | Description | Required  |
| - | - | - |
| **startsWith** | Retrieve all documents whose IDs begin with this string. | Required |
| **matches** | Retrieve documents whose IDs are exactly `[startsWith]`+`[matches]`. Accepts multiple values separated by a pipe character: "\|". Use `?` to represent any single character, and `*` to represent any substring | Optional |
| **exclude** | _Exclude_ documents whose IDs are exactly `[startsWith]`+`[exclude]`. Accepts multiple values separated by a pipe character: "\|". Use `?` to represent any single character, and `*` to represent any substring | Optional |
| **startAfter** | Retrieve only the results after the first document ID that begins with this string | Optional |
| **start** | Number of results to skip | Optional |
| **pageSize** | Number of results to retrieve | Optional |
| **metadataOnly** | Set this parameter to `true` to retrieve only the document metadata for each result. | Optional |

####Headers

| Header | Description | Required |
| - | - | - |
| **If-None-Match** | This header takes a hash representing the previous results of an **identical** request. The hash is found in the response header `ETag`. If the results were not modified since the previous request, the server responds with http status code `304` and the requested documents are retrieved from a local hash rather than over the network. | Optional |

{PANEL/}

{PANEL:Response Format}

####Http Status Codes

| Code | Description |
| ----------- | - |
| `200` | Results were successfully retrieved |
| `304` | No documents were retrieved |

####Headers

| Header | Description |
| - | - |
| **Server** | Web server |
| **Date** | Date and time of response (UTC) |
| **Content-Type** | MIME media type and character encoding. This should always be: `application/json; charset=utf-8` |
| **ETag** | Hash representing the state of these results. If another, **identical** request is made, this hash can be sent in the `If-None-Match` header to check whether the retrieved documents have been modified since the last response. If none were modified. |
| **Raven-Server-Version** | Version of RavenDB that the responding server is running |

####Response Body

A retrieved document is identical in contents and format to the document stored in the server (unless the `metadataOnly` parameter is set to `true`).  

This is the general JSON format of the response body:  

{CODE-BLOCK: JSON}
{
    "Results": [ 
        { 
            "[field]":"[value]",
            ...
            "@metadata":{
                ...
            }
        },
        { ... },
        ...
    ]
}
{CODE-BLOCK/}

{PANEL/}

{PANEL: More Examples}

[About Northwind](../../../getting-started/about-examples), the database used in our examples.

In this section:  

* [Get Using `matches`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-using)  
* [Get Using `matches` and `exclude`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-usingand)  
* [Get Using `startAfter`](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-using-1)  
* [Page Results](../../../client-api/rest-api/document-commands/get-documents-by-prefix#page-results)  
* [Get Document Metadata Only](../../../client-api/rest-api/document-commands/get-documents-by-prefix#get-document-metadata-only)

---

####Get Using&nbsp;`matches`

Example cURL request:  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?
            startsWith=shipp
            &matches=ers/3-A|ers/1-A
{CODE-BLOCK/}

The response:  

{CODE-BLOCK: Http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 12 Sep 2019 10:57:58 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:5972-k50KTOC5G0mfVXKjomTNFQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Name": "Speedy Express",
            "Phone": "(503) 555-9831",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:349-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/1-A",
                "@last-modified": "2018-07-27T12:11:53.0317375Z"
            }
        },
        {
            "Name": "Federal Shipping",
            "Phone": "(503) 555-9931",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:353-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/3-A",
                "@last-modified": "2018-07-27T12:11:53.0317858Z"
            }
        }
    ]
}
{CODE-BLOCK/}

####Get Using&nbsp;`matches`&nbsp;and&nbsp;`exclude`

Example cURL request:  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?
            startsWith=shipp
            &matches=ers/3-A|ers/1-A
            &exclude=ers/3-A
{CODE-BLOCK/}

The response:  

{CODE-BLOCK: Http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 12 Sep 2019 12:24:50 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:5972-k50KTOC5G0mfVXKjomTNFQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Name": "Speedy Express",
            "Phone": "(503) 555-9831",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:349-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/1-A",
                "@last-modified": "2018-07-27T12:11:53.0317375Z"
            }
        }
    ]
}
{CODE-BLOCK/}

####Get Using&nbsp;`startAfter`

Example cURL request:  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?
            startsWith=shipp
            startAfter=shippers/1-A
{CODE-BLOCK/}

The response:  

{CODE-BLOCK: Http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 12 Sep 2019 12:37:39 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:5972-k50KTOC5G0mfVXKjomTNFQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Name": "United Package",
            "Phone": "(503) 555-3199",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:351-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/2-A",
                "@last-modified": "2018-07-27T12:11:53.0317596Z"
            }
        },
        {
            "Name": "Federal Shipping",
            "Phone": "(503) 555-9931",
            "@metadata": {
                "@collection": "Shippers",
                "@change-vector": "A:353-k50KTOC5G0mfVXKjomTNFQ",
                "@id": "shippers/3-A",
                "@last-modified": "2018-07-27T12:11:53.0317858Z"
            }
        }
    ]
}
{CODE-BLOCK/}

####Page Results

Example cURL request:  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?
            startsWith=product
            &start=50
            &pageSize=2
{CODE-BLOCK/}

The response:  

{CODE-BLOCK: Http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 12 Sep 2019 13:17:44 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:5972-k50KTOC5G0mfVXKjomTNFQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "Name": "Pâté chinois",
            "Supplier": "suppliers/25-A",
            "Category": "categories/6-A",
            "QuantityPerUnit": "24 boxes x 2 pies",
            "PricePerUnit": 24.0000,
            "UnitsInStock": 25,
            "UnitsOnOrder": 115,
            "Discontinued": false,
            "ReorderLevel": 20,
            "@metadata": {
                "@collection": "Products",
                "@change-vector": "A:8170-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "products/55-A",
                "@last-modified": "2018-07-27T12:11:53.0303784Z"
            }
        },
        {
            "Name": "Gnocchi di nonna Alice",
            "Supplier": "suppliers/26-A",
            "Category": "categories/5-A",
            "QuantityPerUnit": "24 - 250 g pkgs.",
            "PricePerUnit": 38.0000,
            "UnitsInStock": 26,
            "UnitsOnOrder": 21,
            "Discontinued": false,
            "ReorderLevel": 30,
            "@metadata": {
                "@collection": "Products",
                "@change-vector": "A:8172-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "products/56-A",
                "@last-modified": "2018-07-27T12:11:53.0304385Z"
            }
        }
    ]
}
{CODE-BLOCK/}

Note that the document ID numbers are 55 and 56 rather than the expected 51 and 52 because results are sorted lexically.

####Get Document Metadata Only

Example cURL request:  

{CODE-BLOCK: bash}
curl -X GET http://live-test.ravendb.net/databases/Example/docs?
            startsWith=regio
            &metadataOnly=true
{CODE-BLOCK/}

The response:  

{CODE-BLOCK: Http}
HTTP/1.1 200 OK
Server: nginx
Date: Thu, 12 Sep 2019 13:44:16 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
Connection: keep-alive
Content-Encoding: gzip
ETag: "A:5972-k50KTOC5G0mfVXKjomTNFQ"
Vary: Accept-Encoding
Raven-Server-Version: 4.2.4.42

{
    "Results": [
        {
            "@metadata": {
                "@collection": "Regions",
                "@change-vector": "A:9948-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "regions/1-A",
                "@last-modified": "2018-07-27T12:11:53.2016685Z"
            }
        },
        {
            "@metadata": {
                "@collection": "Regions",
                "@change-vector": "A:9954-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "regions/2-A",
                "@last-modified": "2018-07-27T12:11:53.2021826Z"
            }
        },
        {
            "@metadata": {
                "@collection": "Regions",
                "@change-vector": "A:9950-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "regions/3-A",
                "@last-modified": "2018-07-27T12:11:53.2018086Z"
            }
        },
        {
            "@metadata": {
                "@collection": "Regions",
                "@change-vector": "A:9952-k50KTOC5G0mfVXKjomTNFQ, A:1887-0N64iiIdYUKcO+yq1V0cPA, A:6214-xwmnvG1KBkSNXfl7/0yJ1A",
                "@id": "regions/4-A",
                "@last-modified": "2018-07-27T12:11:53.2019223Z"
            }
        }
    ]
}
{CODE-BLOCK/}

{PANEL/}

## Related Articles

### Client API 

- [Put Documents](../../../client-api/commands/documents/put)  
- [Delete Documents](../../../client-api/commands/documents/delete)
- [How to Send Multiple Commands Using a Batch](../../../client-api/commands/batches/how-to-send-multiple-commands-using-a-batch)
- [Counters: Overview](../../../client-api/session/counters/overview)
- [How to Handle Document Relationships](../../../client-api/how-to/handle-document-relationships#includes)

### Server

- [Change Vector](../../../server/clustering/replication/change-vector)
