### Interface-Oriented Programming Console Exercise in C#

#### Description:
This task aims to familiarize you with interfaces and their implementation in C#. You will create a simple console application that demonstrates the usage of interfaces and objects in a scenario involving performers.

Read first: https://www.w3schools.com/cs/cs_interface.php

#### Task Steps:

1. **Set Up Your Project:**
   - Create a new C# console application project in your preferred development environment (Visual Studio, Visual Studio Code, etc.).

2. **Define an Interface:**
   - Create an interface named `IPerformAction` with the following method signature:
     ```csharp
     interface IPerformAction
     {
         void Perform();
     }
     ```

3. **Implement Classes:**
   - Implement two classes representing different types of performers. For example:
     - `Singer` class: A performer who sings.
     - `Dancer` class: A performer who dances.
   - Ensure that each class implements the `IPerformAction` interface and provides its own implementation for the `Perform()` method.

4. **Console Interaction:**
   - Write code in your `Main` method to demonstrate the usage of interfaces and objects.
   - Create instances of each performer class and invoke their `Perform()` methods.
   - Print out messages to the console indicating the action performed by each performer.

5. **Testing and Output:**
   - Test your program with various inputs to ensure correct behavior.
   - Verify that the interface is being used appropriately to achieve polymorphic behavior.

6. **Mantadory Enhancements:**
   - Add additional types of performers or properties/methods to your classes to extend the exercise.
   - Add new interface named IPublish
     ```csharp
     interface IPublish
     {
        public List<string> Discoraphy{get;}
        public void Publish(string name);
     }
     ```
     - Singer class impelment both interfaces.
     - Publish method adds new record to _discoraphy list.
     - Test that singer object can publish new albums and you can print those to console.

8. **Review and Reflect:**
   - Once you've completed the exercise, review your code and reflect on how interfaces helped in achieving polymorphism and code reusability.

10. **Conclusion:**
    - Summarize your learning from this exercise, noting any challenges faced and insights gained regarding interface-oriented programming in C#.

#### Conclusion:
This exercise will provide you with practical experience in working with interfaces and understanding their role in achieving polymorphism and code organization. Enjoy coding and experimenting with different performers!

