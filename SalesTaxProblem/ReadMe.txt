Problem: Sales Taxes 
Based on the Preamble and Evaluation Guidelines, This application is representative of my coding style.   

The Console program itself was written to meet the bare requirements since a real application that uses
these classes would not be a console program.  No Input mechanism, No UI, and no data store.  I would consider
The program and the SalesTransaction to be class integration test tools for the models and services that would be
replaced by a real UI.

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
