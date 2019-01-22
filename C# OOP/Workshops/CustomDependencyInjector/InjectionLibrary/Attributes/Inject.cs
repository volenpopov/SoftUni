using System;

namespace InjectionLibrary.Injectors
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    { }
}
