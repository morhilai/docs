# Manage Your Server: IO Test

You can use this view to test the speed of reading or writing (or reading and writing simultaneously) of the data from the disk.

IO Test has two modes: **simple** and **batch**. 

To test disk performance in **simple** mode, you need to provide the following:

- temporary record path (a folder has to exist already),
- file size,
- operation type (Write, Read, Read and Write),
- information whether the operation should be buffered,
- information whether the operation should be sequential or random,
- thread count,
- runtime of the operation,
- chunk size

![Figure 1. Manage Your Server. IO Test.](images/manage_your_server-IO_test-reading_writing-1.png)

To test disk performance in **batch** mode, you need to provide the following:

- Number of documents
- Size of documents
- Number of documents in batch
- Wait between batches (ms)

![Figure 2. Manage Your Server. IO Test.](images/manage_your_server-IO_test-options-4.png)

When the test is complete, the results including an average speed of reading and writing, disk throughput and latency are displayed.

![Figure 3. Manage Your Server. IO Test Results.](images/manage_your_server-IO_test-results-3.png) 
