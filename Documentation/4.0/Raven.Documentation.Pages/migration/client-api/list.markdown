# Migration: List of Differences in Client API between 3.x and 4.0

The list of differences in the public Client API between 3.x and 4.0 contains the following changes:

- removed fields and methods in types that exist in both 3.x and 4.0
- added fields and methods in types that exist in both 3.x and 4.0
- types that don't exist in the 4.0 API

## Types with Removed or Added Members

{PANEL:BulkInsertOperation}

#### Namespace Changed

* 3.x: `Raven.Client.Document`
* 4.0: `Raven.Client.Documents.BulkInsert`

#### Removed Methods

* `void add_OnBeforeEntityInsert(Raven.Client.Document.BulkInsertOperation/BeforeEntityInsert)`
* `void add_Report(Action<string>)`
* `Raven.Client.Connection.Async.IAsyncDatabaseCommands get_DatabaseCommands()`
* `bool get_IsAborted()`
* `Guid get_OperationId()`
* `void remove_OnBeforeEntityInsert(Raven.Client.Document.BulkInsertOperation/BeforeEntityInsert)`
* `void remove_Report(Action<string>)`
* `void Store(Raven.Json.Linq.RavenJObject, Raven.Json.Linq.RavenJObject, string, Nullable<int>)`
* `Task WaitForLastTaskToFinish()`

#### Added Fields

* `System.IO.Compression.CompressionLevel CompressionLevel`

#### Added Methods

* `System.Threading.Tasks.Task AbortAsync()`
* `System.Threading.Tasks.Task<string> StoreAsync(object, Raven.Client.Documents.Session.IMetadataDictionary)`
* `System.Threading.Tasks.Task StoreAsync(object, string, Raven.Client.Documents.Session.IMetadataDictionary)`

{PANEL/}

{PANEL:IDatabaseChanges}

#### Namespace Changed

* 3.x: `Raven.Client.Changes`
* 4.0: `Raven.Client.Documents.Changes`

#### Removed Methods

* `Raven.Client.Changes.IObservableWithTask<Raven.Abstractions.Data.DataSubscriptionChangeNotification> ForAllDataSubscriptions()`
* `Raven.Client.Changes.IObservableWithTask<Raven.Abstractions.Data.ReplicationConflictNotification> ForAllReplicationConflicts()`
* `Raven.Client.Changes.IObservableWithTask<Raven.Abstractions.Data.TransformerChangeNotification> ForAllTransformers()`
* `Raven.Client.Changes.IObservableWithTask<Raven.Abstractions.Data.BulkInsertChangeNotification> ForBulkInsert(Nullable<Guid>)`
* `Raven.Client.Changes.IObservableWithTask<Raven.Abstractions.Data.DataSubscriptionChangeNotification> ForDataSubscription(long)`

#### Added Methods

* `Raven.Client.Documents.Changes.IChangesObservable<Raven.Client.Documents.Operations.OperationStatusChange> ForAllOperations()`
* `Raven.Client.Documents.Changes.IChangesObservable<Raven.Client.Documents.Operations.OperationStatusChange> ForOperationId(long)`

{PANEL/}

{PANEL:BatchOptions}

#### Namespace Changed

* 3.x: `Raven.Client.Connection`
* 4.0: `Raven.Client.Documents.Commands.Batches`

#### Removed Methods

* `TimeSpan get_WaitForReplicasTimout()`
* `void set_WaitForReplicasTimout(TimeSpan)`

#### Added Methods

* `System.Nullable<System.TimeSpan> get_RequestTimeout()`
* `System.TimeSpan get_WaitForReplicasTimeout()`
* `void set_RequestTimeout(System.Nullable<System.TimeSpan>)`
* `void set_WaitForReplicasTimeout(System.TimeSpan)`

{PANEL/}

{PANEL:DefaultRavenContractResolver}
#### Namespace Changed

* 3.x: `Raven.Client.Document`
* 4.0: `Raven.Client.Documents.Conventions`

#### Removed Methods

* `IDisposable RegisterForExtensionData(Raven.Imports.Newtonsoft.Json.Serialization.ExtensionDataSetter)`

#### Added Fields

* `System.Nullable<System.Reflection.BindingFlags> MembersSearchFlag`

#### Added Methods

* `Raven.Client.Documents.Conventions.DefaultRavenContractResolver/ClearExtensionData RegisterExtensionDataGetter(Newtonsoft.Json.Serialization.ExtensionDataGetter)`
* `Raven.Client.Documents.Conventions.DefaultRavenContractResolver/ClearExtensionData RegisterExtensionDataSetter(Newtonsoft.Json.Serialization.ExtensionDataSetter)`

{PANEL/}

{PANEL:DocumentConvention}

Renamed to `DocumentConventions`.

#### Namespace Changed

* 3.x: `Raven.Client.Document`
* 4.0: `Raven.Client.Documents.Conventions`

#### Removed Methods

* `string DefaultFindFullDocumentKeyFromNonStringIdentifier(object, Type, bool)`
* `string DefaultTransformTypeTagNameToDocumentKeyPrefix(string)`
* `string DefaultTypeTagName(Type)`
* `string GenerateDocumentKey(string, Raven.Client.Connection.IDatabaseCommands, object)`
* `Task<string> GenerateDocumentKeyAsync(string, Raven.Client.Connection.Async.IAsyncDatabaseCommands, object)`
* `string GenerateDocumentKeyUsingIdentity(Raven.Client.Document.DocumentConvention, object)`
* `bool get_AcceptGzipContent()`
* `bool get_AllowQueriesOnId()`
* `Raven.Client.Document.DocumentConvention/ApplyReduceFunctionFunc get_ApplyReduceFunction()`
* `Func<string, Raven.Client.Connection.Async.IAsyncDatabaseCommands, object, Task<string>> get_AsyncDocumentKeyGenerator()`
* `Raven.Client.Document.ConsistencyOptions get_DefaultQueryingConsistency()`
* `bool get_DefaultUseOptimisticConcurrency()`
* `bool get_DisableProfiling()`
* `Func<string, Raven.Client.Connection.IDatabaseCommands, object, string> get_DocumentKeyGenerator()`
* `bool get_EnlistInDistributedTransactions()`
* `Func<object, string> get_FindDynamicTagName()`
* `Func<object, Type, bool, string> get_FindFullDocumentKeyFromNonStringIdentifier()`
* `Func<string, string> get_FindIdentityPropertyNameFromEntityName()`
* `Func<object, string, string> get_FindIdValuePartForValueTypeConversion()`
* `Func<Type, string> get_FindTypeTagName()`
* `List<Raven.Client.Converters.ITypeConverter> get_IdentityTypeConvertors()`
* `Raven.Client.Document.IndexAndTransformerReplicationMode get_IndexAndTransformerReplicationMode()`
* `int get_MaxLengthOfQueryUsingGetUrl()`
* `Func<string, Raven.Client.Connection.HttpJsonRequestFactory, Func<string, Raven.Client.Metrics.IRequestTimeMetric>, Raven.Client.Connection.IDocumentStoreReplicationInformer> get_ReplicationInformerFactory()`
* `bool get_ShouldAggressiveCacheTrackChanges()`
* `bool get_ShouldSaveChangesForceAggressiveCacheCheck()`
* `Func<string, string> get_TransformTypeTagNameToDocumentKeyPrefix()`
* `bool get_UseParallelMultiGet()`
* `Raven.Abstractions.Indexing.SortOptions GetDefaultSortOption(string)`
* `string GetDynamicTagName(object)`
* `string GetTypeTagName(Type)`
* `Raven.Client.Document.DocumentConvention RegisterIdConvention<TEntity>(Func<string, Raven.Client.Connection.IDatabaseCommands, TEntity, string>)`
* `void set_AcceptGzipContent(bool)`
* `void set_AllowQueriesOnId(bool)`
* `void set_ApplyReduceFunction(Raven.Client.Document.DocumentConvention/ApplyReduceFunctionFunc)`
* `void set_AsyncDocumentKeyGenerator(Func<string, Raven.Client.Connection.Async.IAsyncDatabaseCommands, object, Task<string>>)`
* `void set_DefaultQueryingConsistency(Raven.Client.Document.ConsistencyOptions)`
* `void set_DefaultUseOptimisticConcurrency(bool)`
* `void set_DisableProfiling(bool)`
* `void set_DocumentKeyGenerator(Func<string, Raven.Client.Connection.IDatabaseCommands, object, string>)`
* `void set_EnlistInDistributedTransactions(bool)`
* `void set_FindDynamicTagName(Func<object, string>)`
* `void set_FindFullDocumentKeyFromNonStringIdentifier(Func<object, Type, bool, string>)`
* `void set_FindIdentityPropertyNameFromEntityName(Func<string, string>)`
* `void set_FindIdValuePartForValueTypeConversion(Func<object, string, string>)`
* `void set_FindTypeTagName(Func<Type, string>)`
* `void set_IdentityTypeConvertors(List<Raven.Client.Converters.ITypeConverter>)`
* `void set_IndexAndTransformerReplicationMode(Raven.Client.Document.IndexAndTransformerReplicationMode)`
* `void set_MaxLengthOfQueryUsingGetUrl(int)`
* `void set_ReplicationInformerFactory(Func<string, Raven.Client.Connection.HttpJsonRequestFactory, Func<string, Raven.Client.Metrics.IRequestTimeMetric>, Raven.Client.Connection.IDocumentStoreReplicationInformer>)`
* `void set_ShouldAggressiveCacheTrackChanges(bool)`
* `void set_ShouldSaveChangesForceAggressiveCacheCheck(bool)`
* `void set_TransformTypeTagNameToDocumentKeyPrefix(Func<string, string>)`
* `void set_UseParallelMultiGet(bool)`
* `string TryGetDocumentIdFromRegisteredIdLoadConventions<TEntity>(ValueType)`
* `string TryGetDocumentIdFromRegisteredIdLoadConventions(ValueType, Type)`
* `bool UsesRangeType(object)`

