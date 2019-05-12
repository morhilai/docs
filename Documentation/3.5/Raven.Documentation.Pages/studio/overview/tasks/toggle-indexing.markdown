# Tasks: Toggle Indexing

This view grants you the ability to pause the indexing process, which is expensive in terms of server resources.   
It might be useful in cases where you want to modify the entire database or make changes to many documents at once.    
In such a case, you can pause indexing and when you turn it back on, documents that were added or modified during 
the pause will be re-indexed. This way you can execute patching tasks a lot quicker than normal.

In RavenDB 3.5 we also added an option to pause only the reduction part of indexing (with map-reduce indexes), 
if you want to gain the performance boost while keeping indexing alive. 

Note that information concerning the pausing is not persisted so restarting the server will re-enable indexing.
Another thing to remember is that all indexes are affected, and this pauses them all.

The current indexing status (`Mapping only`, `Mapping & Reducing` or `Paused`) is displayed for your convenience.

![Figure 1. Tasks. Toggle Indexing Tab.](images/tasks-toggle_indexing_tab-1.png)
