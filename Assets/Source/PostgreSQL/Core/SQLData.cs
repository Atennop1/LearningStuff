using System;

namespace LearningStuff.PostgreSQL.Core
{
    public struct SQLData
    {
        public readonly string Name;
        public readonly object Value;

        public SQLData(string name, object value)
        {
            Name = name ?? throw new ArgumentException("Name can't be null");
            Value = value ?? throw new ArgumentNullException(nameof(value));

            if (Value is string valueString && (string.IsNullOrEmpty(valueString) || valueString.IndexOfAny("&^\"\'@#$&|".ToCharArray()) != -1))
                throw new ArgumentException("Value contains forbidden symbols");
        }
    }
}