#### Added Fields

* `Raven.Client.Documents.Conventions.DocumentConventions/BulkInsertConventions BulkInsert`

#### Added Methods

* `string DefaultGetCollectionName(System.Type)`
* `string DefaultTransformCollectionNameToDocumentIdPrefix(string)`
* `string GenerateDocumentId(string, object)`
* `System.Threading.Tasks.Task<string> GenerateDocumentIdAsync(string, object)`
* `System.Func<string, object, System.Threading.Tasks.Task<string>> get_AsyncDocumentIdGenerator()`
* `System.Func<System.Type, Sparrow.Json.BlittableJsonReaderObject, object> get_DeserializeEntityFromBlittable()`
* `bool get_DisableTopologyUpdates()`
* `System.Func<System.Type, string> get_FindCollectionName()`
* `System.Func<object, string> get_FindCollectionNameForDynamic()`
* `System.Func<string, string> get_FindIdentityPropertyNameFromCollectionName()`
* `string get_IdentityPartsSeparator()`
* `Sparrow.Size get_MaxHttpCacheSize()`
* `Raven.Client.Http.ReadBalanceBehavior get_ReadBalanceBehavior()`
* `bool get_SaveEnumsAsIntegers()`
* `bool get_ThrowIfQueryPageSizeIsNotSet()`
* `System.Func<string, string> get_TransformTypeCollectionNameToDocumentIdPrefix()`
* `bool get_UseOptimisticConcurrency()`
* `string GetCollectionName(System.Type)`
* `string GetCollectionName(object)`
* `Raven.Client.Documents.Indexes.RangeType GetRangeType(System.Type)`
* `void RegisterCustomQueryTranslator<T>(System.Linq.Expressions.Expression<System.Func<T, object>>, Raven.Client.Documents.Conventions.DocumentConventions/CustomQueryTranslator)`
* `void set_AsyncDocumentIdGenerator(System.Func<string, object, System.Threading.Tasks.Task<string>>)`
* `void set_DeserializeEntityFromBlittable(System.Func<System.Type, Sparrow.Json.BlittableJsonReaderObject, object>)`
* `void set_DisableTopologyUpdates(bool)`
* `void set_FindCollectionName(System.Func<System.Type, string>)`
* `void set_FindCollectionNameForDynamic(System.Func<object, string>)`
* `void set_FindIdentityPropertyNameFromCollectionName(System.Func<string, string>)`
* `void set_IdentityPartsSeparator(string)`
* `void set_MaxHttpCacheSize(Sparrow.Size)`
* `void set_ReadBalanceBehavior(Raven.Client.Http.ReadBalanceBehavior)`
* `void set_SaveEnumsAsIntegers(bool)`
* `void set_ThrowIfQueryPageSizeIsNotSet(bool)`
* `void set_TransformTypeCollectionNameToDocumentIdPrefix(System.Func<string, string>)`
* `void set_UseOptimisticConcurrency(bool)`

{PANEL/}

