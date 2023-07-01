using System.Collections.Immutable;

namespace The_BCSAP_Algorithm
{
    internal class ServerAdmin
    {
        public string? SuperSecretInfo { get; set; }

        private const string ServerAdminUsername = "CloudJumper";
        private const string ServerAdminPassword = "123";

        private static Dictionary<int, string> dataHolder = new Dictionary<int, string>();

        private static ImmutableDictionary<int, string> DataHolder { get { return dataHolder.ToImmutableDictionary(); } }
        public static bool IsAdmin(string? username, string? password)
        {
            if (username == ServerAdminUsername && password == ServerAdminPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddToDataHolder(int id, string decyphered)
        {
            dataHolder.Add(id, decyphered);
            SeedImmutableDictionary(dataHolder);
        }
        private static void SeedImmutableDictionary(Dictionary<int, string> data)
        {
            foreach (var item in data)
            {
                ImmutableDictionary.CreateRange(new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(item.Key, item.Value)
                 });
            }
        }
        public static void Show(string username, string password)
        {
            if (username == ServerAdminUsername && password == ServerAdminPassword)
            {
                ShowImmutableDictionaryContent(DataHolder);
            }
        }
        private static void ShowImmutableDictionaryContent(ImmutableDictionary<int, string> data)
        {
            foreach (var pair in data)
            {
                Console.WriteLine($"User {pair.Key}'s super secret info is {pair.Value}!");
            }
        }
    }
}
