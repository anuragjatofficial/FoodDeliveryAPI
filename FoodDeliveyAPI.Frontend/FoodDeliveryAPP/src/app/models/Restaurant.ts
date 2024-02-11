import { Item } from "./Item";

export interface Restaurant {
    restaurantId: string,
    restaurantName: string,
    address: string,
    isClosed: boolean,
    items: Item[]
}