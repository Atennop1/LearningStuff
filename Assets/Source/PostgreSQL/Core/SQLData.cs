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
            Value = value ?? throw new ArgumentException("Value can't be null");
        }
    }
}