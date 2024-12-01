/* This idea comes from the 1st chapter of Head First Design Patterns 1st Ed */
using Extending_Behaviour;
using Extending_Behaviour.Behaviour;
using Shared;

RubberDuckEncapsulatedBehavioursExample duck = new RubberDuckEncapsulatedBehavioursExample();

duck.fly();
duck.setFlyBehaviour(new FlyRocket());
duck.fly();