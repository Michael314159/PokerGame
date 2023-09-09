
To pregram is to transform

Transforming may require intermediate steps. Functions.

	Func<int,int> f = x => x + 1; // describing f(x) = x + 1
	Func<int,int> g = x => x + 2; // describing g(x) = x + 2

	function z (z(x,y) = x == y )
	can be represented as Func<int,int,bool> because it takes two integers and returns a Boolean value.


	1111111111

	Generator Functions

A generator function creates values out of nothing. Think of this as a method that takes no arguments but returns an IEnumerable<T>.

Enumerable.Range() and Enumerable.Repeat() are example of generator functions.

A generator function can be represented by the following equation, where T represents any type:

() => T[]

	222222222222222

Statistical Functions

Statistical functions return some kind of statistic about a collection. For example, you might want to know how many elements are 
present in a collection, or whether a given element is available in a collection. 
These types of operations are statistical in nature because they return either a number or a Boolean value.

Any(), Count(), Single(), and SingleOrDefault() are examples of statistical functions. A statistical function can be represented by either of the following equations:

T[] => Number
T[] => Boolean

3333333333333333333

Projector Functions

Functions that take a collection of type T and return a collection of type U (where U could be the same type as T)
are called projector functions.

Select(), SelectMany(), and Cast<T>() are other examples of projector functions. A projector function can be represented by the following equation, where U can be the same as T:

T[] => U[]


444444444444444444444444

Filters

Filters are just what you would think they are. These functions filter out elements of a given collection that don’t match a given expression.

Where(), First(), and Last() are examples of filter functions. A filter function can be represented by either of the following equations:

T[] => T[]: The function output is a list of values that match a given condition.
T[] => T: The function output is a single value that matches a given condition/predicate.



Series generation has applications in many areas.
Although the problems in this chapter may seem disconnected,
they demonstrate how to use LINQ to solve diverse sets of problems. 
I have categorized the problems into six main areas:
math and statistics,
recursive series and patterns,
collections,
number theory, 
game design, 
and working with miscellaneous series.

*******************
*******************
*******************
*******************

Domain Specific language

creating expressive and succinct internal APIs. 
These API sets are also called internal, or embedded, domain-specific languages (DSLs).
You can later extend these to develop an external DSL that subject matter experts 
who do not necessarily have programming experience in a high-level, general-purpose programming language can use.

Armstrong numbers and other related numbers are denoted by functions that act on the digits of those numbers.
So Digits must be a word in this language.
You also want to declare all the functions that can be performed on digits as vocabulary terms,
so users (mathematicians) can glue those functions together. So functions such as
Sum, Cube, and Factorial have to be declared as vocabulary terms.
Since this is going to be a DSL for finding interesting numbers such as Armstrong numbers,
I have named it Armstrong.

In C#, you can define these vocabulary terms as extension methods. 

