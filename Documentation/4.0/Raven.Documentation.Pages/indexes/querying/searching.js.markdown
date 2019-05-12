# Querying: Searching

When you need to do a more complex text searching, use the `search` method. This method allows you to pass a few search terms that will be used in the searching process for a particular field. Here is a sample code
that uses the `search` method to get users with the name *John* or *Adam*:

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_3_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where search(name, 'John Adam')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

Each of the search terms (separated by space character) will be checked independently. The result documents must match exactly one of the passed terms.

In the same way, you can also look for users that have some hobby:

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_4_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where search(name, 'looking for someone who likes sport books computers')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

The results will return users that are interested in *sport*, *books* or *computers*.

## Multiple Fields

By using the `search()` method, you are also able to look for multiple indexed fields. In order to search using both `name` and `hobbies` properties, you need to issue the following query:

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_5_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where search(name, 'Adam') or search(hobbies, 'sport')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

## Boosting

Indexing in RavenDB is built upon the Lucene engine that provides a boosting term mechanism. This feature introduces the relevance level of matching documents based on the terms found. 
Each search term can be associated with a boost factor that influences the final search results. The higher the boost factor, the more relevant the term will be. 
RavenDB also supports that, in order to improve your searching mechanism and provide the users with much more accurate results you can specify the boost argument. 

For example:

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_6_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where boost(search(hobbies, 'I love sport'), 10) or boost(search(hobbies, 'but also like reading books'), 5)
{CODE-TAB-BLOCK/}
{CODE-TABS/}

This search will promote users who do sports before book readers and they will be placed at the top of the results list.

## Search Options

You can specify the logic of a search expression. It can be either:

* or,
* andAlso,
* not.

The following query:

{CODE:nodejs search_7_0@indexes\querying\searching.js /}

will be translated into

{CODE-BLOCK:csharp}
from Users
where search(hobbies, 'computers') or search(name, 'James') and Age = 20
{CODE-BLOCK/}

You can also specify what exactly the query logic should be. The applied option will influence a query term where it was used. The query as follows:

{CODE:nodejs search_8_0@indexes\querying\searching.js /}

will result in the following RQL query:

{CODE-BLOCK:csharp}
from Users
where search(name, 'Adam') and search(hobbies, 'sport')
{CODE-BLOCK/}

If you want to negate the term use `not`:

{CODE:nodejs search_9_0@indexes\querying\searching.js /}

According to RQL syntax it will be transformed into the query:

{CODE-BLOCK:csharp}
from Users
where exists(name) and not search(name, 'Adam')
{CODE-BLOCK/}

You can also combine search options:

{CODE:nodejs search_10_1@indexes\querying\searching.js /}

It will produce the following RQL query:

{CODE-BLOCK:csharp}
from Users
where search(name, 'Adam') and (exists(hobbies) and not search(hobbies, 'sport'))
{CODE-BLOCK/}

## Using Wildcards

When the beginning or ending of a search term is unknown, wildcards can be used to add additional power to the searching feature. RavenDB supports both suffix and postfix wildcards.

### Example I - Using Postfix Wildcards

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_11_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where search(name, 'Jo* Ad*')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

### Example II - Using Suffix and Postfix Wildcards

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_12_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from Users
where search(name, '*oh* *da*')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

{WARNING:Warning}
RavenDB allows you to search by using such queries, but you have to be aware that **leading wildcards drastically slow down searches**.

Consider if you really need to find substrings. In most cases, looking for whole words is enough. There are also other alternatives for searching without expensive wildcard matches, e.g. indexing a reversed version of text field or creating a custom analyzer.
{WARNING/}

## Static Indexes

All of the previous examples demonstrated searching capabilities by executing dynamic queries and were using auto indexes underneath. The same set of queries can be done when static indexes are used, and also those capabilities can be customized by changing the [analyzer](../using-analyzers) or setting up full text search on multiple fields.

### Example I - Basics

To be able to search you need to set `Indexing` to `Search` on a desired field.

{CODE:nodejs search_20_2@indexes\querying\searching.js/}

{CODE-TABS}
{CODE-TAB:nodejs:Node.js search_20_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from index 'Users/ByName'
where search(name, 'John')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

### Example II - FullTextSearch

{CODE-TABS}
{CODE-TAB:nodejs:Query search_21_0@indexes\querying\searching.js /}
{CODE-TAB-BLOCK:sql:RQL}
from index 'Users/Search'
where search(query, 'John')
{CODE-TAB-BLOCK/}
{CODE-TABS/}

## Related Articles

### Indexes

- [Boosting](../../indexes/boosting)

### Querying

- [Boosting](../../indexes/querying/boosting)

### Client API

- [How to Use Search](../../client-api/session/querying/how-to-use-search)
