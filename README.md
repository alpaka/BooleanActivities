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