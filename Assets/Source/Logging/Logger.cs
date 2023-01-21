using System;
using System.IO;
using UnityEngine;

namespace LearningStuff.Logging
{
    public class Logger
    {
        private readonly string _workingDirectory = $"{Application.persistentDataPath}/Logs";
        private FileWriter _fileWriter;

        private const string DATE_FORMAT = "yyyy-MM-dd";
        private string _dateOfLastLog = string.Empty;

        public Logger()
        {
            if (!Directory.Exists(_workingDirectory))
                Directory.CreateDirectory(_workingDirectory);

            _fileWriter = CreateFileWriter();
        }

        public void Log(string message, LogType type)
        {
            if (_dateOfLastLog != DateTime.UtcNow.ToString(DATE_FORMAT))
                _fileWriter = CreateFileWriter();
            
            _fileWriter.Write(new LogMessage(message, type));
            _dateOfLastLog = DateTime.UtcNow.ToString(DATE_FORMAT);
        }

        private FileWriter CreateFileWriter()
            => new($"{_workingDirectory}/{DateTime.UtcNow.ToString(DATE_FORMAT)}.log");
    }
}