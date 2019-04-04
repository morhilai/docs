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
            //if ID already exists, extracts the ID from the entity 
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
                    //Create a new entity
                    Employee employee = new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe"
                    };

                    //Store the entity and generate an ID automatically
                    session.Store(employee);

                    //Save the newly generated ID for client-side use
                    string NewEmployeeId = employee.Id;

                    //Send the entity to the server
                    session.SaveChanges();
                }
                #endregion
            }
        }
    }
}
