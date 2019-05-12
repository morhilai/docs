# Indexes: Index Edit View

Whenever you want to add a new one or edit an existing index, you will be redirected to the `Index Edit View`. This view helps you shape the index definition by providing code-completion, formatters, C# code generator, and more.

## Action Bar

The following actions are available in the Action Bar:

- `Save` - saves an index on a server (if the index existed and the definition changed, then previous indexing data will be lost),
- `Add` - you can add another [mapping](../../../indexes/map-indexes) or [reducing](../../../indexes/map-reduce-indexes) function, define field, or spatial field, and determine max index outputs,
- `Format` - perform code formatting for mapping and reducing functions,
- `Query` - _edit only_ - redirects to the [Query View](../../../studio/overview/query/query-view),
- `Terms` - _edit only_ - redirects to the `Terms View` where you can view current index terms,
- `Copy` - opens a dialog where you can copy an index definition,
- `Generate C#` - creates an index definition class in C#,
- `Refresh` - fetches an index definition from the server,
- `Delete` - removes an index

![Figure 1. Studio. Index Edit View. Action Bar.](images/index-edit-view-action-bar.png)  

![Figure 2. Studio. Index Edit View.](images/index-edit-view-action-bar-2.png)  

## Index Renaming

A new feature in v3.5 is being able to rename an index without needing to re-run the indexing process.

To rename an index, make sure you're in the edit view and change the index name in the text box. Click save.  

![Figure 1. Studio. Index Rename.](images/indexes-rename-1.PNG)  

A warning message will be displayed asking whether to rename or create a new index.

![Figure 2. Studio. Index Rename message.](images/indexes-rename-2.PNG)  

## Related articles

- [Studio: Overview: Indexes : Indexes View](./indexes-view)
