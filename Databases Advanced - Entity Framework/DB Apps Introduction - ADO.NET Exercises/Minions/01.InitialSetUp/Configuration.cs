
namespace _01.InitialSetUp
{
    public class Configuration
    {
        private const string SERVER_NAME = "DESKTOP-4O9GE86;";
        private const string DATABASE = "MinionsDB;";
        private const string AUTHENTICATION = "Integrated Security=true";

        public string ConnectionString => $@"
                    Server={SERVER_NAME}
                    Database={DATABASE}
                    {AUTHENTICATION}";

        public string ServerName
        {
            get { return SERVER_NAME; }
        }

        public string Database
        {
            get { return DATABASE; }
        }

        public string Authentication
        {
            get { return AUTHENTICATION; }
        }

    }
}
