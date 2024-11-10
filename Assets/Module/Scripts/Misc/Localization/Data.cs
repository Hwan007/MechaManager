
namespace Localization
{
    public struct Data
    {
        private string table;
        private string key;

        public Data(string table, string key)
        {
            this.table = table;
            this.key = key;
        }

        public string Table { get => table; }
        public string Key { get => key; }
    }

    public enum ELanguageType
    {
        English,
        Korean,
    }
}