using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LearningStuff.VContainer
{
    public class LoggerConfigurator : LifetimeScope // class where you register dependencies. idk why it call "Lifetime
    {                                               // Scope" if you register dependencies there
        
        [SerializeField, Space] private LogButtonView _logButtonView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LoggerCompositionRoot>(); //register entry point as root
            builder.Register<Logger>(Lifetime.Singleton); //register log as singleton
            builder.RegisterComponent(_logButtonView); //register LogButtonView (singleton by default)
        }
    }
}