using System;
using System.Collections.Generic;
using System.Threading;

namespace LearningStuff.Multithreading
{
    public class Library
    {
        private readonly List<Reader> _readers;
        private readonly Semaphore _semaphore;

        public Library(List<Reader> readers)
        {
            _readers = readers ?? throw new ArgumentException("Readers can't be null");
            _semaphore = new Semaphore(3, 3);
        }

        public void StartWorkDay()
        {
            foreach (var reader in _readers)
            {
                var newReadingThread = new Thread(() =>
                {
                    _semaphore.WaitOne();
                    reader.ReadBook();
                    _semaphore.Release();
                });

                newReadingThread.Start();
            }
        }
    }
}