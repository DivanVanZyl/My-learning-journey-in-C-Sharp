# Scenarios

### Constructing Objects
- Builder
- Factory

# Patterns

### Builder

Some objects require a lot of ceremony to ceate. For example when you want to construct a large string, it's not efficient to call the constructor many times, but rather use the StringBuilder.
Having too many constructor arguments is not good! Rather, allow piecewise construction => The Builder Pattern provides an API for the step-by-step construction of an object.

### Factory

Constructors have some limitations: The Name must be of the containing type, you cannot overload the same sets of arguments and constructors can turn into "optional paramater hell".
The creation of an object can be outsourced to a Factory Method. This differs from a builder, as it is a single invocation and a builder does piecewise construction.