using System;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Commands.Batches;
using Raven.Documentation.Samples.Orders;


namespace Raven.Documentation.Samples.ClientApi.Session
{
    public class DeletingEntities
    {
        private interface IFoo
        {
            #region deleting_1

            //Delete an entity of type `T`
            void Delete<T>(T entity);

            //Delete an entity with a given id
            void Delete(string id);

            //Delete an entity with a given id
            //and a given expected change vector.
            void Delete(string id, string expectedChangeVector);
            //If the change vector doesn't match the one in the server
            //a concurrency exception will be thrown.
            #endregion
        }

        public async Task DeletingEntitiesAsync()
        {
            using (var store = new DocumentStore())
            {

                using (var session = store.OpenSession())
                {
                    #region deleting_2
                    //Load a document from the database
                    //including its change vector and any other metadata
                    Employee employee = session.Load<Employee>("employees/1");

                    //Mark the document for deletion
                    session.Delete(employee);

                    //Send the delete operation to the server
                    session.SaveChanges();
                    #endregion
                }

                using (var session = store.OpenAsyncSession())
                {
                    #region deleting_2_async
                    //Load a document from the database
                    //including its change vector and any other metadata
                    Employee employee = await session.LoadAsync<Employee>("employees/1");

                    //Mark the document for deletion
                    session.Delete(employee);

                    //Send the delete operation to the server asynchronously
                    await session.SaveChangesAsync();
                    #endregion
                }


                using (var session = store.OpenSession())
                {
                    #region deleting_3
                    //Mark the document for deletion
                    session.Delete("employees/1");

                    //Send the delete operation to the server
                    session.SaveChanges();
                    #endregion
                }

                using (var session = store.OpenAsyncSession())
                {
                    #region deleting_3_async
                    //Mark the document for deletion
                    session.Delete("employees/1");

                    //Send the delete operation to the server asynchronously
                    await session.SaveChangesAsync();
                    #endregion
                }

                using (var session = store.OpenSession())
                {
                    #region deleting_4
                    session.Delete("employees/1");
                    #endregion

                    #region deleting_5
                    session.Advanced.Defer(new DeleteCommandData("employees/1", changeVector: null));
                    #endregion
                }
            }
        }
    }
}
