using System;

namespace LearningStuff.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NumberAttribute : Attribute { }
}
