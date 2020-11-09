# SalesTaxProblem

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

# ReadMe in the solution
The Console program itself was written to meet the bare requirements since a real application that uses
these classes would not be a console program.  No Input mechanism, No UI, and no data store and not tests
of the static methods in Program (hence no 100% coverage).  
I would consider The program and the SalesTransaction to be class integration test tools for the models and 
services that would be replaced by a real UI.
All the models and services are unit tested.   

Assumptions:
1) Rounding is to be done once for each line of the receipt.   This is consistent with examples.  The actual
problem description has a formula but the formula does not consider the quantity.  I assume the actual
formula is:
            ((qty * np/100) rounded up to the nearest 0.05)

If given the opportunity I would discuss this with the stake holder(s) because there is significant risk
that by rounding up on every line item the user will be charged much more tax than is reasonable.

2) There are no negative quantities allowed.  This is not an unreasonable requirement but for this
problem I made this assumption and thow an ArgumentException if any code tries to assign a negative value..

If given the opportunity I would discuss this with the stake holder(s) to confirm this assumption is valid.

3) The last digit of Input 3 line 1 is to be ignored.
      •	1 imported bottle of perfume at 27.99 1

4) The Product type (Food, Medical, Book) is a characteristic of the product definition wherever it is stored.  
It is also subject to change (e.g. a government may decide that Books can now be taxed, but
a book is still of Product type Book.   The Input text string does not provide this information, so I assume
it is stored with the product (and have a property for it.)  

If given the opportunity I would discuss this with the stake holder(s) I would ask where this information
is expected to reside.

5) Since the program does not have to have and input mechanism and because of 4) above, there was
not a need to write a parser input strings. 
