using System.Threading;
using UnityEngine;

namespace LearningStuff.Multithreading
{
    public class CreateThreadsTest : MonoBehaviour
    {
        private void Awake()
        {
            var firstThread = new Thread(() => PrintMessages("First Thread", 5));
            firstThread.Start();
            
            var secondThread = new Thread(() => PrintMessages("Second Thread", 3));
            secondThread.Start();
            
            PrintMessages("Main Thread", 1);
        }
        
        private void PrintMessages(string message, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Debug.Log($"{message}: {i}");
                Thread.Sleep(500);
            }
        }
    }
}