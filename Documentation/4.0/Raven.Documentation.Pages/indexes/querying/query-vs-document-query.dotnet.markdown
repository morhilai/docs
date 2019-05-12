# Querying: Query vs DocumentQuery

Why does the RavenDB client offer two ways of querying by exposing the `Query` as well as `DocumentQuery` methods? What are the differences between them?

`DocumentQuery` is the lower level API that we use to query RavenDB, but it does not support LINQ, the mandatory data access solution in .NET. We created `Query` to be the LINQ endpoint for RavenDB. 

The entire LINQ API is a wrapper of `DocumentQuery` and is built on top on that. 
When you use `Query`, it always is translated into the `DocumentQuery` object, which then builds a RQL-syntax query that is sent to the server.
However, we still expose `DocumentQuery` in advanced options to allow the users to have the full power of RQL available to them. 

## Immutability

`DocumentQuery` is mutable while `Query` is immutable. You might get different results if you try to *reuse* a query. The usage of the `Query` method in the following example:

{CODE immutable_query@Indexes\Querying\QueryAndLuceneQuery.cs /}

will result that the queries will be translated into following Lucene-syntax queries:

`query - from Users where startsWith(Name, 'A')`

`ageQuery - from Users where startsWith(Name, 'A') and Age > 21`

`eyeQuery - from Users where startsWith(Name, 'A') and EyeColor = 'blue'`

The similar usage of `DocumentQuery`:

{CODE mutable_lucene_query@Indexes\Querying\QueryAndLuceneQuery.cs /}

`documentQuery - from Users where startsWith(Name, 'A')` (before creating `ageQuery`)

`ageLuceneQuery - from Users where startsWith(Name, 'A') and Age > 21` (before creating `eyeDocumentQuery`)

`eyeLuceneQuery - from Users where startsWith(Name, 'A') and Age > 21 and EyeColor = 'blue'`

In results, all created Lucene queries are the same query (actually the same instance). This is an important hint that you should be aware if you are going to reuse `DocumentQuery`.

## Default Query Operator

Starting from version 4.0, the `Query` and `DocumentQuery` have an identical default operator `AND` (previously `Query` used `AND` and `DocumentQuery` used `OR`). You are able to change this behavior by using `UsingDefaultOperator`:
        
{CODE default_operator@Indexes\Querying\QueryAndLuceneQuery.cs /}

## Related Articles

### Querying

- [Basics](../../indexes/querying/basics)

### Session 

- [How to Query](../../client-api/session/querying/how-to-query)
- [What is a Document Query](../../client-api/session/querying/document-query/what-is-document-query)
- [How to use Lucene](../../client-api/session/querying/document-query/how-to-use-lucene)
