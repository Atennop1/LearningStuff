using System.Collections.Generic;
using UnityEngine;

namespace LearningStuff.Multithreading
{
    public class SemaphoreTest : MonoBehaviour
    {
        private void Awake()
        {
            var readers = new List<Reader>();

            for (var i = 1; i < 6; i++)
                readers.Add(new Reader($"Reader {i}"));

            var library = new Library(readers);
            library.StartWorkDay();
        }
    }
}