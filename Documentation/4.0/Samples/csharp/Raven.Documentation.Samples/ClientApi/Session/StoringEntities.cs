using Raven.Client.Documents;
using Raven.Documentation.Samples.Orders;

namespace Raven.Documentation.Samples.ClientApi.Session
{
    public class StoringEntities
    {
        private interface IFoo
        {
            #region store_entities_1
            //First overload: 
            //stores the entity in a session 
            //generates a new ID if none exists
            //extracts the ID from the entity if it already exists.
            void Store(object entity);

            //Second overload: 
            //stores the entity in a session with a given ID.
            void Store(object entity, string id);

            //Third overload: 
            //stores the entity in a session with a given ID
            //forces a concurrency check with a given change vector.
            void Store(object entity, string changeVector, string id);
            #endregion

        }

        public StoringEntities()
        {
            using (var store = new DocumentStore())
            {
                #region store_entities_5                
                using (var session = store.OpenSession())
                {
                    //Store an entity and generate Id automatically
                    session.Store(new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    });

                    //Send accumulated operations to server
                    session.SaveChanges();
                }
                #endregion
            }
        }
    }
}
