using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LearningStuff.Attributes
{
    public class NumberAttributesAdder : MonoBehaviour
    {
        private void Awake()
        {
            var monoBehaviours = FindObjectsOfType<MonoBehaviour>();
            Debug.Log($"Sum of all number is {CalculateSumOfAllAttributes(monoBehaviours)}");
        }

        private float CalculateSumOfAllAttributes(IEnumerable<MonoBehaviour> monoBehaviours)
        {
            var sum = 0f;

            foreach (var monoBehaviour in monoBehaviours)
            {
                var fields = monoBehaviour.GetType().
                    GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).
                    Where(field => Attribute.IsDefined(field, typeof(NumberAttribute)) && (field.FieldType == typeof(int) ||
                    field.FieldType == typeof(float))).ToList();

                var staticFields = monoBehaviour.GetType().
                    GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).
                    Where(field => Attribute.IsDefined(field, typeof(NumberAttribute)) && (field.FieldType == typeof(int) ||
                    field.FieldType == typeof(float))).ToList();

                sum += fields.Select(field => field.GetValue(monoBehaviour) is int ? (int)field.GetValue(monoBehaviour) : 0).Sum() +
                       fields.Select(field => field.GetValue(monoBehaviour) is float ? (float)field.GetValue(monoBehaviour) : 0).Sum();
                
                sum += staticFields.Select(field => field.GetValue(null) is int ? (int)field.GetValue(null) : 0).Sum() +
                       staticFields.Select(field => field.GetValue(null) is float ? (float)field.GetValue(null) : 0).Sum();
            }
            
            return sum;
        }
    }
}