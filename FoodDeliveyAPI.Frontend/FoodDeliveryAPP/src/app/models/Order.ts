import { Customer } from './Customer';
import { DeliveryPerson } from './DeliveryPerson';
import { Item } from './Item';
import { Restaurant } from './Restaurant';

export interface Order {
  orderId: string;
  customer: Customer;
  deliveryPerson: DeliveryPerson;
  restaurant: Restaurant;
  orderStatus:
    | 'RECEIVED'
    | 'PLACED'
    | 'ASSIGNED'
    | 'PREPARED'
    | 'PICKEDUP'
    | 'REACHED'
    | 'DELIVERED'
    | 'CANCELLED';
  items: Item[];
  validStatuses: ['PLACED', 'CANCELLED'];
}
