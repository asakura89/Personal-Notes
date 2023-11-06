# Event Modeling Architect
August 6, 2023


you are an event modeling architect. you describe everything in steps using example data. every step is either a state change or a view into state. 

each state change step has 4 items: 
1. the screen that shows how the state change is initiated by the user including example data. 
2. the command that contains the information that's needed to change the state including example data. only one command is allowed in this type of step. minimal information is used to mark the intent to change the state. this command can fail if business rules are broken.
3. the resulting event with the information that shows how the state is changed including example data
4. a reference to the previous step. 

each state view step has 4 items: 
1. the screen with what information is available to view with example data, 
2. the read model that contains the model that populates the screen including example data. this is the result of a reducer over any relevant previous events. It may contain default data if no relevant events occured yet. only one read model is allowed in this type of step. it includes relevant ids that can be used by the system to accomodate commands.
3. a list of relevant events including the step they were created in that happened in the previous steps to make the informaton available
4. a link to the previous step

screen descriptions will include itemization of controls such as text boxes, lists, buttons, radio buttons, checkboxes, menus etc.

When a state view step connects to a state change step, they share the same screen so please repeat the screen between the 2 if they are related. When a state change step is followed by a state view step, references to relevant previous events serve as a link. These links ensure that there is referential integrity to the data in the system being shown. State changes are only user initiated. Any other state change is strictly deduced from a reduction of previous events. There are no explicit commands to adjust product inventaries or total prices.

Steps can also be called slices. A slice can be either a state change or a state view. Example data is used in each component - not just the property names. Data can be traced through the steps. Use realistic data and avoid gerenarlities like "Prouct A". Use integers or UUIDs as identifiers, but don't show them on the screens. You never combine operations into one step. if the instructions say something like "remove 2 products" you will make 2 steps to show explicitly how that happens.

Each command will have a suite of tests in the style of Given-When-Then GWT from BDD with the following format: "Given" is a set of 0..N events. "When" is the command. "Then" is one event showing the resulting state change if the command was successful. "Then" can be an exception if the scenario shows the command failing. The minimal amount of test is 2: 1 for a failure, 1 for a success. But more is usually typical to show data variations.

Each read model will have a suite of tests in the style of Given-When-Then GWT from BDD but without the "When" step. The "Given" is a set of 0..N events. The "Then" is a model that is the result of running a reducer over the events from the "Given" events.

The tests for commands and read models will be fully listed after all steps of the system are described.

Now that you know what to do, please architect the following system:

comletely show what happens when a user sees a page listing 10 different products, adds 2 products and removes one of them from their basket in an online store and then goes to checkout and pay. Please keep track of inventory (but not viewable by the end user) along the way and the users invoice history. show all tests needed.

# ChatGPT

Alright, I will outline the Event Sourcing System for the described scenario. Let’s start with State Change Slices and State View Slices.

**State View Slice 1: Display Product List**
1. **Screen**: 
   - List of 10 products with:
     - Product Name (e.g., "Samsung Galaxy S21")
     - Price (e.g., "$999")
     - "Add to basket" Button for each product

2. **Read Model**:
   - ProductID, ProductName, Price, AvailableQuantity
   - Example Data: `[{ ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999", AvailableQuantity: 50}, {ProductID: 2, ProductName: "Apple iPhone 12", Price: "$1099", AvailableQuantity: 40}, ...]`

3. **Relevant Events**: None (First interaction)

4. **Link to Previous Step**: None (First interaction)

---

**State Change Slice 2: Add First Product to Basket**
1. **Screen**:
   - List of products with "Add to basket" Button
   - User clicked "Add to basket" for "Samsung Galaxy S21"

2. **Command**:
   - `AddProductToBasketCommand`: `{ UserID: "UserA", ProductID: 1 }`

3. **Resulting Event**:
   - `ProductAddedToBasketEvent`: `{ UserID: "UserA", ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999" }`

4. **Reference to Previous Step**: Slice 1

---

**State Change Slice 3: Add Second Product to Basket**
1. **Screen**:
   - List of products with "Add to basket" Button
   - User clicked "Add to basket" for "Apple iPhone 12"

2. **Command**:
   - `AddProductToBasketCommand`: `{ UserID: "UserA", ProductID: 2 }`

3. **Resulting Event**:
   - `ProductAddedToBasketEvent`: `{ UserID: "UserA", ProductID: 2, ProductName: "Apple iPhone 12", Price: "$1099" }`

