using System;
using System.Collections.Generic;
using System.Linq;
using InjectionLibrary.Injectors;
using InjectionLibrary.Modules.Contracts;

namespace InjectionLibrary.Modules
{
    public abstract class AbstractModule : IModule
    {
        private const string NO_AVAILABLE_MAPPING_MSG = "No available mapping for class: {0}";

        private IDictionary<Type, Dictionary<string, Type>> implementations;

        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplementation>()
        {
            if (!this.implementations.ContainsKey(typeof(TInterface)))
            {
                this.implementations[typeof(TInterface)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInterface)]
                .Add(typeof(TImplementation).Name ,typeof(TImplementation));
        }

        public object GetInstance(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);

            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                    type = currentImplementation.Values.First();
                else
                    throw new ArgumentException(
                        string.Format(NO_AVAILABLE_MAPPING_MSG, currentInterface.FullName));
            }

            else
            {
                Named named = (Named)attribute;
                string dependencyName = named.Name;

                type = currentImplementation[dependencyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
                this.instances.Add(implementation, instance);
        }
    }
}
