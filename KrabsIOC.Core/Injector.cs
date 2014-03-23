using System;
using System.Collections.Generic;
using System.Linq;

namespace KrabsIOC.Core
{
    public class Injector
    {
        private readonly Dictionary<Type, Func<object>> providers = new Dictionary<Type, Func<object>>();
        
       

        public void Bind<TKey, TConcrete>() where TConcrete : TKey
        {
            providers[typeof(TKey)] = () => ResolveByType(typeof(TConcrete));
        }
  
        private object ResolveByType(Type type)
        {
            var constructor = type.GetConstructors().SingleOrDefault();
            if (constructor != null)
            {
                var args = constructor.GetParameters()
                                      .Select(p => Resolve(p.ParameterType))
                                      .ToArray();
                return constructor.Invoke(args);
            }
            var instanceField = type.GetField("Instance");
            return instanceField.GetValue(null);
        }

        public void Bind<T>(T instance)
        {
            providers[typeof(T)] = () => instance;
        }

        public TKey Resolve<TKey>()
        {
            return (TKey)Resolve(typeof(TKey));
        }

        internal object Resolve(Type type)
        {
            Func<object> provider;
            if (providers.TryGetValue(type, out provider))
            {
                return provider();
            }
            return ResolveByType(type);
        }
    }
}
