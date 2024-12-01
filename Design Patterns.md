# Scenarios and which patterns address them

### Constructing Objects
- Builder
- Factory

# Object Orientation

### Extending behaviour

When we need a superclass A, with an x amount of sub-classes, we may need to both inheric certain behaviours, but implement others per sub-class.
There are two obvious solutions here: Inheriting some behaviours from a parent (inheritance), and implementing interfaces for the specific behaviours.
But these present two problems:
1. Inheritence can cause incorrect behaviour in sub-classes. 
2. Interfaces may result in you duplicating code.

A solution to this, is offloading behaviours to another class. Then one can define the behaviour of a method in a sub-class, during runtime! 

The Extending Behaviour example program, can be found in the OO folder of the MyLearning repo.

# Patterns

### Builder

Some objects require a lot of ceremony to ceate. For example when you want to construct a large string, it's not efficient to call the constructor many times, but rather use the StringBuilder.
Having too many constructor arguments is not good! Rather, allow piecewise construction => The Builder Pattern provides an API for the step-by-step construction of an object.

### Factory

Constructors have some limitations: The Name must be of the containing type, you cannot overload the same sets of arguments and constructors can turn into "optional paramater hell".
The creation of an object can be outsourced to a Factory Method. This differs from a builder, as it is a single invocation and a builder does piecewise construction.