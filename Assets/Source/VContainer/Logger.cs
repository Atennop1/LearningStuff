using JetBrains.Annotations;
using UnityEngine;

namespace LearningStuff.VContainer
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    public class Logger //simple class who logs messages
    {
        public void Log(string message) => Debug.Log(message);
    }
}
