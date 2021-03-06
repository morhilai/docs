﻿# Introduction to the REST API

---

{NOTE: }

* This page covers some basic information that will help you learn to use the REST API:  
  * How to use the CLI tool *cURL*.  
  * A description of the JSON format for the purposes of writing and parsing it.  
  * Some of the HTTP status codes used in the API.  

* To learn more about HTTP and REST in general, try these tutorials:  
  * [HTTP guide for developers by Mozilla](https://developer.mozilla.org/en-US/docs/Web/HTTP)
  * [REST API Tutorial website](https://www.restapitutorial.com/)

* In this page:
  * [cURL Basics](../../client-api/rest-api/rest-api-intro#curl-basics)
  * [Document Format and Structure](../../client-api/rest-api/rest-api-intro#document-format-and-structure)
  * [Using cURL With HTTPS](../../client-api/rest-api/rest-api-intro#using-curl-with-https)
  * [Common HTTP Status Codes](../../client-api/rest-api/rest-api-intro#common-http-status-codes)

{NOTE/}

---

{PANEL: cURL Basics}

A good way to familiarize yourself with the RavenDB REST API is with the command line tool cURL, which allows you to construct and 
send individual HTTP requests. You can download cURL from [curl.haxx.se](https://curl.haxx.se/download.html) (If you're using Linux 
your CLI may already have cURL installed). You can learn how to use it with the [cURL documentation](https://curl.haxx.se/docs/). 
This page just covers the basics you'll need to interact with RavenDB.  

All cURL commands begin with the keyword `curl` and contain the URL of your RavenDB server or one of its endpoints. This command retrieves the first document from 
a database named "Demo" located on our public [playground server](http://live-test.ravendb.net), and prints it in your CLI:  

{CODE-BLOCK: bash}
curl http://live-test.ravendb.net/databases/demo/docs?pagesize=1
{CODE-BLOCK/}

The other parameters of the HTTP request are specified using 'options'. These are the main cURL options that interest us:  

| Option | Purpose |
| - | - |
| -X | Set the [HTTP method](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html) that is sent with the request |
| -H | Add one or more headers, e.g. to provide extra information about the contents of the request body |
| -d | This option denotes the beginning of the body of the request. The body itself is wrapped with double quotes `"`. One of the ways to upload a document to the server is to send it in the body. |
| -T | Set the path to a file you want to upload, such as a document or attachment |
| --cert | (For https) the path to your certificate file |
| --key | (For https) the path to your private key file |

This request uploads a document to a database on the playground server from a local file:  

{CODE-BLOCK: bash}
curl -X PUT http://live-test.ravendb.net/databases/demo/docs?id=example -T <path to file>document.txt
{CODE-BLOCK/}
[More about how to upload documents](../../client-api/rest-api/document-commands/put-documents)

{PANEL/}

{PANEL: Document Format and Structure}

In RavenDB all documents have a standard [JSON](https://www.json.org/) format. In essence, every JSON object is composed of a series 
of key-value pairs. A document with a complex structure might look something like this:  

{CODE-BLOCK: JSON}
{
    "<key>": <value>,
    "<key>": "<string value>",
    "an array": [
        <value>,
        "<string value>",
        ...
    ],
    "an object": {
        "<key>": <value>,
        "<key>": "<string value>",
        ...
    },
    ...
}
{CODE-BLOCK/}

The whole object is wrapped in curly brackets `{}`. The `<key>` is always a string, and the `<value>` can be a string (denoted by 
double quotes), a number, a boolean, or null. The value can also be an array of values wrapped in square brackets `[]`, or it can itself be another JSON object 
wrapped in another pair of curly brackets. Whitespace is completely optional. In the above example and throughout the documentation, 
JSON is broken into multiple lines for the sake of clarity. When using cURL, the entire command including the request body 
needs to be on one line.  
</br>
#### Sending raw JSON using cURL
Sending raw JSON in the body faces us with a problem: the body itself is wrapped with double quotes `"`, 
so the double quotes within the JSON will be interpreted by the parser as the end of the body. The solution is to escape every double quote 
by putting a backslash `\` before it, like this:  

{CODE-BLOCK: bash}
-d "{
    \"a string\": \"some text\",
    \"a number\": 42
}"
{CODE-BLOCK/}
</br>
#### Binary data
In addition to JSON, pure binary data can be stored as an [attachment](../../document-extensions/attachments/what-are-attachments) 
associated with an existing document. Files can be added to the request with the `-T` option. Some types of requests, though, allow you to include raw binary in the body - such as the 
[Put Attachment Command](../../client-api/rest-api/document-commands/batch-commands#put-attachment-command).  

{PANEL/}

{PANEL: Using cURL With HTTPS}

HTTPS adds public-key encryption on top of standard HTTP to protect information during transit between client and server. It has 
become increasingly common throughout the internet in recent years. Our [setup wizard](../../start/installation/setup-wizard) makes 
it very simple to set up server secure using a free [Let's Encrypt](https://letsencrypt.org/) certificate.  

To communicate with a secure server over https, you need to specify the paths to the your client certificate and private key 
files with the `--cert` and `--key` options respectively:  

{CODE-BLOCK: bash}
curl --cert <path to your certificate file> --key <path to your private key file> "<server url>"
{CODE-BLOCK/}

These files can be found in the configuration Zip package you recieved at the end of the setup wizard. You can download this Zip package 
again by going to this endpoint: `<the URL of your server>/admin/debug/cluster-info-package`. The certificate and key are found at 
the root of the package with the names: `admin.client.certificate.<your domain name>.crt`, and 
`admin.client.certificate.<your domain name>.key` respectively.  

{PANEL/}

{PANEL: Common HTTP Status Codes}

These are a few of the HTTP status codes we use in our REST API, and what we mean by them:  

| Code | [Official IANA description](https://www.iana.org/assignments/http-status-codes/http-status-codes.xhtml) | Purpose |
| - | - | - |
| 200 | OK | Indicates that a valid request was received by the server, such as `GET` requests and queries. This includes cases where the response body itself is empty because the query returned 0 results. |
| 201 | Created | Confirms the success of document `PUT` requests |
| 304 | Not Modified | When prompted, the server can check if the requested data has been modified since the previous request. If it hasn't, the server responds with this status code to tell the client that it can continue to use the locally cached copy of the data. This is a mechanism we often use to minimize traffic over the network. |
| 404 | Not Found | Sometimes used to indicate that the request was valid but the requested data could not be found |
| 409 | Conflict | Indicates that the database has received [conflicting commands](../../server/clustering/replication/replication-conflicts). This happens in clusters when different nodes receive commands to modify the same data at the same time - before the modification could be passed on to the rest of the cluster. |
| 500 | Internal Server Error | Used for exceptions that occur on the server side |

{PANEL/}

## Related Articles

### Getting Started
- [Setup Wizard](../../start/installation/setup-wizard)

### REST API
- [Put Documents](../../client-api/rest-api/document-commands/put-documents)
- [Batch Commands](../../client-api/rest-api/document-commands/batch-commands)

### Server
- [Security Overview](../../server/security/overview)
