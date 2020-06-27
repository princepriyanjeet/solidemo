# solidemo
Encapsulation is implementation hiding and protection of invariants.
Impementation hiding- Lets say we have user and pwd expose as property, when we try to change password, we may have collection of previous password.
And if the user changes the password which is equal to previously stored paswword we make the request invalid. So we are hiding the implementaion.

Protection of invariants- Its difficult to put the object in a invalid state and to achieve this we have pre and post condition validation.
which is known as assertion.

A precondition is the state of the system and its surroundings that is required before the use case can be started. 
A postcondition is the states the system can be in after the use case has ended. Consider the following: 
The states described by pre- or postconditions should be states that the user can observe.

CQS(Comand query separation principle)-> Each operation must be either command or query.
Command - That has observable side effects. Saving, deleting file or record in database.It mutates the state.Cnan invoke queries.
Query- Just an operation that returns data with no side effects.These are idempotent.Safe to invoke. Asikng the same question again and agin does not
change the answer.

Postel law- You should be very conservative in what you send(strictly adhere to contracts constituited with client). 
And liberal in what you accept.(If you understand what client has send, if dont understand what client has send, lets say input is garbled, tell the client right away which is fail fast)
How can you trust that a command accept input?
How can you trust a query returns a successful result?

Solid is a reaction to set of design smells.

Rigidity- The design is difficult to change
Fragility- Design is easy to break
Immobilty-Design is difficult ot reuse.
Viscocity-Its difficult to do the right thing.
Needless complexity-overdesign

SRP- Class should have single responsibility.
How do we define responsibility- A class should have only one reason to change. Our concern is Separation of concern. Whatever might be those concern might be,
we want to vary those concern independently.
Each class should do one thing and do it well. Ex-MVC