{PANEL:IDocumentStore}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents`

#### Removed Methods

* `void ExecuteTransformer(Raven.Client.Indexes.AbstractTransformerCreationTask)`
* `Task ExecuteTransformerAsync(Raven.Client.Indexes.AbstractTransformerCreationTask)`
* `Raven.Client.Connection.Async.IAsyncDatabaseCommands get_AsyncDatabaseCommands()`
* `Raven.Client.Document.IAsyncReliableSubscriptions get_AsyncSubscriptions()`
* `Raven.Client.Connection.IDatabaseCommands get_DatabaseCommands()`
* `bool get_HasJsonRequestFactory()`
* `Raven.Client.Connection.HttpJsonRequestFactory get_JsonRequestFactory()`
* `Raven.Client.Document.DocumentSessionListeners get_Listeners()`
* `NameValueCollection get_SharedOperationsHeaders()`
* `string get_Url()`
* `Raven.Abstractions.Data.Etag GetLastWrittenEtag()`
* `Raven.Client.Connection.Profiling.ProfilingInformation GetProfilingInformationFor(Guid)`
* `void InitializeProfiling()`
* `void SetListeners(Raven.Client.Document.DocumentSessionListeners)`
* `IDisposable SetRequestTimeoutFor(TimeSpan)`
* `void SideBySideExecuteIndex(Raven.Client.Indexes.AbstractIndexCreationTask, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideExecuteIndexAsync(Raven.Client.Indexes.AbstractIndexCreationTask, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `void SideBySideExecuteIndexes(List<Raven.Client.Indexes.AbstractIndexCreationTask>, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideExecuteIndexesAsync(List<Raven.Client.Indexes.AbstractIndexCreationTask>, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`

#### Added Methods

* `void add_OnAfterSaveChanges(System.EventHandler<Raven.Client.Documents.Session.AfterSaveChangesEventArgs>)`
* `void add_OnBeforeDelete(System.EventHandler<Raven.Client.Documents.Session.BeforeDeleteEventArgs>)`
* `void add_OnBeforeQuery(System.EventHandler<Raven.Client.Documents.Session.BeforeQueryExecutedEventArgs>)`
* `void add_OnBeforeStore(System.EventHandler<Raven.Client.Documents.Session.BeforeStoreEventArgs>)`
* `System.Security.Cryptography.X509Certificates.X509Certificate2 get_Certificate()`
* `string get_Database()`
* `Raven.Client.Documents.Operations.MaintenanceOperationExecutor get_Maintenance()`
* `Raven.Client.Documents.Operations.OperationExecutor get_Operations()`
* `System.String[] get_Urls()`
* `Raven.Client.Http.RequestExecutor GetRequestExecutor(string)`
* `void remove_OnAfterSaveChanges(System.EventHandler<Raven.Client.Documents.Session.AfterSaveChangesEventArgs>)`
* `void remove_OnBeforeDelete(System.EventHandler<Raven.Client.Documents.Session.BeforeDeleteEventArgs>)`
* `void remove_OnBeforeQuery(System.EventHandler<Raven.Client.Documents.Session.BeforeQueryExecutedEventArgs>)`
* `void remove_OnBeforeStore(System.EventHandler<Raven.Client.Documents.Session.BeforeStoreEventArgs>)`
* `void set_Database(string)`
* `System.IDisposable SetRequestTimeout(System.TimeSpan, string)`

{PANEL/}

{PANEL:GenerateEntityIdOnTheClient}

#### Namespace Changed

* 3.x: `Raven.Client.Document`
* 4.0: `Raven.Client.Documents.Identity`

#### Removed Methods

* `string GenerateDocumentKeyForStorage(object)`
* `string GetOrGenerateDocumentKey(object)`

#### Added Methods

* `string GenerateDocumentIdForStorage(object)`
* `string GetOrGenerateDocumentId(object)`

{PANEL/}

{PANEL:AbstractGenericIndexCreationTask<TReduceResult>}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `bool get_DisableInMemoryIndexing()`
* `void set_DisableInMemoryIndexing(bool)`

{PANEL/}

{PANEL:AbstractIndexCreationTask}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `void AfterExecute(Raven.Client.Connection.IDatabaseCommands, Raven.Client.Document.DocumentConvention)`
* `Task AfterExecuteAsync(Raven.Client.Connection.Async.IAsyncDatabaseCommands, Raven.Client.Document.DocumentConvention, CancellationToken)`
* `void Execute(Raven.Client.Connection.IDatabaseCommands, Raven.Client.Document.DocumentConvention)`
* `Task ExecuteAsync(Raven.Client.Connection.Async.IAsyncDatabaseCommands, Raven.Client.Document.DocumentConvention, CancellationToken)`
* `Raven.Abstractions.Indexing.IndexDefinition GetLegacyIndexDefinition(Raven.Client.Document.DocumentConvention)`
* `object LoadAttachmentForIndexing(string)`
* `void SideBySideExecute(Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `void SideBySideExecute(Raven.Client.Connection.IDatabaseCommands, Raven.Client.Document.DocumentConvention, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideExecuteAsync(Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideExecuteAsync(Raven.Client.Connection.Async.IAsyncDatabaseCommands, Raven.Client.Document.DocumentConvention, Raven.Abstractions.Data.Etag, Nullable<DateTime>, CancellationToken)`
* `object SpatialClustering(string, Nullable<Double>, Nullable<Double>)`
* `object SpatialClustering(string, Nullable<Double>, Nullable<Double>, int, int)`
* `object SpatialGenerate(Nullable<Double>, Nullable<Double>)`
* `object SpatialGenerate(string, Nullable<Double>, Nullable<Double>)`
* `object SpatialGenerate(string, string)`
* `object SpatialGenerate(string, string, Raven.Abstractions.Indexing.SpatialSearchStrategy)`
* `object SpatialGenerate(string, string, Raven.Abstractions.Indexing.SpatialSearchStrategy, int)`

#### Added Methods

* `object CreateSpatialField(System.Nullable<System.Double>, System.Nullable<System.Double>)`
* `object CreateSpatialField(string)`
* `System.Nullable<Raven.Client.Documents.Indexes.IndexLockMode> get_LockMode()`
* `void set_LockMode(System.Nullable<Raven.Client.Documents.Indexes.IndexLockMode>)`

{PANEL/}

{PANEL:AbstractIndexCreationTask<TDocument, TReduceResult>}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `Nullable<int> get_MaxIndexOutputsPerDocument()`
* `void set_MaxIndexOutputsPerDocument(Nullable<int>)`

{PANEL/}

{PANEL:AbstractMultiMapIndexCreationTask<TReduceResult>}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `Nullable<int> get_MaxIndexOutputsPerDocument()`
* `void set_MaxIndexOutputsPerDocument(Nullable<int>)`

{PANEL/}

{PANEL:IndexCreation}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `void CreateIndexes(ExportProvider, Raven.Client.IDocumentStore)`
* `Task CreateIndexesAsync(ExportProvider, Raven.Client.IDocumentStore)`
* `void SideBySideCreateIndexes(Assembly, Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `void SideBySideCreateIndexes(ExportProvider, Raven.Client.Connection.IDatabaseCommands, Raven.Client.Document.DocumentConvention, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `void SideBySideCreateIndexes(ExportProvider, Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideCreateIndexesAsync(ExportProvider, Raven.Client.Connection.Async.IAsyncDatabaseCommands, Raven.Client.Document.DocumentConvention, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideCreateIndexesAsync(Assembly, Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`
* `Task SideBySideCreateIndexesAsync(ExportProvider, Raven.Client.IDocumentStore, Raven.Abstractions.Data.Etag, Nullable<DateTime>)`

{PANEL/}

{PANEL:IndexDefinitionBuilder<TDocument, TReduceResult>}

#### Namespace Changed

* 3.x: `Raven.Client.Indexes`
* 4.0: `Raven.Client.Documents.Indexes`

#### Removed Methods

* `bool get_DisableInMemoryIndexing()`
* `Nullable<int> get_MaxIndexOutputsPerDocument()`
* `IDictionary<Expression<Func<TReduceResult, object>>, Raven.Abstractions.Indexing.SortOptions> get_SortOptions()`
* `Dictionary<string, Raven.Abstractions.Indexing.SortOptions> get_SortOptionsStrings()`
* `IDictionary<Expression<Func<TReduceResult, object>>, Raven.Abstractions.Indexing.SuggestionOptions> get_Suggestions()`
* `void set_DisableInMemoryIndexing(bool)`
* `void set_MaxIndexOutputsPerDocument(Nullable<int>)`
* `void set_SortOptions(IDictionary<Expression<Func<TReduceResult, object>>, Raven.Abstractions.Indexing.SortOptions>)`
* `void set_SortOptionsStrings(Dictionary<string, Raven.Abstractions.Indexing.SortOptions>)`
* `void set_Suggestions(IDictionary<Expression<Func<TReduceResult, object>>, Raven.Abstractions.Indexing.SuggestionOptions>)`

#### Added Methods

* `System.Collections.Generic.Dictionary<string, string> get_AdditionalSources()`
* `string get_OutputReduceToCollection()`
* `System.Nullable<Raven.Client.Documents.Indexes.IndexPriority> get_Priority()`
* `void set_AdditionalSources(System.Collections.Generic.Dictionary<string, string>)`
* `void set_OutputReduceToCollection(string)`
* `void set_Priority(System.Nullable<Raven.Client.Documents.Indexes.IndexPriority>)`

{PANEL/}

{PANEL:IndexingLinqExtensions}

#### Namespace Changed

* 3.x: `Raven.Client.Linq.Indexing`
* 4.0: `Raven.Client.Documents.Linq.Indexing`

#### Removed Methods

* `string ParseShort(object)`
* `string ParseShort(object, Int16)`
* `string StripHtml(object)`

{PANEL/}

{PANEL:IRavenQueryable<T>}

#### Namespace Changed

* 3.x: `Raven.Client.Linq`
* 4.0: `Raven.Client.Documents.Linq`

#### Removed Methods

* `Raven.Client.Linq.IRavenQueryable<T> AddQueryInput(string, Raven.Json.Linq.RavenJToken)`
* `Raven.Client.Linq.IRavenQueryable<T> AddTransformerParameter(string, Raven.Json.Linq.RavenJToken)`
* `Type get_OriginalQueryType()`
* `Raven.Client.Linq.IRavenQueryable<T> OrderByDistance(Raven.Abstractions.Indexing.SpatialSort)`
* `void set_OriginalQueryType(Type)`
* `Raven.Client.Linq.IRavenQueryable<T> Spatial(Expression<Func<T, object>>, Func<Raven.Client.Spatial.SpatialCriteriaFactory, Raven.Client.Spatial.SpatialCriteria>)`
* `Raven.Client.Linq.IRavenQueryable<TResult> TransformWith<TTransformer, TResult>()`
* `Raven.Client.Linq.IRavenQueryable<TResult> TransformWith<TResult>(string)`

{PANEL/}

{PANEL:LinqExtensions}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents`

#### Removed Methods

* `Raven.Client.Linq.IRavenQueryable<TResult> ProjectFromIndexFieldsInto<TResult>(IQueryable)`
* `Raven.Abstractions.Data.SuggestionQueryResult Suggest(IQueryable)`
* `Raven.Abstractions.Data.SuggestionQueryResult Suggest(IQueryable, Raven.Abstractions.Data.SuggestionQuery)`
* `Task<Raven.Abstractions.Data.SuggestionQueryResult> SuggestAsync(IQueryable, Raven.Abstractions.Data.SuggestionQuery, CancellationToken)`
* `Task<Raven.Abstractions.Data.SuggestionQueryResult> SuggestAsync(IQueryable, CancellationToken)`
* `Lazy<Raven.Abstractions.Data.SuggestionQueryResult> SuggestLazy(IQueryable)`
* `Lazy<Raven.Abstractions.Data.SuggestionQueryResult> SuggestLazy(IQueryable, Raven.Abstractions.Data.SuggestionQuery)`
* `Raven.Abstractions.Data.FacetQuery ToFacetQuery<T>(IQueryable<T>, string, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetQuery ToFacetQuery<T>(IQueryable<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetResults ToFacets<T>(IQueryable<T>, string, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetResults ToFacets<T>(IQueryable<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetResults ToFacets<T>(Raven.Client.IDocumentQuery<T>, string, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetResults ToFacets<T>(Raven.Client.IDocumentQuery<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Task<Raven.Abstractions.Data.FacetResults> ToFacetsAsync<T>(IQueryable<T>, string, int, Nullable<int>, CancellationToken)`
* `Task<Raven.Abstractions.Data.FacetResults> ToFacetsAsync<T>(IQueryable<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>, CancellationToken)`
* `Task<Raven.Abstractions.Data.FacetResults> ToFacetsAsync<T>(Raven.Client.IAsyncDocumentQuery<T>, string, int, Nullable<int>, CancellationToken)`
* `Task<Raven.Abstractions.Data.FacetResults> ToFacetsAsync<T>(Raven.Client.IAsyncDocumentQuery<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>, CancellationToken)`
* `Lazy<Raven.Abstractions.Data.FacetResults> ToFacetsLazy<T>(IQueryable<T>, string, int, Nullable<int>)`
* `Lazy<Raven.Abstractions.Data.FacetResults> ToFacetsLazy<T>(IQueryable<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Lazy<Raven.Abstractions.Data.FacetResults> ToFacetsLazy<T>(Raven.Client.IDocumentQuery<T>, string, int, Nullable<int>)`
* `Lazy<Raven.Abstractions.Data.FacetResults> ToFacetsLazy<T>(Raven.Client.IDocumentQuery<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Lazy<Task<Raven.Abstractions.Data.FacetResults>> ToFacetsLazyAsync<T>(IQueryable<T>, string, int, Nullable<int>)`
* `Lazy<Task<Raven.Abstractions.Data.FacetResults>> ToFacetsLazyAsync<T>(IQueryable<T>, IEnumerable<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`

#### Added Methods

* `Raven.Client.Documents.Queries.Facets.IAggregationQuery<T> AggregateUsing<T>(System.Linq.IQueryable<T>, string)`
* `Raven.Client.Documents.Linq.IRavenQueryable<System.Linq.IGrouping<System.Collections.Generic.IEnumerable<TKey>, TSource>> GroupByArrayContent<TSource, TKey>(System.Linq.IQueryable<TSource>, System.Linq.Expressions.Expression<System.Func<TSource, System.Collections.Generic.IEnumerable<TKey>>>)`
* `Raven.Client.Documents.Linq.IRavenQueryable<System.Linq.IGrouping<TKey, TSource>> GroupByArrayValues<TSource, TKey>(System.Linq.IQueryable<TSource>, System.Linq.Expressions.Expression<System.Func<TSource, System.Collections.Generic.IEnumerable<TKey>>>)`
* `Raven.Client.Documents.Linq.IRavenQueryable<TResult> Include<TResult>(System.Linq.IQueryable<TResult>, string)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> MoreLikeThis<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.MoreLikeThis.MoreLikeThisBase)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> MoreLikeThis<T>(System.Linq.IQueryable<T>, System.Action<Raven.Client.Documents.Queries.MoreLikeThis.IMoreLikeThisBuilder<T>>)`
* `System.Linq.IOrderedQueryable<T> OrderBy<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> OrderBy<T>(System.Linq.IQueryable<T>, string, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> OrderByDescending<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> OrderByDescending<T>(System.Linq.IQueryable<T>, string, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, System.Func<Raven.Client.Documents.Queries.Spatial.DynamicSpatialFieldFactory<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField>, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, string, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, System.Func<Raven.Client.Documents.Queries.Spatial.DynamicSpatialFieldFactory<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField>, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistance<T>(System.Linq.IQueryable<T>, string, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, System.Func<Raven.Client.Documents.Queries.Spatial.DynamicSpatialFieldFactory<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField>, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, string, System.Double, System.Double)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, System.Func<Raven.Client.Documents.Queries.Spatial.DynamicSpatialFieldFactory<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField>, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, string)`
* `System.Linq.IOrderedQueryable<T> OrderByDistanceDescending<T>(System.Linq.IQueryable<T>, string, string)`
* `Raven.Client.Documents.Linq.IRavenQueryable<TResult> ProjectInto<TResult>(System.Linq.IQueryable)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Spatial<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, System.Func<Raven.Client.Documents.Queries.Spatial.SpatialCriteriaFactory, Raven.Client.Documents.Queries.Spatial.SpatialCriteria>)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Spatial<T>(System.Linq.IQueryable<T>, string, System.Func<Raven.Client.Documents.Queries.Spatial.SpatialCriteriaFactory, Raven.Client.Documents.Queries.Spatial.SpatialCriteria>)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Spatial<T>(System.Linq.IQueryable<T>, System.Func<Raven.Client.Documents.Queries.Spatial.DynamicSpatialFieldFactory<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField>, System.Func<Raven.Client.Documents.Queries.Spatial.SpatialCriteriaFactory, Raven.Client.Documents.Queries.Spatial.SpatialCriteria>)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Spatial<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Spatial.DynamicSpatialField, System.Func<Raven.Client.Documents.Queries.Spatial.SpatialCriteriaFactory, Raven.Client.Documents.Queries.Spatial.SpatialCriteria>)`
* `Raven.Client.Documents.Queries.Suggestions.ISuggestionQuery<T> SuggestUsing<T>(System.Linq.IQueryable<T>, Raven.Client.Documents.Queries.Suggestions.SuggestionBase)`
* `Raven.Client.Documents.Queries.Suggestions.ISuggestionQuery<T> SuggestUsing<T>(System.Linq.IQueryable<T>, System.Action<Raven.Client.Documents.Queries.Suggestions.ISuggestionBuilder<T>>)`
* `System.Linq.IOrderedQueryable<T> ThenBy<T>(System.Linq.IOrderedQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> ThenBy<T>(System.Linq.IOrderedQueryable<T>, string, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> ThenByDescending<T>(System.Linq.IOrderedQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, object>>, Raven.Client.Documents.Session.OrderingType)`
* `System.Linq.IOrderedQueryable<T> ThenByDescending<T>(System.Linq.IOrderedQueryable<T>, string, Raven.Client.Documents.Session.OrderingType)`
* `void ToStream<T>(System.Linq.IQueryable<T>, System.IO.Stream)`
* `void ToStream<T>(Raven.Client.Documents.Session.IDocumentQuery<T>, System.IO.Stream)`
* `System.Threading.Tasks.Task ToStreamAsync<T>(System.Linq.IQueryable<T>, System.IO.Stream, System.Threading.CancellationToken)`
* `System.Threading.Tasks.Task ToStreamAsync<T>(Raven.Client.Documents.Session.IAsyncDocumentQuery<T>, System.IO.Stream, System.Threading.CancellationToken)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Where<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, int, bool>>, bool)`
* `Raven.Client.Documents.Linq.IRavenQueryable<T> Where<T>(System.Linq.IQueryable<T>, System.Linq.Expressions.Expression<System.Func<T, bool>>, bool)`

{PANEL/}

{PANEL:Operation}
#### Namespace Changed

* 3.x: `Raven.Client.Connection`
* 4.0: `Raven.Client.Documents.Operations`

#### Removed Methods

* `void .ctor(Func<long, Task<Raven.Json.Linq.RavenJToken>>, long)`
* `void .ctor(Raven.Client.Connection.Async.AsyncServerClient, long)`

#### Added Methods

* `void OnCompleted()`
* `void OnError(System.Exception)`
* `void OnNext(Raven.Client.Documents.Operations.OperationStatusChange)`
* `TResult WaitForCompletion<TResult>(System.Nullable<System.TimeSpan>)`
* `System.Threading.Tasks.Task<TResult> WaitForCompletionAsync<TResult>(System.Nullable<System.TimeSpan>)`

{PANEL/}

{PANEL:IDocumentQueryCustomization}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `Raven.Client.IDocumentQueryCustomization AddOrder(string, bool)`
* `Raven.Client.IDocumentQueryCustomization AddOrder<TResult>(Expression<Func<TResult, object>>, bool)`
* `Raven.Client.IDocumentQueryCustomization AddOrder(string, bool, Type)`
* `Raven.Client.IDocumentQueryCustomization AlphaNumericOrdering(string, bool)`
* `Raven.Client.IDocumentQueryCustomization AlphaNumericOrdering<TResult>(Expression<Func<TResult, object>>, bool)`
* `Raven.Client.IDocumentQueryCustomization BeforeQueryExecution(Action<Raven.Abstractions.Data.IndexQuery>)`
* `Raven.Client.IDocumentQueryCustomization CustomSortUsing(string)`
* `Raven.Client.IDocumentQueryCustomization CustomSortUsing(string, bool)`
* `Raven.Client.IDocumentQueryCustomization Highlight(string, int, int, string)`
* `Raven.Client.IDocumentQueryCustomization Highlight(string, int, int, Raven.Client.FieldHighlightings&)`
* `Raven.Client.IDocumentQueryCustomization Highlight(string, string, int, int, Raven.Client.FieldHighlightings&)`
* `Raven.Client.IDocumentQueryCustomization Include<TResult, TInclude>(Expression<Func<TResult, object>>)`
* `Raven.Client.IDocumentQueryCustomization Include(string)`
* `Raven.Client.IDocumentQueryCustomization RelatesToShape(string, string, Raven.Abstractions.Indexing.SpatialRelation, Double)`
* `Raven.Client.IDocumentQueryCustomization SetAllowMultipleIndexEntriesForSameDocumentToResultTransformer(bool)`
* `Raven.Client.IDocumentQueryCustomization SetHighlighterTags(string, string)`
* `Raven.Client.IDocumentQueryCustomization SetHighlighterTags(String[], String[])`
* `Raven.Client.IDocumentQueryCustomization ShowTimings()`
* `Raven.Client.IDocumentQueryCustomization SortByDistance()`
* `Raven.Client.IDocumentQueryCustomization SortByDistance(Double, Double)`
* `Raven.Client.IDocumentQueryCustomization SortByDistance(Double, Double, string)`
* `Raven.Client.IDocumentQueryCustomization TransformResults(Func<Raven.Abstractions.Data.IndexQuery, IEnumerable<object>, IEnumerable<object>>)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResults(TimeSpan)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOf(DateTime)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOf(DateTime, TimeSpan)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOf(Raven.Abstractions.Data.Etag)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOf(Raven.Abstractions.Data.Etag, TimeSpan)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOfLastWrite()`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOfLastWrite(TimeSpan)`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOfNow()`
* `Raven.Client.IDocumentQueryCustomization WaitForNonStaleResultsAsOfNow(TimeSpan)`
* `Raven.Client.IDocumentQueryCustomization WithinRadiusOf(Double, Double, Double, Double)`
* `Raven.Client.IDocumentQueryCustomization WithinRadiusOf(string, Double, Double, Double, Double)`
* `Raven.Client.IDocumentQueryCustomization WithinRadiusOf(Double, Double, Double, Raven.Abstractions.Indexing.SpatialUnits, Double)`
* `Raven.Client.IDocumentQueryCustomization WithinRadiusOf(string, Double, Double, Double, Raven.Abstractions.Indexing.SpatialUnits, Double)`
* `Raven.Client.IDocumentQueryCustomization Include<TResult>(Expression<Func<TResult, object>>)`
* `Raven.Client.IDocumentQueryCustomization Spatial(string, Func<Raven.Client.Spatial.SpatialCriteriaFactory, Raven.Client.Spatial.SpatialCriteria>)`

#### Added Methods

* `Raven.Client.Documents.Session.IDocumentQueryCustomization AfterQueryExecuted(System.Action<Raven.Client.Documents.Queries.QueryResult>)`
* `Raven.Client.Documents.Session.IDocumentQueryCustomization AfterStreamExecuted(System.Action<Sparrow.Json.BlittableJsonReaderObject>)`
* `Raven.Client.Documents.Session.IDocumentQueryCustomization BeforeQueryExecuted(System.Action<Raven.Client.Documents.Queries.IndexQuery>)`
* `Raven.Client.Documents.Session.Operations.QueryOperation get_QueryOperation()`

{PANEL/}

{PANEL:IAsyncDocumentQuery<T>}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `string get_AsyncIndexQueried()`
* `Task<Raven.Abstractions.Data.FacetResults> GetFacetsAsync(string, int, Nullable<int>, CancellationToken)`
* `Task<Raven.Abstractions.Data.FacetResults> GetFacetsAsync(List<Raven.Abstractions.Data.Facet>, int, Nullable<int>, CancellationToken)`
* `Lazy<Task<Raven.Abstractions.Data.FacetResults>> GetFacetsLazyAsync(string, int, Nullable<int>, CancellationToken)`
* `Lazy<Task<Raven.Abstractions.Data.FacetResults>> GetFacetsLazyAsync(List<Raven.Abstractions.Data.Facet>, int, Nullable<int>, CancellationToken)`
* `Task<Raven.Abstractions.Data.QueryResult> QueryResultAsync(CancellationToken)`
* `void SetQueryInputs(Dictionary<string, Raven.Json.Linq.RavenJToken>)`
* `Raven.Client.IAsyncDocumentQuery<TTransformerResult> SetResultTransformer<TTransformer, TTransformerResult>()`
* `Raven.Client.IAsyncDocumentQuery<T> SetTransformerParameters(Dictionary<string, Raven.Json.Linq.RavenJToken>)`

#### Added Methods

* `Raven.Client.Documents.Queries.Facets.IAsyncAggregationDocumentQuery<T> AggregateBy(System.Action<Raven.Client.Documents.Queries.Facets.IFacetBuilder<T>>)`
* `Raven.Client.Documents.Queries.Facets.IAsyncAggregationDocumentQuery<T> AggregateBy(Raven.Client.Documents.Queries.Facets.FacetBase)`
* `Raven.Client.Documents.Queries.Facets.IAsyncAggregationDocumentQuery<T> AggregateBy(System.Collections.Generic.IEnumerable<Raven.Client.Documents.Queries.Facets.Facet>)`
* `Raven.Client.Documents.Queries.Facets.IAsyncAggregationDocumentQuery<T> AggregateUsing(string)`
* `string get_IndexName()`
* `bool get_IsDistinct()`
* `System.Threading.Tasks.Task<Raven.Client.Documents.Queries.QueryResult> GetQueryResultAsync(System.Threading.CancellationToken)`
* `Raven.Client.Documents.Session.IAsyncGroupByDocumentQuery<T> GroupBy(string, System.String[])`
* `Raven.Client.Documents.Session.IAsyncGroupByDocumentQuery<T> GroupBy(System.ValueTuple<string, Raven.Client.Documents.Queries.GroupByMethod>, System.ValueTuple`2<System.String,Raven.Client.Documents.Queries.GroupByMethod>[])`
* `Raven.Client.Documents.Session.IAsyncDocumentQuery<T> MoreLikeThis(System.Action<Raven.Client.Documents.Queries.MoreLikeThis.IMoreLikeThisBuilderForAsyncDocumentQuery<T>>)`
* `Raven.Client.Documents.Session.IAsyncDocumentQuery<TResult> OfType<TResult>()`
* `Raven.Client.Documents.Queries.Suggestions.IAsyncSuggestionDocumentQuery<T> SuggestUsing(Raven.Client.Documents.Queries.Suggestions.SuggestionBase)`
* `Raven.Client.Documents.Queries.Suggestions.IAsyncSuggestionDocumentQuery<T> SuggestUsing(System.Action<Raven.Client.Documents.Queries.Suggestions.ISuggestionBuilder<T>>)`

{PANEL/}

{PANEL:IAsyncAdvancedSessionOperations}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `Raven.Client.IAsyncDocumentQuery<T> AsyncDocumentQuery<T>(string, bool)`
* `Raven.Client.IAsyncDocumentQuery<T> AsyncDocumentQuery<T>()`
* `Raven.Client.IAsyncDocumentQuery<T> AsyncLuceneQuery<T, TIndexCreator>()`
* `Raven.Client.IAsyncDocumentQuery<T> AsyncLuceneQuery<T>(string, bool)`
* `Raven.Client.IAsyncDocumentQuery<T> AsyncLuceneQuery<T>()`
* `Task<Raven.Client.Connection.Operation> DeleteByIndexAsync<T, TIndexCreator>(Expression<Func<T, bool>>)`
* `Task<Raven.Client.Connection.Operation> DeleteByIndexAsync<T>(string, Expression<Func<T, bool>>)`
* `string GetDocumentUrl(object)`
* `Task<Raven.Json.Linq.RavenJObject> GetMetadataForAsync<T>(T)`
* `Task<IEnumerable<T>> LoadStartingWithAsync<T>(string, string, int, int, string, Raven.Client.RavenPagingInformation, string, CancellationToken)`
* `Task<IEnumerable<TResult>> LoadStartingWithAsync<TTransformer, TResult>(string, string, int, int, string, Raven.Client.RavenPagingInformation, Action<Raven.Client.ILoadConfiguration>, string, CancellationToken)`
* `Task<Raven.Abstractions.Data.FacetResults[]> MultiFacetedSearchAsync(Raven.Abstractions.Data.FacetQuery[])`
* `void Store(object, Raven.Abstractions.Data.Etag)`
* `void Store(object, Raven.Abstractions.Data.Etag, string)`
* `void Store(object)`
* `void Store(object, string)`
* `Task<Raven.Abstractions.Util.IAsyncEnumerator<Raven.Abstractions.Data.StreamResult<T>>> StreamAsync<T>(IQueryable<T>, CancellationToken)`
* `Task<Raven.Abstractions.Util.IAsyncEnumerator<Raven.Abstractions.Data.StreamResult<T>>> StreamAsync<T>(Raven.Client.IAsyncDocumentQuery<T>, Raven.Abstractions.Extensions.Reference<Raven.Abstractions.Data.QueryHeaderInformation>, CancellationToken)`
* `Task<Raven.Abstractions.Util.IAsyncEnumerator<Raven.Abstractions.Data.StreamResult<T>>> StreamAsync<T>(IQueryable<T>, Raven.Abstractions.Extensions.Reference<Raven.Abstractions.Data.QueryHeaderInformation>, CancellationToken)`
* `Task<Raven.Abstractions.Util.IAsyncEnumerator<Raven.Abstractions.Data.StreamResult<T>>> StreamAsync<T>(Raven.Abstractions.Data.Etag, int, int, Raven.Client.RavenPagingInformation, string, Dictionary<string, Raven.Json.Linq.RavenJToken>, CancellationToken)`
* `Task<Raven.Abstractions.Util.IAsyncEnumerator<Raven.Abstractions.Data.StreamResult<T>>> StreamAsync<T>(string, string, int, int, Raven.Client.RavenPagingInformation, string, string, Dictionary<string, Raven.Json.Linq.RavenJToken>, CancellationToken)`

#### Added Methods

* `Raven.Client.Documents.Session.IAsyncRawDocumentQuery<T> AsyncRawQuery<T>(string)`
* `System.Threading.Tasks.Task<bool> ExistsAsync(string)`
* `Raven.Client.Documents.Session.IAttachmentsSessionOperationsAsync get_Attachments()`
* `Raven.Client.Documents.Session.IRevisionsSessionOperationsAsync get_Revisions()`
* `void Increment<T, U>(T, System.Linq.Expressions.Expression<System.Func<T, U>>, U)`
* `void Increment<T, U>(string, System.Linq.Expressions.Expression<System.Func<T, U>>, U)`
* `System.Threading.Tasks.Task LoadIntoStreamAsync(System.Collections.Generic.IEnumerable<string>, System.IO.Stream, System.Threading.CancellationToken)`
* `System.Threading.Tasks.Task LoadStartingWithIntoStreamAsync(string, System.IO.Stream, string, int, int, string, string, System.Threading.CancellationToken)`
* `void Patch<T, U>(string, System.Linq.Expressions.Expression<System.Func<T, U>>, U)`
* `void Patch<T, U>(T, System.Linq.Expressions.Expression<System.Func<T, U>>, U)`
* `void Patch<T, U>(T, System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<U>>>, System.Linq.Expressions.Expression<System.Func<Raven.Client.Documents.Session.JavaScriptArray<U>, object>>)`
* `void Patch<T, U>(string, System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<U>>>, System.Linq.Expressions.Expression<System.Func<Raven.Client.Documents.Session.JavaScriptArray<U>, object>>)`
* `System.Threading.Tasks.Task StreamIntoAsync<T>(Raven.Client.Documents.Session.IAsyncDocumentQuery<T>, System.IO.Stream, System.Threading.CancellationToken)`
* `System.Threading.Tasks.Task StreamIntoAsync<T>(Raven.Client.Documents.Session.IAsyncRawDocumentQuery<T>, System.IO.Stream, System.Threading.CancellationToken)`

{PANEL/}

{PANEL:IAsyncDocumentSession}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `void Delete<T>(ValueType)`
* `void Delete(string)`
* `Task<T> LoadAsync<T>(ValueType, CancellationToken)`
* `Task<T[]> LoadAsync<T>(CancellationToken, ValueType[])`
* `Task<T[]> LoadAsync<T>(IEnumerable<ValueType>, CancellationToken)`
* `Task<TResult> LoadAsync<TTransformer, TResult>(string, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<TResult[]> LoadAsync<TTransformer, TResult>(IEnumerable<string>, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<TResult> LoadAsync<TResult>(string, string, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<TResult[]> LoadAsync<TResult>(IEnumerable<string>, string, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<TResult> LoadAsync<TResult>(string, Type, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<TResult[]> LoadAsync<TResult>(IEnumerable<string>, Type, Action<Raven.Client.ILoadConfiguration>, CancellationToken)`
* `Task<T> LoadAsync<T>(string, CancellationToken)`
* `Task<T[]> LoadAsync<T>(IEnumerable<string>, CancellationToken)`
* `Raven.Client.Linq.IRavenQueryable<T> Query<T>()`
* `Raven.Client.Linq.IRavenQueryable<T> Query<T, TIndexCreator>()`
* `Task StoreAsync(object, Raven.Abstractions.Data.Etag, string, CancellationToken)`
* `Task StoreAsync(object, string, CancellationToken)`

#### Added Methods

* `Raven.Client.Documents.Session.Loaders.IAsyncLoaderWithInclude<object> Include(string)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLoaderWithInclude<T> Include<T>(System.Linq.Expressions.Expression<System.Func<T, string>>)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLoaderWithInclude<T> Include<T, TInclude>(System.Linq.Expressions.Expression<System.Func<T, string>>)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLoaderWithInclude<T> Include<T>(System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<string>>>)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLoaderWithInclude<T> Include<T, TInclude>(System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<string>>>)`

{PANEL/}

{PANEL:IAdvancedDocumentSessionOperations}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `void ExplicitlyVersion(object)`
* `bool get_AllowNonAuthoritativeInformation()`
* `TimeSpan get_NonAuthoritativeInformationTimeout()`
* `Raven.Abstractions.Data.Etag GetEtagFor<T>(T)`
* `void MarkReadOnly(object)`
* `void set_AllowNonAuthoritativeInformation(bool)`
* `void set_NonAuthoritativeInformationTimeout(TimeSpan)`
* `void UnregisterMissing(string)`

#### Added Methods

* `void add_OnAfterSaveChanges(System.EventHandler<Raven.Client.Documents.Session.AfterSaveChangesEventArgs>)`
* `void add_OnBeforeDelete(System.EventHandler<Raven.Client.Documents.Session.BeforeDeleteEventArgs>)`
* `void add_OnBeforeQuery(System.EventHandler<Raven.Client.Documents.Session.BeforeQueryExecutedEventArgs>)`
* `void add_OnBeforeStore(System.EventHandler<Raven.Client.Documents.Session.BeforeStoreEventArgs>)`
* `void Defer(Raven.Client.Documents.Commands.Batches.ICommandData, Raven.Client.Documents.Commands.Batches.ICommandData[])`
* `void Defer(Raven.Client.Documents.Commands.Batches.ICommandData[])`
* `Sparrow.Json.JsonOperationContext get_Context()`
* `Raven.Client.Documents.Session.EntityToBlittable get_EntityToBlittable()`
* `Raven.Client.Http.RequestExecutor get_RequestExecutor()`
* `string GetChangeVectorFor<T>(T)`
* `System.Threading.Tasks.Task<Raven.Client.Http.ServerNode> GetCurrentSessionNode()`
* `System.Nullable<System.DateTime> GetLastModifiedFor<T>(T)`
* `void remove_OnAfterSaveChanges(System.EventHandler<Raven.Client.Documents.Session.AfterSaveChangesEventArgs>)`
* `void remove_OnBeforeDelete(System.EventHandler<Raven.Client.Documents.Session.BeforeDeleteEventArgs>)`
* `void remove_OnBeforeQuery(System.EventHandler<Raven.Client.Documents.Session.BeforeQueryExecutedEventArgs>)`
* `void remove_OnBeforeStore(System.EventHandler<Raven.Client.Documents.Session.BeforeStoreEventArgs>)`

{PANEL/}

{PANEL:IAsyncLazySessionOperations}

#### Namespace Changed

* 3.x: `Raven.Client.Document.Batches`
* 4.0: `Raven.Client.Documents.Session.Operations.Lazy`

#### Removed Methods

* `Lazy<Task<TResult[]>> LoadAsync<TResult>(IEnumerable<string>, CancellationToken)`
* `Lazy<Task<TResult[]>> LoadAsync<TResult>(IEnumerable<string>, Action<TResult[]>, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TResult>(string, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TResult>(string, Action<TResult>, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TResult>(ValueType, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TResult>(ValueType, Action<TResult>, CancellationToken)`
* `Lazy<Task<TResult[]>> LoadAsync<TResult>(CancellationToken, ValueType[])`
* `Lazy<Task<TResult[]>> LoadAsync<TResult>(IEnumerable<ValueType>, CancellationToken)`
* `Lazy<Task<TResult[]>> LoadAsync<TResult>(IEnumerable<ValueType>, Action<TResult[]>, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TTransformer, TResult>(string, Action<Raven.Client.ILoadConfiguration>, Action<TResult>, CancellationToken)`
* `Lazy<Task<TResult>> LoadAsync<TResult>(string, Type, Action<Raven.Client.ILoadConfiguration>, Action<TResult>, CancellationToken)`
* `Lazy<Task<TResult[]>> MoreLikeThisAsync<TResult>(Raven.Abstractions.Data.MoreLikeThisQuery, CancellationToken)`

#### Added Methods

* `Raven.Client.Documents.Session.Loaders.IAsyncLazyLoaderWithInclude<object> Include(string)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLazyLoaderWithInclude<TResult> Include<TResult>(System.Linq.Expressions.Expression<System.Func<TResult, string>>)`
* `Raven.Client.Documents.Session.Loaders.IAsyncLazyLoaderWithInclude<TResult> Include<TResult>(System.Linq.Expressions.Expression<System.Func<TResult, System.Collections.Generic.IEnumerable<string>>>)`

{PANEL/}

{PANEL:IDocumentQuery<T>}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `string get_IndexQueried()`
* `Raven.Abstractions.Data.QueryResult get_QueryResult()`
* `Raven.Abstractions.Data.FacetResults GetFacets(string, int, Nullable<int>)`
* `Raven.Abstractions.Data.FacetResults GetFacets(List<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Lazy<Raven.Abstractions.Data.FacetResults> GetFacetsLazy(string, int, Nullable<int>)`
* `Lazy<Raven.Abstractions.Data.FacetResults> GetFacetsLazy(List<Raven.Abstractions.Data.Facet>, int, Nullable<int>)`
* `Lazy<IEnumerable<T>> Lazily(Action<IEnumerable<T>>)`
* `Raven.Client.IDocumentQuery<T> SetQueryInputs(Dictionary<string, Raven.Json.Linq.RavenJToken>)`
* `Raven.Client.IDocumentQuery<TTransformerResult> SetResultTransformer<TTransformer, TTransformerResult>()`
* `Raven.Client.IDocumentQuery<T> SetTransformerParameters(Dictionary<string, Raven.Json.Linq.RavenJToken>)`

#### Added Methods

* `Raven.Client.Documents.Queries.Facets.IAggregationDocumentQuery<T> AggregateBy(System.Action<Raven.Client.Documents.Queries.Facets.IFacetBuilder<T>>)`
* `Raven.Client.Documents.Queries.Facets.IAggregationDocumentQuery<T> AggregateBy(Raven.Client.Documents.Queries.Facets.FacetBase)`
* `Raven.Client.Documents.Queries.Facets.IAggregationDocumentQuery<T> AggregateBy(System.Collections.Generic.IEnumerable<Raven.Client.Documents.Queries.Facets.Facet>)`
* `Raven.Client.Documents.Queries.Facets.IAggregationDocumentQuery<T> AggregateUsing(string)`
* `string get_IndexName()`
* `Raven.Client.Documents.Queries.QueryResult GetQueryResult()`
* `Raven.Client.Documents.Session.IGroupByDocumentQuery<T> GroupBy(string, System.String[])`
* `Raven.Client.Documents.Session.IGroupByDocumentQuery<T> GroupBy(System.ValueTuple<string, Raven.Client.Documents.Queries.GroupByMethod>, System.ValueTuple`2<System.String,Raven.Client.Documents.Queries.GroupByMethod>[])`
* `Raven.Client.Documents.Session.IDocumentQuery<T> MoreLikeThis(System.Action<Raven.Client.Documents.Queries.MoreLikeThis.IMoreLikeThisBuilderForDocumentQuery<T>>)`
* `Raven.Client.Documents.Session.IDocumentQuery<TResult> OfType<TResult>()`
* `Raven.Client.Documents.Queries.Suggestions.ISuggestionDocumentQuery<T> SuggestUsing(Raven.Client.Documents.Queries.Suggestions.SuggestionBase)`
* `Raven.Client.Documents.Queries.Suggestions.ISuggestionDocumentQuery<T> SuggestUsing(System.Action<Raven.Client.Documents.Queries.Suggestions.ISuggestionBuilder<T>>)`

{PANEL/}

{PANEL:ISyncAdvancedSessionOperation}

#### Removed Methods

* `Raven.Client.Connection.Operation DeleteByIndex<T, TIndexCreator>(Expression<Func<T, bool>>)`
* `Raven.Client.Connection.Operation DeleteByIndex<T>(string, Expression<Func<T, bool>>)`
* `Raven.Client.IDocumentQuery<T> DocumentQuery<T>(string, bool)`
* `Raven.Client.IDocumentQuery<T> DocumentQuery<T>()`
* `string GetDocumentUrl(object)`
* `T[] LoadStartingWith<T>(string, string, int, int, string, Raven.Client.RavenPagingInformation, string)`
* `TResult[] LoadStartingWith<TTransformer, TResult>(string, string, int, int, string, Raven.Client.RavenPagingInformation, Action<Raven.Client.ILoadConfiguration>, string)`
* `Raven.Client.IDocumentQuery<T> LuceneQuery<T, TIndexCreator>()`
* `Raven.Client.IDocumentQuery<T> LuceneQuery<T>(string, bool)`
* `Raven.Client.IDocumentQuery<T> LuceneQuery<T>()`
* `Raven.Abstractions.Data.FacetResults[] MultiFacetedSearch(Raven.Abstractions.Data.FacetQuery[])`

{PANEL/}

{PANEL:IDocumentSession}

#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `T[] Load<T>(ValueType[])`
* `T[] Load<T>(IEnumerable<ValueType>)`
* `TResult Load<TTransformer, TResult>(string, Action<Raven.Client.ILoadConfiguration>)`
* `TResult[] Load<TTransformer, TResult>(IEnumerable<string>, Action<Raven.Client.ILoadConfiguration>)`
* `TResult Load<TResult>(string, string, Action<Raven.Client.ILoadConfiguration>)`
* `TResult[] Load<TResult>(IEnumerable<string>, string, Action<Raven.Client.ILoadConfiguration>)`
* `TResult Load<TResult>(string, Type, Action<Raven.Client.ILoadConfiguration>)`
* `TResult[] Load<TResult>(IEnumerable<string>, Type, Action<Raven.Client.ILoadConfiguration>)`
* `T Load<T>(string)`
* `T[] Load<T>(IEnumerable<string>)`
* `T Load<T>(ValueType)`
* `Raven.Client.Linq.IRavenQueryable<T> Query<T>()`
* `Raven.Client.Linq.IRavenQueryable<T> Query<T, TIndexCreator>()`
* `void Store(object)`
* `void Store(object, string)`

#### Added Methods

* `Raven.Client.Documents.Session.Loaders.ILoaderWithInclude<object> Include(string)`
* `Raven.Client.Documents.Session.Loaders.ILoaderWithInclude<T> Include<T>(System.Linq.Expressions.Expression<System.Func<T, string>>)`
* `Raven.Client.Documents.Session.Loaders.ILoaderWithInclude<T> Include<T>(System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<string>>>)`
* `Raven.Client.Documents.Session.Loaders.ILoaderWithInclude<T> Include<T, TInclude>(System.Linq.Expressions.Expression<System.Func<T, string>>)`
* `Raven.Client.Documents.Session.Loaders.ILoaderWithInclude<T> Include<T, TInclude>(System.Linq.Expressions.Expression<System.Func<T, System.Collections.Generic.IEnumerable<string>>>)`

{PANEL/}

{PANEL:ILazySessionOperations}

#### Namespace Changed

* 3.x: `Raven.Client.Document.Batches`
* 4.0: `Raven.Client.Documents.Session.Operations.Lazy`

#### Removed Methods

* `Lazy<TResult[]> Load<TResult>(IEnumerable<string>)`
* `Lazy<TResult[]> Load<TResult>(IEnumerable<string>, Action<TResult[]>)`
* `Lazy<TResult> Load<TResult>(string)`
* `Lazy<TResult> Load<TResult>(string, Action<TResult>)`
* `Lazy<TResult> Load<TResult>(ValueType)`
* `Lazy<TResult> Load<TResult>(ValueType, Action<TResult>)`
* `Lazy<TResult[]> Load<TResult>(ValueType[])`
* `Lazy<TResult[]> Load<TResult>(IEnumerable<ValueType>)`
* `Lazy<TResult[]> Load<TResult>(IEnumerable<ValueType>, Action<TResult[]>)`
* `Lazy<TResult> Load<TTransformer, TResult>(string, Action<Raven.Client.ILoadConfiguration>, Action<TResult>)`
* `Lazy<TResult> Load<TResult>(string, Type, Action<Raven.Client.ILoadConfiguration>, Action<TResult>)`
* `Lazy<TResult[]> Load<TTransformer, TResult>(IEnumerable<string>, Action<Raven.Client.ILoadConfiguration>, Action<TResult>)`
* `Lazy<TResult[]> Load<TResult>(IEnumerable<string>, Type, Action<Raven.Client.ILoadConfiguration>, Action<TResult>)`
* `Lazy<TResult[]> MoreLikeThis<TResult>(Raven.Abstractions.Data.MoreLikeThisQuery)`

#### Added Methods

* `Raven.Client.Documents.Session.Loaders.ILazyLoaderWithInclude<object> Include(string)`
* `Raven.Client.Documents.Session.Loaders.ILazyLoaderWithInclude<TResult> Include<TResult>(System.Linq.Expressions.Expression<System.Func<TResult, string>>)`
* `Raven.Client.Documents.Session.Loaders.ILazyLoaderWithInclude<TResult> Include<TResult>(System.Linq.Expressions.Expression<System.Func<TResult, System.Collections.Generic.IEnumerable<string>>>)`

{PANEL/}

{PANEL:WhereParams}
#### Namespace Changed

* 3.x: `Raven.Client`
* 4.0: `Raven.Client.Documents.Session`

#### Removed Methods

* `bool get_IsAnalyzed()`
* `void set_IsAnalyzed(bool)`

#### Added Methods

* `bool get_Exact()`
* `void set_Exact(bool)`

{PANEL/}

{PANEL:DocumentSubscriptions}
#### Namespace Changed

* 3.x: `Raven.Client.Document`
* 4.0: `Raven.Client.Documents.Subscriptions`

#### Removed Methods

* `Raven.Client.Document.Subscription<Raven.Json.Linq.RavenJObject> Open(long, Raven.Abstractions.Data.SubscriptionConnectionOptions, string)`
* `Raven.Client.Document.Subscription<T> Open<T>(long, Raven.Abstractions.Data.SubscriptionConnectionOptions, string)`
* `void Release(long, string)`

#### Added Methods

* `System.Threading.Tasks.Task<string> CreateAsync<T>(Raven.Client.Documents.Subscriptions.SubscriptionCreationOptions<T>, string)`
* `System.Threading.Tasks.Task<string> CreateAsync<T>(System.Linq.Expressions.Expression<System.Func<T, bool>>, Raven.Client.Documents.Subscriptions.SubscriptionCreationOptions, string)`
* `System.Threading.Tasks.Task<string> CreateAsync(Raven.Client.Documents.Subscriptions.SubscriptionCreationOptions, string)`
* `System.Threading.Tasks.Task DeleteAsync(string, string)`
* `void DropConnection(string, string)`
* `System.Threading.Tasks.Task DropConnectionAsync(string, string)`
* `System.Threading.Tasks.Task<System.Collections.Generic.List<Raven.Client.Documents.Subscriptions.SubscriptionState>> GetSubscriptionsAsync(int, int, string)`
* `Raven.Client.Documents.Subscriptions.SubscriptionState GetSubscriptionState(string, string)`
* `System.Threading.Tasks.Task<Raven.Client.Documents.Subscriptions.SubscriptionState> GetSubscriptionStateAsync(string, string)`
* `Raven.Client.Documents.Subscriptions.SubscriptionWorker<object> GetSubscriptionWorker(Raven.Client.Documents.Subscriptions.SubscriptionWorkerOptions, string)`
* `Raven.Client.Documents.Subscriptions.SubscriptionWorker<object> GetSubscriptionWorker(string, string)`
* `Raven.Client.Documents.Subscriptions.SubscriptionWorker<T> GetSubscriptionWorker<T>(Raven.Client.Documents.Subscriptions.SubscriptionWorkerOptions, string)`
* `Raven.Client.Documents.Subscriptions.SubscriptionWorker<T> GetSubscriptionWorker<T>(string, string)`

{PANEL/}

{PANEL:IndexCreation}
#### Removed Methods

* `Raven.Client.Documents.Indexes.IndexDefinition[] CreateIndexesToAdd(System.Collections.Generic.IEnumerable<Raven.Client.Documents.Indexes.AbstractIndexCreationTask>, Raven.Client.Documents.Conventions.DocumentConventions)`
{PANEL/}


## The Following Types (or Entire Namespaces) are No Longer Available

* Raven.Client.AfterStreamExecutedDelegate
* Raven.Client.Bundles.MoreLikeThis.MoreLikeThisExtensions
* Raven.Client.Bundles.Versioning.VersioningExtensions
* Raven.Client.Changes.ConnectionStateBase
* Raven.Client.Changes.IConnectableChanges
* Raven.Client.Changes.IObservableWithTask<T>
* Raven.Client.Changes.RemoteChangesClientBase<TChangesApi, TConnectionState, TConventions>
* Raven.Client.Changes.RemoteDatabaseChanges
* Raven.Client.Changes.TaskedObservable<T, TConnectionState>
* Raven.Client.Connection.AdminRequestCreator
* Raven.Client.Connection.AdminServerClient
* Raven.Client.Connection.Async.AsyncAdminServerClient
* Raven.Client.Connection.Async.AsyncDatabaseCommandsExtensions
* Raven.Client.Connection.Async.AsyncServerClient
* Raven.Client.Connection.Async.AsyncServerClientBase<TConvention, TReplicationInformer>
* Raven.Client.Connection.Async.IAsyncAdminDatabaseCommands
* Raven.Client.Connection.Async.IAsyncDatabaseCommands
* Raven.Client.Connection.Async.IAsyncGlobalAdminDatabaseCommands
* Raven.Client.Connection.Async.IAsyncInfoDatabaseCommands
* Raven.Client.Connection.Async.NameAndCount
* Raven.Client.Connection.CachedRequest
* Raven.Client.Connection.CachedRequestOp
* Raven.Client.Connection.CompressedStreamContent
* Raven.Client.Connection.ConnectionOptions
* Raven.Client.Connection.CreateHttpJsonRequestParams
* Raven.Client.Connection.DocumentConventionJsonExtensions
* Raven.Client.Connection.FailoverStatusChangedEventArgs
* Raven.Client.Connection.HttpConnectionHelper
* Raven.Client.Connection.HttpContentExtentions
* Raven.Client.Connection.HttpJsonRequestFactory
* Raven.Client.Connection.IAdminDatabaseCommands
* Raven.Client.Connection.IDatabaseCommands
* Raven.Client.Connection.IDocumentStoreReplicationInformer
* Raven.Client.Connection.IGlobalAdminDatabaseCommands
* Raven.Client.Connection.IInfoDatabaseCommands
* Raven.Client.Connection.Implementation.HttpJsonRequest
* Raven.Client.Connection.IReplicationInformerBase
* Raven.Client.Connection.IReplicationInformerBase<TClient>
* Raven.Client.Connection.ObservableLineStream
* Raven.Client.Connection.OperationMetadata
* Raven.Client.Connection.Profiling.IHoldProfilingInformation
* Raven.Client.Connection.Profiling.ProfilingContext
* Raven.Client.Connection.Profiling.ProfilingInformation
* Raven.Client.Connection.Profiling.RequestResultArgs
* Raven.Client.Connection.Profiling.RequestStatus
* Raven.Client.Connection.RavenTransactionAccessor
* Raven.Client.Connection.RavenUrlExtensions
* Raven.Client.Connection.ReplicationInformer
* Raven.Client.Connection.ReplicationInformerBase<TClient>
* Raven.Client.Connection.ReplicationInformerLocalCache
* Raven.Client.Connection.Request.AsyncOperationResult<T>
* Raven.Client.Connection.Request.ClusterAwareRequestExecuter
* Raven.Client.Connection.Request.FailureCounter
* Raven.Client.Connection.Request.FailureCounters
* Raven.Client.Connection.Request.FailureTimeSeries
* Raven.Client.Connection.Request.FailureTimeSeries1
* Raven.Client.Connection.Request.IRequestExecuter
* Raven.Client.Connection.Request.ReplicationAwareRequestExecuter
* Raven.Client.Connection.Request.RequestExecuterSelector
* Raven.Client.Connection.SerializationHelper
* Raven.Client.Connection.ServerClient
* Raven.Client.ConventionBase
* Raven.Client.Converters.GuidConverter
* Raven.Client.Converters.Int32Converter
* Raven.Client.Converters.Int64Converter
* Raven.Client.Converters.ITypeConverter
* Raven.Client.Document.AfterAcknowledgment
* Raven.Client.Document.AfterBatch
* Raven.Client.Document.Async.AsyncDocumentKeyGeneration
* Raven.Client.Document.AsyncDocumentSubscriptions
* Raven.Client.Document.AsyncHiLoKeyGenerator
* Raven.Client.Document.AsyncMultiDatabaseHiLoKeyGenerator
* Raven.Client.Document.AsyncMultiTypeHiLoKeyGenerator
* Raven.Client.Document.AsyncShardedDocumentQuery<T>
* Raven.Client.Document.Batches.LazyFacetsOperation
* Raven.Client.Document.Batches.LazyMoreLikeThisOperation<T>
* Raven.Client.Document.Batches.LazyMultiLoadOperation<T>
* Raven.Client.Document.Batches.LazySuggestOperation
* Raven.Client.Document.Batches.LazyTransformerLoadOperation<T>
* Raven.Client.Document.BeforeAcknowledgment
* Raven.Client.Document.BeforeBatch
* Raven.Client.Document.ChunkedRemoteBulkInsertOperation
* Raven.Client.Document.ConsistencyOptions
* Raven.Client.Document.DocumentSessionListeners
* Raven.Client.Document.DTC.*
* Raven.Client.Document.EntityToJson
* Raven.Client.Document.HiLoKeyGenerator
* Raven.Client.Document.HiLoKeyGeneratorBase
* Raven.Client.Document.IAsyncReliableSubscriptions
* Raven.Client.Document.ILowLevelBulkInsertOperation
* Raven.Client.Document.IndexAndTransformerReplicationMode
* Raven.Client.Document.IReliableSubscriptions
* Raven.Client.Document.MultiDatabaseHiLoGenerator
* Raven.Client.Document.MultiTypeHiLoKeyGenerator
* Raven.Client.Document.OpenSessionOptions
* Raven.Client.Document.QueryValueConvertionType
* Raven.Client.Document.RavenClientEnlistment
* Raven.Client.Document.RavenLoadConfiguration
* Raven.Client.Document.RemoteBulkInsertOperation
* Raven.Client.Document.ReplicationBehavior
* Raven.Client.Document.SessionOperations.LoadTransformerOperation
* Raven.Client.Document.SessionOperations.MultiLoadOperation
* Raven.Client.Document.SessionOperations.ShardLoadOperation
* Raven.Client.Document.ShardedBulkInsertOperation
* Raven.Client.Document.ShardedDocumentQuery<T>
* Raven.Client.Document.Subscription<T>
* Raven.Client.Document.SubscriptionConnectionInterrupted
* Raven.Client.DocumentToEntity
* Raven.Client.EntityStored
* Raven.Client.EntityToDocument
* Raven.Client.EscapeQueryOptions
* Raven.Client.Exceptions.NonAuthoritativeInformationException
* Raven.Client.Exceptions.ReadVetoException
* Raven.Client.Exceptions.ServerRequestError
* Raven.Client.Extensions.AsyncExtensions
* Raven.Client.Extensions.HttpJsonRequestExtensions
* Raven.Client.Extensions.MultiDatabase
* Raven.Client.Extensions.MultiTenancyExtensions
* Raven.Client.Extensions.TaskExtensions2
* Raven.Client.Extensions.Time
* Raven.Client.FieldHighlightings
* Raven.Client.FileSystem.*
* Raven.Client.ILoadConfiguration
* Raven.Client.Indexes.AbstractCommonApiForIndexesAndTransformers
* Raven.Client.Indexes.AbstractScriptedIndexCreationTask
* Raven.Client.Indexes.AbstractScriptedIndexCreationTask<TDocument>
* Raven.Client.Indexes.AbstractScriptedIndexCreationTask<TDocument, TReduceResult>
* Raven.Client.Indexes.AbstractTransformerCreationTask
* Raven.Client.Indexes.AbstractTransformerCreationTask<TFrom>
* Raven.Client.Indexes.RavenDocumentsByEntityName
* Raven.Client.ISyncAdvancedSessionOperation
* Raven.Client.ITransactionalDocumentSession
* Raven.Client.Linq.AggregationQuery
* Raven.Client.Linq.DynamicAggregationQuery<T>
* Raven.Client.Linq.RenamedField
* Raven.Client.Listeners.IDocumentConflictListener
* Raven.Client.Listeners.IDocumentConversionListener
* Raven.Client.Listeners.IDocumentDeleteListener
* Raven.Client.Listeners.IDocumentQueryListener
* Raven.Client.Listeners.IDocumentStoreListener
* Raven.Client.Metrics.ComplexTimeMetric
* Raven.Client.Metrics.DecreasingTimeMetric
* Raven.Client.Metrics.IRequestTimeMetric
* Raven.Client.Metrics.RequestTimeMetric
* Raven.Client.QueryConvention
* Raven.Client.RavenPagingInformation
* Raven.Client.RavenQueryHighlightings
* Raven.Client.RavenQueryStatistics
* Raven.Client.Shard.*
* Raven.Client.Util.DisposableStream
* Raven.Client.Util.GlobalLastEtagHolder
* Raven.Client.Util.HttpClientCache
* Raven.Client.Util.IDisposableAsync
* Raven.Client.Util.ILastEtagHolder
* Raven.Client.Util.NoSynchronizationContext
* Raven.Client.Util.SimpleCache
* Raven.Client.Util.Types
* Raven.Client.Documents.Changes.DatabaseConnectionState
* Raven.Client.Documents.Changes.EvictItemsFromCacheBasedOnChanges
* Raven.Client.Documents.Changes.IChangesConnectionState
* Raven.Client.Documents.Conventions.Inflector
* Raven.Client.Documents.Indexes.ExpressionOperatorPrecedence
* Raven.Client.Documents.Indexes.ExpressionOperatorPrecedenceExtension
* Raven.Client.Documents.Indexes.ExpressionStringBuilder
* Raven.Client.Documents.Indexes.IndexDefinitionHelper
* Raven.Client.Documents.Indexes.JSBeautify
* Raven.Client.Documents.Linq.ExpressionInfo
* Raven.Client.Documents.Linq.RavenQueryProvider<T>
* Raven.Client.Documents.Linq.RavenQueryProviderProcessor<T>
* Raven.Client.Documents.Queries.Facets.AggregationQuery<T>
* Raven.Client.Documents.Session.IAsyncDocumentSessionImpl
* Raven.Client.Documents.Session.Loaders.AsyncLazyMultiLoaderWithInclude<T>
* Raven.Client.Documents.Session.Loaders.LazyMultiLoaderWithInclude<T>
* Raven.Client.Documents.Session.Loaders.MultiLoaderWithInclude<T>
* Raven.Client.Documents.Session.Operations.Lazy.LazyLoadOperation<T>
* Raven.Client.Documents.Session.Operations.Lazy.LazyQueryOperation<T>
* Raven.Client.Documents.Session.Operations.Lazy.LazyStartsWithOperation<T>
* Raven.Client.Documents.Session.Operations.LoadOperation
* Raven.Client.Extensions.ExceptionExtensions
* Raven.Client.Extensions.HttpExtensions
* Raven.Client.Http.ServerHash
* Raven.Client.Json.Converters.JsonLuceneDateTimeConverter
* Raven.Client.Util.ObjectReferenceEqualityComparer<T>
* Raven.Client.Util.ReflectionUtil
