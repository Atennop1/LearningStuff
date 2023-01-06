using System.Threading;
using UnityEngine;

namespace LearningStuff.Multithreading
{
    public class ThreadInfoTest : MonoBehaviour
    {
        private void Awake()
        {
            var currentThread = Thread.CurrentThread;
            
            Debug.Log($"Thread name: {currentThread.Name}");
            currentThread.Name = "UnityEngine";
            Debug.Log($"Thread name: {currentThread.Name}");
 
            Debug.Log($"Is thread alive: {currentThread.IsAlive}");
            Debug.Log($"Thread ID: {currentThread.ManagedThreadId}");
            Debug.Log($"Thread priority: {currentThread.Priority}");
            Debug.Log($"Thread status: {currentThread.ThreadState}");
        }
    }
}
