# Glossary: BulkInsertOptions

### Properties

| Name | Type | Description |
| ------------- | ------------- | ----- |
| **OverwriteExisting** | bool | Indicates if existing documents should be overwritten. If not, exception will be thrown. Default: `false`. |
| **CheckReferencesInIndexes** | bool | Enables reference checking. Default: `false`. |
| **SkipOverwriteIfUnchanged** | bool | Determines whether should skip to overwrite a document when it is updated by exactly the same document (by comparing a content and as well as metadata). Default: `false`. |
| **BatchSize** | int | Used batch size. Default: `512`. |
| **WriteTimeoutMilliseconds** | int |Maximum 'quiet period' in milliseconds. If there will be no writes during that period operation will end with `TimeoutException`. Default: `15000`.  |
| **ChunkedBulkInsertOptions** | [BulkInsertOptions](chunked-bulk-insert-options) |Allows splitting the bulk insert operation to seperate chunks, forcing creation of new connections, if set to null, the single bulk insert operation will be performed. Default: `defined`. The default, chunked bulk insert operation is not thread safe, in order to support multi threaded usage of the same bulk insert, this value must be set to null |
