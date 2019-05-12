# Status: Map/Reduce visualizer

In this view you get a visualization for map/reduce process. 
The following options are available in the `Action bar`:

- `Index Name` - choose the name of an appropriate index.  If the index chosen is of a fan-out type, one document will be converted into more in the mapping process,
- `Document id` - insert the id of the document you want to track,
- `Reduce key` - insert the reduce key you want to track,
- `Edit index` - edit the chosen index,
- `Run query` - link to run query view,
- `Full screen mode` - enter the full screen mode for more convenient view,
- `Display information about inserted document aids and reduced keys` - displays information about tracked documents and reduce keys,
- `Delete` - clears visualizer,
- `Download` - download a visualization in .png, .svg., or JSON format,
- `Import`- import visualization (in JSON format)

Clicking on a box next to document's name will make the map/reduce path for a given document appear. If you click on a blue box, you will get details of a given map/reduce step.

**Example**

If you enter order/11 in the `Document id`,  you will get more documents than the one you've entered. It happens because after mapping order/11 creates reduction key for companies/20. Later on all the information for companies/20 keys are downloaded.

![Figure 1. Status. Map/Reduce Visualizer.](images/status_map-reduce-1.png)

