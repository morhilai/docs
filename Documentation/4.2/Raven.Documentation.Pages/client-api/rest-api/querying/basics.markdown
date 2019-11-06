# Basic Queries

---

{NOTE: }

* Use this endpoint with the **`POST`** method to send queries to the database:  
`<server URL>/databases/<database name>/queries`  

* All queries are ultimately expressed in [RQL](../../../indexes/querying/what-is-rql), our user friendly SQL-like query language.  

* This page covers the simplest possible queries - `from <collection>` and `from <index>`  

* In this page:  
  * [Basic Examples](../../../client-api/rest-api/querying/basics#basic-examples)  
  * [Request Format](../../../client-api/rest-api/querying/basics#request-format)  
  * [Response Format](../../../client-api/rest-api/querying/basics#response-format)  

{NOTE/}

---

{PANEL: Basic Examples}

This cURL request sends a query to the database "Example" on our [playground server](http://live-test.ravendb.net).  
The query asks for all the documents in the collection `Shippers`.  

{CODE-BLOCK: bash}
curl -X GET "http://live-test.ravendb.net/databases/Example/queries"
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

{CODE-BLOCK: bash}
curl -X GET "http://live-test.ravendb.net/databases/Example/queries"
-d "{ \"Query\": \"from Employees where FirstName = 'Robert'\" }"
{CODE-BLOCK/}
Linebreaks are added for clarity.  

To satisfy the above query, RavenDB has created a new [auto index]() called `Auto/Employees/ByFirstName`. Let us now ~say amen~ specifically query this index:

{CODE-BLOCK: bash}
curl -X GET "http://live-test.ravendb.net/databases/Example/queries"
-d "{ \"Query\": \"from index 'Auto/Employees/ByFirstName'\" }"
{CODE-BLOCK/}

It simply retrieves all documents from the collection `Employees`, the same result as querying the collection directly.

{PANEL/}

{PANEL: Request Format}

This the general format of the cURL request:

{CODE-BLOCK: batch}
curl -X GET "<server URL>/databases/<database name>/docs?
            &debug=<debug>
            &pageSize=<integer>
            &metadata=<boolean>"
--header "If-None-Match: <hash>"
{CODE-BLOCK/}

####Query String Parameters

| Parameter | Description | Required  |
| - | - | - |
| **debug** |  | No |
| **diagnostics** |  | No |
| **metadataOnly** | Set this parameter to `true` to retrieve only the document metadata for each result. | No |
| **includeServerSideQuery** |  | No |

Debug values: entries,explain,serverSideQuery,graph,detailedGraphResult,

####Headers

| Header | Description | Required |
| - | - | - |
| **If-None-Match** | This header takes a hash representing the previous results of an **identical** request. The hash is found in the response header `ETag`. If the results were not modified since the previous request, the server responds with http status code `304`, and the requested documents are retrieved from a local cache rather than over the network. | No |
