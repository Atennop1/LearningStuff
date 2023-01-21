using System;
using System.IO;
using System.Text;

namespace LearningStuff.Logging
{
    public class FileWriter
    {
        private readonly string _filePath;
        private const string LOG_MESSAGE_FORMAT = "{0:dd/MM/yyyy HH:mm:ss:ffff} [{1}]: {2}\r";

        public FileWriter(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public void Write(LogMessage message)
        {
            using var fileStream = File.Open(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            var messageToWrite = string.Format(LOG_MESSAGE_FORMAT, message.Date, message.Type, message.Text);
            
            var bytes = Encoding.UTF8.GetBytes(messageToWrite);
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}