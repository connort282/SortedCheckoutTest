Brief:
A supermarket requires a working checkout. MVP is to scan products and periodically ask for a total price, considering any special offers that apply to the product.

Checklist to follow:
Create a new solution
	Include a class library for the logic | Added
	Include a test library for unit tests (feel free to use whatever test library you are most comfortable with) | Added
Prove you can scan an item at a checkout | done
	Adding my own points:
		Need a class to hold the item information | Item.cs
		Need a class that can validate and return information about an item | IItemLookup and the concrete ItemLookup
		State is going to be handled in memory by just maintaining an object
		Need a class that performs the actual logic | Checkout.cs
Prove you can request the total price | done
Introduce special offers
	Amend your prior implementation to consider offers on items
Prove you can request the total price inclusive of offers


Thoughts:
In the test document it specifically says "This kata covers just the middleware, do not be concerned with UI or data access." Which is the reason I've chose a console application.
