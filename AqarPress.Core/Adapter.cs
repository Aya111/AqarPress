using DB_A4D6F8_AqarPress.Data.DatabaseSpecific;

namespace AqarPress.Core
{
    public static class Adapter
    {
        public static string ConnectionString { get; set; }

        public static DataAccessAdapter Create()
        {
            return new DataAccessAdapter(ConnectionString);
        }

        public static DataAccessAdapter Create(string connectionString)
        {
            return new DataAccessAdapter(connectionString);
        }

        /// <summary>
        /// If self is null, will create a new data access adapter
        /// </summary>
        /// <param name="self"></param>
        /// <param name="level"></param>
        /// <param name="transactionName"></param>
        /// <returns></returns>
        public static DataAccessAdapter CreateTransaction(this DataAccessAdapter self, System.Data.IsolationLevel level, string transactionName)
        {
            if (self == null)
                self = Create();

            self.StartTransaction(level, transactionName);
            return self;
        }
    }
}