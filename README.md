# SalesTaxProblem


 CODING EXERCISE - .NET/ Java

Preamble 

What makes our team unique and great at TEKSystems is our focus on code quality. We pride ourselves in having a great team with strong engineering practices skills. This focus on strong development and engineering practices skills is why customers choose us as their partner. They don’t want us to just develop some code for them, they want us to build an enterprise quality solution that will support the growth of their business. We believe that you must start with a great foundation that is based on strong engineering practices, code quality and object-oriented design.

As you know the best way to judge an artist/a developer is to see their art/their code. We know that a written or an online technical test is not the ideal right way to evaluate a good developer so we want to give you the opportunity to show us what you can do and who you are as a developer at your own time. Therefore, we would like to give you a small challenge so we can see how you think about object-oriented design and code quality. We know you are probably very busy, and we appreciate the time you will be investing on this, but we believe this is the best way for us to get to know the great developer you are. It helps us maintain and grow our talent pool of great teammates for you to work with.

We are very excited to see what you will come up with.

Jean-Nicholas Thomas
Practice Manager – Core Development

Evaluation Guidelines 
What we are looking for 
You will be evaluated on how you reach the solution, keeping in mind that the correctness of the solution will also be taken into consideration. 
Your focus should be on these elements of code quality: 
- Code easy to read and to maintain (i.e. Clean code) 
- Object-oriented design 
- Unit testing 
- Expandable design
- SOLID principles

What you should aim to deliver 
A simple console application does the job. You do not need to implement any input mechanism, any UI nor data store. It is important to keep in mind that we are looking for code quality and attention to details, not quantity of code. 
You may use frameworks and/or tools that are in general usage for the target technology stack (for example your preferred unit testing framework). 
However, the central problem of the coding exercise should be performed entirely by your own code. 
Please note that, according to the information collected from the candidates, they usually spend between 4 to 12 hours on this coding exercise. 

If you are writing a test in .NET/ C# 
• The code must be written using Visual Studio. Visual Studio Community is available free on the Internet. 
• Once the code is written send me the source code only and not the executable or libraries (. Exe or .dll). 

Or in Java 
• The code must be written using an IDE like Eclipse or Intellij, two free IDE available on the internet. 
• Once the code is written, the source code must be submitted without its byte code; please remove any files archiving byte code (jar, war, "*.class” and the bin/target directory). 
Problem: Sales Taxes 
Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions. 
When I purchase items, I receive a receipt which lists the name of all the items and their price (including tax), finishing with the total cost of the items, and the total amounts of sales taxes paid. The rounding rules for sales tax are that for a tax rate of n%, a shelf price of p contains (np/100 rounded up to the nearest 0.05) amount of sales tax. 
Write an application that prints out the receipt details for these shopping baskets... 

INPUT: 
Input 1: 
•	1 book at 12.49 
•	1 music CD at 14.99 
•	1 chocolate bar at 0.85 
Input 2: 
•	1 imported box of chocolates at 10.00 
•	1 imported bottle of perfume at 47.50 
Input 3: 
•	1 imported bottle of perfume at 27.99 1
•	1 bottle of perfume at 18.99 
•	1 packet of headache pills at 9.75 
•	1 box of imported chocolates at 11.25 
OUTPUT 
Output 1: 
•	1 book: 12.49 
•	1 music CD: 16.49 
•	1 chocolate bar: 0.85 
•	Sales Taxes: 1.50 Total: 29.83
Output 2: 
•	1 imported box of chocolates: 10.50 
•	1 imported bottle of perfume: 54.65 
•	Sales Taxes: 7.65 Total: 65.15
Output 3: 
•	1 imported bottle of perfume: 32.19 
•	1 bottle of perfume: 20.89 
•	1 packet of headache pills: 9.75 
•	1 imported box of chocolates: 11.85 
•	Sales Taxes: 6.70 Total: 74.68
