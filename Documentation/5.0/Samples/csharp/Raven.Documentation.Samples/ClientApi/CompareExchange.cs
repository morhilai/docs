﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Operations.CompareExchange;
using Raven.Client.Documents.Operations.Configuration;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using Raven.Client.Http;
using Raven.Client.ServerWide;
using Raven.Documentation.Samples.ClientApi.Operations.Maintenance.Backup;
using Raven.Documentation.Samples.Indexes.Querying;

namespace Raven.Documentation.Samples.ClientApi.Operations
{
    public class CompareExchange
    {
        private interface IFoo
        {
            /*
            #region get_0
            public GetCompareExchangeValueOperation(string key)
            #endregion

            #region get_list_0
            public GetCompareExchangeValuesOperation(string[] keys)
            #endregion

            #region get_list_1
            public GetCompareExchangeValuesOperation(string startWith, int? start = null, int? pageSize = null)
            #endregion

            #region put_0
            public PutCompareExchangeValueOperation(string key, T value, long index)
            #endregion

            #region delete_0
            public DeleteCompareExchangeValueOperation(string key, long index)
            #endregion
            */
        }
        private class Foo
        {
            #region compare_exchange_value
            public class CompareExchangeValue<T>
            {
                public readonly string Key;
                public readonly T Value;
                public readonly long Index;
            }
            #endregion

            #region compare_exchange_result
            public class CompareExchangeResult<T>
            {
                public bool Successful;
                public T Value;
                public long Index;
            }
            #endregion
        }

        public CompareExchange()
        {
            using (var store = new DocumentStore())
            {
                {
                    #region get_1
                    CompareExchangeValue<long> readResult =
                        store.Operations.Send(new GetCompareExchangeValueOperation<long>("NextClientId"));

                    long value = readResult.Value;
                    #endregion
                }

                {
                    #region get_2
                    CompareExchangeValue<User> readResult =
                        store.Operations.Send(new GetCompareExchangeValueOperation<User>("AdminUser"));

                    User admin = readResult.Value;
                    #endregion
                }

                {
                    #region get_list_2
                    Dictionary<string, CompareExchangeValue<string>> compareExchangeValues
                        = store.Operations.Send(
                            new GetCompareExchangeValuesOperation<string>(new[] { "Key-1", "Key-2" }));
                    #endregion
                }

                {
                    #region get_list_3
                    // Get values for keys that have the common prefix 'users'
                    // Retrieve maximum 20 entries
                    Dictionary<string, CompareExchangeValue<User>> compareExchangeValues
                        = store.Operations.Send(new GetCompareExchangeValuesOperation<User>("users", 0, 20));
                    #endregion
                }

                {
                    #region put_1 
                    CompareExchangeResult<string> compareExchangeResult
                        = store.Operations.Send(
                            new PutCompareExchangeValueOperation<string>("Emails/foo@example.org", "users/123", 0));

                    bool successful = compareExchangeResult.Successful;
                    // If successfull is true: then Key 'foo@example.org' now has the value of "users/123"
                    #endregion
                }

                {
                    #region put_2
                    // Get existing value
                    CompareExchangeValue<User> readResult =
                        store.Operations.Send(
                            new GetCompareExchangeValueOperation<User>("AdminUser"));

                    readResult.Value.Age++;

                    // Update value
                    CompareExchangeResult<User> saveResult
                        = store.Operations.Send(
                            new PutCompareExchangeValueOperation<User>("AdminUser", readResult.Value, readResult.Index));

                    // The save result is successful only if 'index' wasn't changed between the read and write operations
                    bool saveResultSuccessful = saveResult.Successful;
                    #endregion
                }

                {
                    #region delete_1
                    // First, get existing value
                    CompareExchangeValue<User> readResult =
                        store.Operations.Send(
                            new GetCompareExchangeValueOperation<User>("AdminUser"));

                    // Delete the key - use the index received from the 'Get' operation
                    CompareExchangeResult<User> deleteResult
                        = store.Operations.Send(
                            new DeleteCompareExchangeValueOperation<User>("AdminUser", readResult.Index));

                    // The delete result is successful only if the index has not changed between the read and delete operations
                    bool deleteResultSuccessful = deleteResult.Successful;
                    #endregion
                }

                #region expiration_0
                using (IAsyncDocumentSession session = store.OpenAsyncSession())
                {
                    // Set a time exactly one week from now
                    DateTime expirationTime = DateTime.UtcNow.AddDays(7);

                    // Create a new compare exchange value
                    var cmpxchgValue = session.Advanced.ClusterTransaction.CreateCompareExchangeValue("key", "value");

                    // Edit Metadata
                    cmpxchgValue.Metadata[Constants.Documents.Metadata.Expires] = expirationTime;

                    // Send to server
                    session.SaveChangesAsync();
                }
                #endregion

                using (IAsyncDocumentSession session = store.OpenAsyncSession())
                {
                    #region expiration_1
                    // Retrieve an existing key
                    CompareExchangeValue<string> cmpxchgValue = store.Operations.Send(
                            new GetCompareExchangeValueOperation<string>("key"));
                
                    // Set time
                    DateTime expirationTime = DateTime.UtcNow.AddDays(7);
                    
                    // Edit Metadata
                    cmpxchgValue.Metadata[Constants.Documents.Metadata.Expires] = expirationTime;
                
                    // Update value. Index must match the index on the server side,
                    // or the operation will fail.
                    CompareExchangeResult<string> result = store.Operations.Send(
                            new PutCompareExchangeValueOperation<string>(
                                cmpxchgValue.Key,
                                cmpxchgValue.Value,
                                cmpxchgValue.Index));
                    #endregion
                }
            }
        }

        private class User
        {
            public int Age { get; set; }
        }
    }
}
