using System.Threading;
using UnityEngine;

namespace LearningStuff.Multithreading
{
    public class LockTest : MonoBehaviour
    {
        private int number;
        private readonly object locker = new();

        private void Awake()
        {
            for (var i = 1; i < 6; i++)
            {
                var newThread = new Thread(Print)
                {
                    Name = $"Thread {i}"
                };
                
                newThread.Start();
            }
        }
        
        private void Print()
        {
            lock (locker)
            {
                number = 1;
                for (var i = 0; i < 5; i++)
                {
                    Debug.Log($"{Thread.CurrentThread.Name}: {number}");
                    number++;
                    
                    Thread.Sleep(100);
                }
            }
        }
    }
}