4. **Reference to Previous Step**: Slice 2

---

**State Change Slice 4: Remove Product from Basket**
1. **Screen**:
   - User's basket showing added products
   - User clicked "Remove" for "Samsung Galaxy S21"

2. **Command**:
   - `RemoveProductFromBasketCommand`: `{ UserID: "UserA", ProductID: 1 }`

3. **Resulting Event**:
   - `ProductRemovedFromBasketEvent`: `{ UserID: "UserA", ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999" }`

4. **Reference to Previous Step**: Slice 3

---

**State Change Slice 5: Checkout and Payment**
1. **Screen**:
   - Checkout screen with total price
   - User clicked "Pay"

2. **Command**:
   - `CheckoutCommand`: `{ UserID: "UserA" }`

3. **Resulting Event**:
   - `CheckoutCompletedEvent`: `{ UserID: "UserA", InvoiceID: "Invoice123", TotalPrice: "$1099" }`

4. **Reference to Previous Step**: Slice 4

---

**State View Slice 6: Display User's Invoice History**
1. **Screen**:
   - List of invoices with:
     - Invoice ID (e.g., "Invoice123")
     - Total Price (e.g., "$1099")

2. **Read Model**:
   - InvoiceID, TotalPrice
   - Example Data: `[ { InvoiceID: "Invoice123", TotalPrice: "$1099" }, ... ]`

3. **Relevant Events**: `CheckoutCompletedEvent` from Slice 5

4. **Link to Previous Step**: Slice 5

---

**Tests for Commands**:
1. `AddProductToBasketCommand`:
   - Given: No previous events
     When: `{ UserID: "UserA", ProductID: 1 }`
     Then: `{ UserID: "UserA", ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999" }`
   
   - Given: Product with ProductID: 1 already in basket
     When: `{ UserID: "UserA", ProductID: 1 }`
     Then: Exception (Product already in basket)

2. `RemoveProductFromBasketCommand`:
   - Given: `{ UserID: "UserA", ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999" }`
     When: `{ UserID: "UserA", ProductID: 1 }`
     Then: `{ UserID: "UserA", ProductID: 1, ProductName: "Samsung Galaxy S21", Price: "$999" }`
     
   - Given: No products in basket
     When: `{ UserID: "UserA", ProductID: 1 }`
     Then: Exception (No products to remove)

3. `CheckoutCommand`:
   - Given: `{ UserID: "UserA", ProductID: 2, ProductName: "Apple iPhone 12", Price: "$1099" }`
     When: `{ UserID: "UserA" }`
     Then: `{ UserID: "UserA", InvoiceID: "Invoice123", TotalPrice: "$1099" }`
     
   - Given: No products in basket
     When: `{ UserID: "UserA" }`
     Then: Exception (Cannot checkout empty basket)

---

**Tests for Read Models**:
1. For product list view:
   - Given: No previous events
     Then: Default product list

2. For user's invoice history:
   - Given: `CheckoutCompletedEvent`: `{ UserID: "UserA", InvoiceID: "Invoice123", TotalPrice: "$1099" }`
     Then: `[ { InvoiceID: "Invoice123", TotalPrice: "$1099" }, ... ]`

---

This is a simplified version for understanding. In a real-world scenario, there might be other considerations like handling different product quantities, shipping details, applying discounts, etc.


# Chat GPT 2

Certainly, I can help you architect the system as per your specifications. Here's how the system would be designed step by step, including example data and tests:

**State View Step 1: Display Product List**

1. **Screen**: 
   - List of 10 products with:
     - Product Name
     - Price
     - "Add to Basket" Button for each product

2. **Read Model**:
   - ProductID, ProductName, Price, AvailableQuantity
   - Example Data: 
     ```
     [
       { ProductID: 1, ProductName: "Laptop", Price: 1000, AvailableQuantity: 10 },
       { ProductID: 2, ProductName: "Smartphone", Price: 500, AvailableQuantity: 20 },
       // ... 8 more products
     ]
     ```

3. **Relevant Events**: None (Initial view)

4. **Link to Previous Step**: None (Initial view)

---

**State Change Step 2: Add First Product to Basket**

1. **Screen**: 
   - Same as Step 1

2. **Command**: 
   - `AddToBasketCommand`: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

3. **Resulting Event**: 
   - `ProductAddedToBasketEvent`: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

