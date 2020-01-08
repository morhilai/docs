# Introduction to the Rest API

---

{NOTE:}

* This is a general introduction to using the RavenDB http API.

* In this page:
  * [How to Use cURL]()
  * https V
access certificate file
generic statuc codes V
document format V
failover
{NOTE/}

---

{PANEL: How to Use cURL}

A good way to familiarize yourself with the RavenDB rest API is with the command line tool cURL, which 
allows you to construct and send individual HTTP requests. You can download cURL from 
[curl.haxx.se](https://curl.haxx.se/download.html) (If you're using Linux, your CLI may already have 
cURL installed). You can learn how to use it with the [cURL documentation](https://curl.haxx.se/docs/), 
but here are the basics you'll need for the examples in this documentation:  

Every cURL command begins with the keyword `curl` and the URL of your RavenDB server. Specify the HTTP 
method with the option `-X` e.g. `-X POST`.  

For example, this request retrieves all documents from our public [playground server](http://live-test.ravendb.net):  

{CODE-BLOCK: bash}
curl -X GET "http://live-test.ravendb.net/databases/demo/docs"
{CODE-BLOCK/}

Some requests require special headers with the `-H` option.

Data is sent to the server in the body of the request, which is denoted with the option `-d` and wrapped 
with either single `'` or double-quotes `"`.  

### Document Format and Structure

In RavenDB all documents have a standard [JSON]() format. In brief, a JSON object has the following structure:  

{CODE-BLOCK: }

{CODE-BLOCK/}

In addition, binary data can be stored as an [attachment]() associated with an existing document. In HTTP requests, 
attachments can be sent as raw binary or text, demarcated by special markers.  

{PANEL/}

{PANEL: Common HTTP Status Codes}

Status codes commonly used in the API:

| Code | Official Meaning | Uses |
| - | - | - |
| 200 | OK | Indicates that a valid HTTP request was received by the server. Even if the request is valid, it doesn't necessarily mean that the query has any results i.e. a response with this code still might not contain data. |
| 201 | Created | Confirms the success of put requests |
| 304 | Not Modified | The server can check if the data was modified since the previous request. If it hasn't, the server responds with this status code so that the client knows it can continue to use the cached version of the documents.
| 404 | Not Found | Sometimes used to indicate that the request was valid but the specified data could not be found |
| 409 | Conflict | Indicates that the database has received [conflicting commands](). This happens in clusters when different nodes receive commands to modify the same data at the same time, before the modification could be passed to the rest of the cluster. |
| 500 | Internal Server Error | Used for exceptions that occur on the server |

{PANEL/}

{PANEL: HTTPS}

HTTPS adds public-key encryption to the standard  TP to protect information during transit between client and server. It has become 
more and more common in recent years. [Safe by default]() details set up by providing a certificate or using [let's encrypt]().  

Enabling HTTPS is necessary to use the [encryption at rest](../../server/security/encryption/encryption-at-rest) feature.  

By default, RavenDB redirects all incoming HTTP traffic on port 80 to HTTPS on port 443. This destination port 
can be [configured](../../server/configuration/security-configuration).  

[Manual Certificate Configuration](../../server/security/authentication/certificate-configuration)
When providing a certificate for authentication, you must also set the ServerUrl configuration option to an HTTPS address in the 
`settings.json` file.  

[HTTP Configuration](../../server/configuration/http-configuration) Whether Raven's HTTP server should allow response compression to 
happen when HTTPS is enabled.  

Mention ETL

[Setting up Authentication and Authorization](../../client-api/setting-up-authentication-and-authorization)

{PANEL/}

{PANEL: cluster zip file}
Contains cluster configuration information and authentication certificate???
{PANEL/}
