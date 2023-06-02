# ECommerceAPI
  
ECommerceAPI is a .NET API project that automatically selects a shipping carrier based on the weight (desi) information entered by the customer during the order placement process.

When a customer creates an order, the API calculates the shipping cost based on the weight of the order using the predefined data associated with the shipping carriers.
The calculated shipping cost and relevant data are then stored in the order table.

### Orders
The necessary parameters are filled in to add a record to the database.

1. If the order's weight falls within the MinWeight-MaxWeight range of any carrier:
a. The price values of that carrier should be retrieved and recorded as the shipping cost for the order. The carrier with the lowest cost among the identified carriers should be selected.

2. If the order's weight does not fall within the MinWeight-MaxWeight range of any carrier:
a. The data of the carrier that has the weight closest to the order's weight, from the CarrierConfigurations table, is retrieved using appropriate queries.
b. The price and +1 weight cost information of the retrieved record(s) are obtained.
c. The difference between the order's weight and the closest weight value of the carrier obtained in step A is calculated.
d. The difference value obtained in step C is multiplied by the +1 weight cost, and then added to the base shipping cost. This ensures the appropriate pricing for each additional weight unit exceeding the carrier's standard weight range.
e. The value obtained in step D is recorded in the database as the shipping cost for the order.

To better understand the logical operations involved, you can refer to the following example:

Order Weight: 13
Carrier Min-Max Weight Range: 1-10
Shipping Cost for the Relevant Weight Range: $32
+1 Weight Cost: $4
Calculated Final Shipping Cost (to be recorded in the Order table): $32 + ($4 * (13-10) ) = $44

Please note that the above explanation assumes a weight-based pricing model for the shipping costs.