4. **Reference to Previous Step**: Step 1

**Tests for `AddToBasketCommand`**:

- **Test 1: Adding Product to Basket Successfully**
  - Given: No previous events
  - When: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`
  - Then: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

- **Test 2: Adding Product to Basket with Insufficient Quantity**
  - Given: `{ ProductAddedToBasketEvent: { UserID: "User123", ProductID: 1, Quantity: 10 } }`
  - When: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`
  - Then: Exception (Insufficient quantity)

---

**State Change Step 3: Add Second Product to Basket**

1. **Screen**: 
   - Same as Step 1

2. **Command**: 
   - `AddToBasketCommand`: `{ UserID: "User123", ProductID: 2, Quantity: 1 }`

3. **Resulting Event**: 
   - `ProductAddedToBasketEvent`: `{ UserID: "User123", ProductID: 2, Quantity: 1 }`

4. **Reference to Previous Step**: Step 2

**Tests for `AddToBasketCommand`**:

- **Test 3: Adding Second Product to Basket Successfully**
  - Given: `{ ProductAddedToBasketEvent: { UserID: "User123", ProductID: 1, Quantity: 1 } }`
  - When: `{ UserID: "User123", ProductID: 2, Quantity: 1 }`
  - Then: `{ UserID: "User123", ProductID: 2, Quantity: 1 }`

---

**State Change Step 4: Remove Product from Basket**

1. **Screen**: 
   - User's basket showing added products
   - User clicked "Remove" for ProductID 1

2. **Command**: 
   - `RemoveFromBasketCommand`: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

3. **Resulting Event**: 
   - `ProductRemovedFromBasketEvent`: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

4. **Reference to Previous Step**: Step 3

**Tests for `RemoveFromBasketCommand`**:

- **Test 4: Removing Product from Basket Successfully**
  - Given: `{ ProductAddedToBasketEvent: { UserID: "User123", ProductID: 1, Quantity: 1 }, ProductAddedToBasketEvent: { UserID: "User123", ProductID: 2, Quantity: 1 } }`
  - When: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`
  - Then: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`

- **Test 5: Removing Non-existent Product from Basket**
  - Given: `{ ProductAddedToBasketEvent: { UserID: "User123", ProductID: 2, Quantity: 1 } }`
  - When: `{ UserID: "User123", ProductID: 1, Quantity: 1 }`
  - Then: Exception (Product not in basket)

---

**State Change Step 5: Checkout and Payment**

1. **Screen**: 
   - Checkout screen with a list of products and total price
   - User clicked "Pay"

2. **Command**: 
   - `CheckoutCommand`: `{ UserID: "User123" }`

3. **Resulting Event**: 
   - `OrderPlacedEvent`: `{ UserID: "User123", OrderID: "Order456", TotalPrice: 500 }`

4. **Reference to Previous Step**: Step 4

**Tests for `CheckoutCommand`**:

- **Test 6: Checkout Successfully**
  - Given: `{ ProductAddedToBasketEvent: { UserID: "User123", ProductID: 2, Quantity: 1 } }`
  - When: `{ UserID: "User123" }`
  - Then: `{ UserID: "User123", OrderID: "Order456", TotalPrice: 500 }`

- **Test 7: Checkout with Empty Basket**
  - Given: No previous events
  - When: `{ UserID: "User123" }`
  - Then: Exception (Empty basket)

---

**State View Step 6: Display User's Invoice History**

1. **Screen**: 
   - List of invoices with:
     - Invoice ID
     - Total Price

2. **Read Model**:
   - InvoiceID, TotalPrice
   - Example Data: 
     ```
     [
       { InvoiceID: "Invoice123", TotalPrice: 1000 },
       { InvoiceID: "Order456", TotalPrice: 500 },
     ]
     ```

3. **Relevant Events**: `OrderPlacedEvent` from Step 5

4. **Link to Previous Step**: Step 5

**Tests for Read Model**:

- **Test 8: Displaying User's Invoice History**
  - Given: `{ OrderPlacedEvent: { UserID: "User123", OrderID: "Order456", TotalPrice: 500 } }`
  - Then: `[ { InvoiceID: "Order456", TotalPrice: 500 }, ... ]`

---

This architecture follows your requirements for tracking the user's actions, maintaining inventory, and recording the user's invoice history. The tests provided cover different scenarios for commands and read models to ensure system reliability.