using System.Collections.Specialized;
using System.Configuration;
using UnityEngine;

namespace LearningStuff.Configs
{
    public class ConfigsTest : MonoBehaviour
    {
        private void Awake()
        {
            if (ConfigurationManager.GetSection("human") is not NameValueCollection humanConfigSection) 
                return;
            
            var firstName = humanConfigSection["FirstName"];
            var lastName = humanConfigSection["LastName"];
            var age = int.Parse(humanConfigSection["Age"]);
            
            Debug.Log($"First name: {firstName}\nLast name: {lastName}\nAge: {age}");
        }
    }
}
