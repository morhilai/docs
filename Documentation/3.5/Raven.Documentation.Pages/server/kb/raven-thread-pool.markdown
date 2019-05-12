# KB: RTP: Raven Thread Pool

The .NET thread pool is a really amazing piece of technology, and it is suitable for a wide range of usages. RavenDB has been making use of it for almost all of its concurrent work since the very beginning.
In this article, we will explain some of the reasons why we chose to implement our own thread pool.

One of the uses of the .NET thread pool is in RavenDB 3.0, where we rely on it for index execution. This has led to some interesting issues related to thread starvation, 
especially when you have many concurrent requests that take up threads. The fact that the .NET thread pool has a staggered growth pattern also has an impact here, in terms of how much we are actually scalable.

In RavenDB 3.5, we have decided to change that. RavenDB has a lot of parallel execution requirements, but most of them have unique characteristics that we can express better with our own thread pool.
By creating our own thread pool, designed for our own purposes, we are able to do things that you can't do in the global thread pool. 

To start with, unlike the normal thread pool, we aren't registering just a delegate and some state for it to execute, we are always registering a list of items to process, 
and a delegate that takes either a single item from that list or a section of that list. This lets us do a much better job at work stealing because we have a lot more context about the actual operation. 
We know that when we are done with executing a particular delegate, we get to run the same delegate on the next available item in the list that it got passed it. 
That gives us higher locality of code, because we are always executing the same task, as long as we have tasks for that in the pool.

We often have nested operations, a parallel task (which executes indexing work) that spawns additional parallel work (index the following documents). By basing this all on our custom thread pool, 
we can perform those operations in a way that doesn't involve waiting for that work to be done. Instead, the thread pool thread that we run on is able to "wait" by executing the work that we are waiting for. 
We have no blocked threads, and in many cases we can avoid getting any context switches.

Under load, that means that threads won't put a lot of work on the thread pool and then have to fight with each other over who will finish its work first, it means that we get to run our own tasks, 
and only when there are enough threads available for other word will we spread for additional threads.

Speaking of load, the new thread pool also have dynamic load balancing feature. Because we know that RavenDB will use the thread pool for background work only, we can prioritize things accordingly. 
RavenDB is trying to keep the CPU usage in the 60% - 80% range by default. And if we detect that we have a higher CPU usage, we'll start decreasing the background work we are doing, 
to make sure that we aren't impacting front row work (like serving requests). We'll start doing that by changing the priority of the background threads, and eventually just stop processing work
in most of the background threads (we always have a minimum number of threads that will remain working, of course).

Another fun thing that the thread pool can do is to detect and handle slowpokes. A common example is an index that is taking a long time to run. Significantly more than all the other indexes. 
The thread pool can release all the other indexes, and let the calling code know that this particular task has been left to run on its own. RavenDB will then split the indexing work so the slow index 
will not slow all of the rest of the indexing.

In order to achieve stability, have  predictable performance, and  support big amounts of database, we have a single instance of RavenThreadPool in the server. 
While each call to RPT is performed from a .net thread pool thread, the RPT mechanism will try to use it's own threads in order to help accelerete the execution, 
but if there is no free resources, the calling .net task will execute the whole workload, without waiting to receive any new resources not from the .net thread pool and not from RTP.

And finally, like every other feature in RavenDB nowadays, we have a rich set of debug endpoints that can tell us in details exactly what is going on. That is crucial when we are talking about systems 
that run for months and years or when we are trying to troubleshoot a problematic server.
