using System;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexValidation obj = new RegexValidation();
            Console.WriteLine(obj.ValidateName());
            Console.WriteLine(obj.ValidateMobileNumber());
            Console.WriteLine(obj.ValidateEmail());
            Console.WriteLine(obj.ValidatePassword());
            Console.WriteLine("Hello World!");
        }
    }
}
/*Regex

     * B - Bracket Sign (square,curly,paranthesis) middle of regex
     [] -> specifies characters which need to be matched
     {} -> specifies how many characters
     () -> for grouping
     * C - Carrot Sign (^) start of regex
     * D - Dollar Sign ($) end of regex
1)

[abc]    -> a or b or c
[^abc]   -> any character except a,b,c
[a-z]    -> a to z
[A-Z]    -> A to Z
[0-9]    -> 0 to 9
[a-zA-Z] -> a to z,A to Z

2)

[]?     -> occurs 0 or 1 time
[]+     -> occurs 1 or more times 
[]*     -> occurs 0 or more times
\s      -> to find any whitespace
[]{n}   -> occurs n times
[]{n,}  -> occurs n or more times
[]{x,y} -> occurs minimum of x times and less than y times

3)

[0-9]  we can use [\d]
[^0-9] we can use [\D]
[a-zA-Z0-9] we can use [\w]
[^a-zA-Z0-9] we can use [\W]
[\. \* \+] for . + , \ we can use escape character(\)

5)To make it rigid use carrot and dollar symbol

Examples:
-----------
1)Enter character which exists between a-g?
    [a-g]  [^a-z] means except a to g

2)Enter characters between [a-g] with length of 3?
    ^[a-g]{3}$ 

3)Enter characters between [a-g) with maximum 3 characters and minimum 1 character?
    ^[a-g]{1,3}$

4)How can I validate data with 8 digit fix numeric format like 91230456, 01237648 etc?
    ^[0-9]{8}$

5)How to validate numeric data with minimum length of 3 and maximum of 7, ex-123, 1274667, 876547
    ^[0-9]{3,7}$

6)Validate invoice numbers which have formats like LJI12345678, the first 3 characters are alphabets and remaining is
8 length number?
    ^[a-z]{3}[0-9]{8}$

7)Check for format INV190203 or inv820830, with first 3 characters alphabets case insensitive and remaining 8 length numeric?
     ^[a-zA-Z]{3}[0-9]{8}$    

8)Can we see simple validat for website URL's?
    ^www.[a-zA-Z0-9]{1,10}.(com|org|in|edu)$

9)Can we see simple email validation ?
    skselva312000@gmail.com
    ^[a-zA-Z0-9_\.\-]+[@][a-z]+[\.][a-z]{1,4}$

 */