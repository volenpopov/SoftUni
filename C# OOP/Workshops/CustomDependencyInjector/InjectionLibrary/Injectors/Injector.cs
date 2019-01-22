using InjectionLibrary.Modules.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace InjectionLibrary.Injectors
{    
    public class Injector
    {
        private const string ATTRIBUTE_ERROR = 
            "There must be only field or constructor annotated with Inject attribute!";

        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(ctor => ctor.GetCustomAttributes(typeof(Inject), true).Any());
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
                throw new ArgumentException(ATTRIBUTE_ERROR);

            if (hasConstructorAttribute)
                return this.CreateConstructorInjection<TClass>();
            else if (hasFieldAttribute)
                return this.CreateFieldInjection<TClass>();

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desiredClass = typeof(TClass);
            var desiredClassInstance = this.module.GetInstance(desiredClass);

            if (desiredClassInstance == null)
            {
                desiredClassInstance = Activator.CreateInstance(desiredClass);
                this.module.SetInstance(desiredClass, desiredClassInstance);
            }

            var fields = desiredClass.GetFields((BindingFlags)62);
            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(Inject), true).Any())
                {
                    var injection = (Inject)field
                        .GetCustomAttributes(typeof(Inject), true)
                        .FirstOrDefault();

                    Type dependency = null;

                    var named = field.GetCustomAttribute(typeof(Named), true);

                    var type = field.FieldType;

                    if (named == null)
                        dependency = this.module.GetMapping(type, injection);
                    else
                        dependency = this.module.GetMapping(type, named);

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        field.SetValue(desiredClassInstance, instance);
                    }
                }
            }

            return (TClass)desiredClassInstance;
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desiredClass = typeof(TClass);

            if (desiredClass == null)
                return default(TClass);

            var constructors = desiredClass.GetConstructors();
            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                    continue;

                var inject = (Inject)constructor
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttribute(typeof(Named));

                    Type dependency = null;

                    if (named == null)
                        dependency = this.module.GetMapping(parameterType.ParameterType, inject);
                    else
                        dependency = this.module.GetMapping(parameterType.ParameterType, named);

                    if (parameterType.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);
                        if (instance != null)
                            constructorParams[i++] = instance;
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desiredClass, constructorParams);
            }

            return default(TClass);
        }
    }
}
