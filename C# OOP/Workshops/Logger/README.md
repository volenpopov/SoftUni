Logger

This project contains a logging application, written following the SOLID principles.

Whenever a logger is told to log something, it calls all of its appenders and tells them to append the message. In turn, the appenders append the message (e.g. to the console or a file) according to the layout they have.

The end-user should be able to add his own layouts/appenders/loggers and use them. For example, he should be able to create his own XmlLayout and make the appenders use it, without directly editing the library source code.

More info can be found in the following file: "Logger - 01. CSharp-OOP-Advanced-SOLID-Exercise"
