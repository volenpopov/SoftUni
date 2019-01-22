using System;

namespace InjectionLibrary.Modules.Contracts
{
    public interface IModule
    {
        //Used for configuring the relation between the interface and the class which inherits it
        void Configure();

        //Returns the class which inherits the current interface. 
        Type GetMapping(Type currentInterface, object attribute);

        //Returns the instance of the current class or null (if it doesnt exist)
        object GetInstance(Type type);

        void SetInstance(Type implementation, object instance );
    }
}
