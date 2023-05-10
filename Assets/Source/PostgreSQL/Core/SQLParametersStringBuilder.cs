﻿using System.Text;

namespace LearningStuff.PostgreSQL.Core
{
    public sealed class SQLParametersStringBuilder
    {
        public string BuildParameters(string[] names, string delimiter)
        {
            var stringBuilder = new StringBuilder();
            
            foreach (var name in names)
            {
                stringBuilder.Append(name);
                stringBuilder.Append(name != names[^1] ? delimiter : string.Empty);
            }

            return stringBuilder.ToString();
        }
    }
}