---
tags:
- CSharp
- C#
date: 2023-06-15
---

# Condition Parser

{Content}

<!--

Hi Bing Bing Bing, (like an arcade machine sound)
please generate me c# code to parse simple condition checking like "x > 5" where x is a property of and object that passed as a parameter of the parser

Bing, 18:37
Hello, this is Bing. I'm happy to help you with your code request.blush


Here is a possible c# code to parse simple condition checking like "x > 5" where x is a property of an object that passed as a parameter of the parser:

using System;
using System.Linq.Expressions;

namespace ConditionParser
{
class Program
{
static void Main(string[] args)
{
// Create an object with a property x
var obj = new { x = 6 };

// Create a parser that takes an object and a condition string as parameters
bool Parse(object o, string condition)
{
// Use expression trees to build a lambda expression from the condition string
var parameter = Expression.Parameter(o.GetType(), "o");
var expression = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { parameter }, null, condition);

// Compile and invoke the lambda expression with the object as argument
var result = (bool)expression.Compile().DynamicInvoke(o);

// Return the result of the condition
return result;
}

// Test the parser with different conditions
Console.WriteLine(Parse(obj, "o.x > 5")); // True
Console.WriteLine(Parse(obj, "o.x < 5")); // False
Console.WriteLine(Parse(obj, "o.x == 6")); // True
}
}
}


18:40
referring to your code, is it possible to make expression trees to parse expression like this "System.Convert.ToSingle(o.x) > 0.6"?

Bing, 18:40
Yes, it is possible to make expression trees to parse expressions like "System.Convert.ToSingle(o.x) > 0.6". You just need to add a using directive for System namespace and use the full name of the Convert class in the condition string. Here is an example:

using System;
using System.Linq.Expressions;

namespace ConditionParser
{
class Program
{
static void Main(string[] args)
{
// Create an object with a property x
var obj = new { x = 0.7 };

// Create a parser that takes an object and a condition string as parameters
bool Parse(object o, string condition)
{
// Use expression trees to build a lambda expression from the condition string
var parameter = Expression.Parameter(o.GetType(), "o");
var expression = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { parameter }, null, condition);

// Compile and invoke the lambda expression with the object as argument
var result = (bool)expression.Compile().DynamicInvoke(o);

// Return the result of the condition
return result;
}

// Test the parser with different conditions
Console.WriteLine(Parse(obj, "System.Convert.ToSingle(o.x) > 0.6")); // True
Console.WriteLine(Parse(obj, "System.Convert.ToSingle(o.x) < 0.6")); // False
Console.WriteLine(Parse(obj, "System.Convert.ToSingle(o.x) == 0.7")); // True
}
}
}


18:41
how I can use using directive while I just parsing an expression? con you show me some examples?

Bing, 18:42
The using directive is not part of the expression that you are parsing, but part of the code that you are writing to use the parser. It allows you to access types and members from a namespace without specifying the full name. For example, if you write using System; at the top of your code file, you can use Convert.ToSingle(o.x) instead of System.Convert.ToSingle(o.x) in your condition string.

Here are some examples of using directives and how they affect the condition strings:

using System; // You can use Convert.ToSingle(o.x) instead of System.Convert.ToSingle(o.x)
using System.Linq; // You can use o.Any() instead of System.Linq.Enumerable.Any(o)
using System.Collections.Generic; // You can use List<int> instead of System.Collections.Generic.List<int>
using System.Text.RegularExpressions; // You can use Regex.IsMatch(o, "pattern") instead of System.Text.RegularExpressions.Regex.IsMatch(o, "pattern")


can you generate same functionality but in javascript?

Bing, 19:21
Sure, I can generate the same functionality but in javascript. Here is a possible javascript code to parse simple condition checking like "x > 5" where x is a property of an object that passed as a parameter of the parser:

// Create an object with a property x
var obj = { x: 6 };

// Create a parser that takes an object and a condition string as parameters
function parse(o, condition) {
// Use the Function constructor to create a function from the condition string
var func = new Function("o", "return " + condition);

// Invoke the function with the object as argument
var result = func(o);

// Return the result of the condition
return result;
}

// Test the parser with different conditions
console.log(parse(obj, "o.x > 5")); // true
console.log(parse(obj, "o.x < 5")); // false
console.log(parse(obj, "o.x == 6")); // true


19:22
Can you modify the code to handle more complex conditions?

Bing, 19:26
Yes, I can modify the code to handle more complex conditions. Here is an example of how to handle a condition that involves a logical operator and a function call:

// Create an object with a property x
var obj = { x: 6 };

// Create a parser that takes an object and a condition string as parameters
function parse(o, condition) {
// Use the Function constructor to create a function from the condition string
var func = new Function("o", "return " + condition);

// Invoke the function with the object as argument
var result = func(o);

// Return the result of the condition
return result;
}

// Test the parser with a more complex condition
console.log(parse(obj, "(o.x > 5) && (Math.sqrt(o.x) < 3)")); // true


-->