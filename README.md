BooleanActivities
========
## Introduction
A collection of small quality of life improvements for UiPath / Windows Workflow Foundation. 
Most of them make interactions with Activity\<bool\>, i.e. boolean-valued activities, easier. 
For example, *ActivityIf* allows you to test an Activity\<bool\> in a condition instead of an 
expression like in the regular *If* activity.

Contains the following activities:
* **ActivityIf**: Use a boolean activity as a condition instead of an expression
* **ActivityWhile**/**ActivityDoWhile**: Use a boolean activity as the loop condition instead of 
an expression
* **ActivityAnd**: Check multiple boolean activities *in parallel*. Returns true if and only if 
all children return true. Will cancel execution of all children as soon as one of them is false.
* **ActivityOr**: Check multiple boolean activities *in parallel*. Returns true if any child 
returns true. Will cancel execution of all children as soon as any of them is true.
* **ActivityNot**: Negation of *ActivityAnd* - usually used with a single child, returns false if 
the child is true and vice-versa
* **ActivityXOr**: Check two boolean activities *in parallel*. Return true if and only if one of 
them is true and the other is false.
* **ActivityTrue**/**ActivityFalse**: Constant True/False values for debugging
* **VBExpression\<T\>**: Evaluate an expression and return the result. In the context of this package,
used typically as *VBExpression\<bool\>* to compose with other boolean activities
* **ActivityEquals\<T\>**: Check if two valued activities are equal. In the context of this package,
typically used to compare two *VBExpression\<T\>*.

## Installation
1. Acquire the nupkg (e.g. from UiPath Go!)
2. Use UiPath package manager to add it as a dependency. Please see the UiPath documentation for more details.

Alternatively, use directly from Visual Studio for use in Workflow Foundation

## Usage
Simply drag and drop the desired activities onto the canvas. The main use in UiPath is together with 
activities such as *ElementExists* - e.g. a "while element exists" loop.

One important point to keep in mind is that the container activities (*ActivityAnd*, *ActivityOr* and *ActivityNot*)
execute all child activities in parallel and cancel the other children as soon as possible. This is the same
behaviour as you may be used to from the *Pick* activity. 
For example, say you want to check for the existence of one of two elements on a website, **Foo** and **Bar**. 
If either exists, you want to show an alert "Element found". If both aren't found, you want to display 
an alert "No element found" after 3 seconds. 

To build this in UiPath, drag an *ActivityIf* onto the canvas, add an *ActivityOr* container and put two 
*ElementExists* activities with a timeout of 3000 ms inside the *ActivityOr* - one checking for **Foo** and the 
other for **Bar**. 

Imagine that you visit a website that contains only **Foo**. When UiPath finds **Foo**, *ActivityOr* will immediately cancel 
the *ElementExists* that looks for **Bar**, so *ActivityIf* will execute quickly without having to wait for the 
unsuccessful search for **Bar** to finish. This is effectively the same as using a *Pick* with multiple branches
to set a boolean flag that you subsequently use in an *If* activity.
