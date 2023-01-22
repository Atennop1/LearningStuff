using System;
using System.IO;
using UnityEngine;

namespace LearningStuff.Logging
{
    public class IOExceptionsHandler
    {
        public void Handle(Exception exception)
        {
            switch (exception)
            {
                case NotSupportedException:
                    Debug.LogError("This function isn't supported");
                    break;
                
                case DirectoryNotFoundException:
                    Debug.LogError("Directory doesn't exist");
                    break;
                
                case UnauthorizedAccessException:
                    Debug.LogError("Can't get access to file");
                    break;
                
                case IOException:
                    Debug.LogError("Something went wrong");
                    break;
                
                default:
                    throw exception;
            }
        }
    }
}