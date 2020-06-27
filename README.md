# solidemo
# Encapsulation
Encapsulation is implementation hiding and protection of invariants.
## What are invariants? 
PreCondition and PostConditions checks are invariants, which makes impossible for a  object to be at invalid state. which is also called assertion.
A precondition is the state of the system and its surroundings that is required before the use case can be started. 
A postcondition is the states the system can be in after the use case has ended. Consider the following: 
The states described by pre- or postconditions should be states that the user can observe.

# SRP- 
Class should have only one responsibility, and should have only single (responsibility)reason to change. Here we are talking about separation of concern. 
whatever are those concern might be we want o vary the independently. Ex-MVC
Class should do one thing and do it well
# OCP
Open for extensibilty and closed for modification.
Essentialy it says once class is deployed to prod we are no longer allowed to change the class because it is used by various clients.Changing the behaviour can impact the client.
Anyone should be able to redefine the behaviour of the class by extending it. It can done by inheritance and object composition.
Favour composition over inheritance.
Ex-Strategy pattern

# LSP
# ISP
# DIP
