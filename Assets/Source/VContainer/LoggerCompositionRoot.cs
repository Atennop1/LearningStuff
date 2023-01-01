using System;
using JetBrains.Annotations;
using VContainer.Unity;

namespace LearningStuff.VContainer
{
    public class LoggerCompositionRoot : IStartable //composite root for all logger stuff
    {
        private readonly Logger _logger;
        private readonly LogButtonView _logButtonView;
        
        [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public LoggerCompositionRoot(Logger logger, LogButtonView logButtonView)
        {
            _logger = logger ?? throw new ArgumentException("Logger can't be null");
            _logButtonView = logButtonView ? logButtonView : throw new ArgumentException("LogButtonView can't be null");
        }
        
        public void Start()
        {
            _logger.Log("Hello!");
            _logButtonView.LogButton.onClick.AddListener(() => _logger.Log("You taped a button"));
        }
    }
}