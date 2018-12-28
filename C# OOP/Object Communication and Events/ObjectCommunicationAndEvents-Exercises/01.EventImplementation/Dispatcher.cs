
namespace _01.EventImplementation
{
    public delegate void NameChangedEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangedEventHandler NameChange;
        private string name;        

        public Dispatcher(string name)
        {
            this.name = name; //not using the property in order to avoid method OnNameChane with the initialization ofo the class
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.OnNameChange(new NameChangeEventArgs(value));
                this.name = value;
            }
        }      
        
        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
                this.NameChange.Invoke(this, args);
        }
    }
}
