namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    //using System.Collections.Generic;
    //using System.Linq   

    public class Tests
    {       
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CtorThrowsArgExWhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, "M7"));
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]       
        public void CtorThrowsArgExWhenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("HTC", model));
        }

        //[Test]
        //public void PhonebookIsEmptyWhenPhoneInitialized()
        //{
        //    var phone = new Phone("HTC", "M7");
        //    var phonebook = phone.GetType()
        //       .GetField("phonebook", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
        //       .GetValue(phone);

        //    Assert.AreEqual(new Dictionary<string, string>(), phonebook);
        //}


            //?
        [Test]
        public void CountWorks()
        {
            var phone = new Phone("HTC", "M7");

            Assert.AreEqual(0, phone.Count);

            phone.AddContact("Pesho", "123");

            Assert.AreEqual(1, phone.Count);
        }


        [Test]
        public void AddContextThrowsIOexPersonExist()
        {
            var phone = new Phone("HTC", "M7");
            phone.AddContact("Pesho", "123");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "456"));
        }

        //[Test]
        //public void AddContactWorksCorrectly()
        //{
        //    var name = "Pesho";
        //    var number = "123";

        //    var phone = new Phone("HTC", "M7");
        //    phone.AddContact(name, number);

        //    KeyValuePair<string, string> kvp =
        //        new KeyValuePair<string, string>("Pesho", "123");

        //    var personKvp = (Dictionary<string, string>)phone.GetType()
        //        .GetField("phonebook", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
        //        .GetValue(phone);
            
        //    Assert.AreEqual(kvp, personKvp.First());
        //}

        [Test]
        public void CallThrowsIoExWhenPersonDoesntExist()
        {
            var phone = new Phone("HTC", "M7");
            Assert.Throws<InvalidOperationException>(() => phone.Call("Pehso"));
        }


        [Test]   
        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void  CallReturnsCorrectString(string name)
        {
            var phone = new Phone("HTC", "M7");
            phone.AddContact(name, "123");

            string result = $"Calling {name} - 123...";

            Assert.AreEqual(result, phone.Call(name));
        }
    }
}