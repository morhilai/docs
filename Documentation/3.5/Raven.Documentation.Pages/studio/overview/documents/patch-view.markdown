# Documents: Patch View

Single documents, entire collections or query results can be patched using this view. More detailed information of JavaScript patching capabilities can be found [here](../../../client-api/commands/patches/how-to-use-javascript-to-patch-your-documents). 
This article focuses on the Studio's side of the patching.

## Action Bar

Action bar contains the following buttons:

- `Patch type selector` (single document, collection, or index),
- `Load` - saved patch scripts can be loaded using this action,
- `Save` - patch script can be saved to use this action later,
- `Recent Patches` - recent patch scripts can be loaded using this action,
- `Test` - you can test your patch here, without modifying actual data,
- `Patch Selected` - execute patch on actual data (only the selected document)
- `Patch All` - execute patch on actual data (on all matching documents in collection/index)

![Figure 1. Studio. Patch View. Action Bar.](images/patch-view-action-bar.png)  

## Patch Scripts

After specifying patch type, we need to do **one** of the following:

- select a document to patch by typing its key,
- select a collection that we want to patch,
- select an index and type a query that we want to use for patching

After doing that, we need to type our script (examples of scripts can be found [here](../../../client-api/commands/patches/how-to-use-javascript-to-patch-your-documents)) with parameters (if needed) and click on `Patch` button to apply it.

![Figure 2. Studio. Patch View. Script.](images/patch-view-script.png)  

## Testing Patch

If you want to test your patch before applying it to real data, you can test it by pressing the `Test` button. This will fill up `After Patch` section with patched data and list what documents were put (`PutDocument`) or loaded (`LoadDocument`) using your script.

![Figure 3. Studio. Patch View. Test.](images/patch-view-test.png)  

## Saving Patches

Each patch can be saved using the `Save` action from `Action Bar` for further use (you need to type its name). To load it just press the `Load` button from the `Action Bar` and select desired patch.

## Patching a collection

The case where we patch an entire collection might be time consuming, depending on the script complexity and the size of the collection.
A warning message will make sure you understand that the script will run on **all** matching documents in the collection. A progress bar will be displayed.   
![Figure 4. Studio. Patch View. Progress Bar.](images/patch-view-progress.png)  

## Patches in Progress

You can see the number of patches in progress next to the action bar.

![Figure 5. Studio. Patch View. Patches in Progress.](images/patch-view-in-progress.png)

## Related articles

- [How to use JavaScript to patch your documents?](../../../client-api/commands/patches/how-to-use-javascript-to-patch-your-documents)
