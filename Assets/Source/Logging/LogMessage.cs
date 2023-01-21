using System;
using UnityEngine;

namespace LearningStuff.Logging
{
    public readonly struct LogMessage
    {
        public readonly string Text;
        public readonly DateTime Date;
        public readonly LogType Type;

        public LogMessage(string text, LogType type)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Date = DateTime.UtcNow;
            Type = type;
        }
    }
}