import { createId } from "@paralleldrive/cuid2";
import { ICartItem, IShoppingCart } from "../interfaces/ishopping-cart";

export class ShoppingCart implements IShoppingCart {
    id: string = createId();
    items: ICartItem[] = [];
  }