namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
                throw new ArgumentException("Invalid UnitType!");

            if (!typeof(IUnit).IsAssignableFrom(model))
                throw new ArgumentException($"\"{unitType}\" is not a UnitType!");

            IUnit unit = (IUnit)Activator.CreateInstance(model, true);

            return unit;
        }
    }
}
