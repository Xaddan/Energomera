namespace Application.Common.Models
{
    public class Error
    {
        public Error(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Error(string value) : this(string.Empty, value)
        {
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}
