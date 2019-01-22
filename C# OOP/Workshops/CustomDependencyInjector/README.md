# Custom Dependency Injector

This project contains a simple custom dependency injection framework, in which a dependent object is provided with the object it needs at runtime. The provided object will satisfy the dependency during program execution but would not be known at compile time. Rather than directly instantiating dependencies, or using static references, the objects a class needs in order to perform its actions are provided to the class in some abstracted form.

The injector allows implementation classes to be bound programmatically to an interface, then injected into constructors, methods or fields using an **"Inject"** attribute. When more than one implementation of the same interface is needed, the user can create custom attributes that identify an implementation, then use that attribute when injecting it. 

There are no time scopes defined, so by default, the injector returns a new instance each time it supplies a value.
