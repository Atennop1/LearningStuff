using System;
using System.Threading;
using UnityEngine;

namespace LearningStuff.Multithreading
{
    public class Reader
    {
        private readonly string _name;

        public Reader(string name)
        {
            _name = name ?? throw new ArgumentException("Name can't be null");
        }

        public void ReadBook()
        {
            Debug.Log($"{_name} enter the library");
            Debug.Log($"{_name} reading");

            Thread.Sleep(1000);
            Debug.Log($"{_name} leaves library");
        }
    }
}