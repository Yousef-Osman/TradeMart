import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { BehaviorSubject } from 'rxjs';
import { IShoppingCart } from '../_shared/interfaces/ishopping-cart';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  baseUrl: string = environment.apiUrl;
  apiUrl: string = this.baseUrl + 'shoppingCart';
  private shoppingCartSource = new BehaviorSubject<IShoppingCart | null>(null);
  cart$ = this.shoppingCartSource.asObservable();

  constructor(private http: HttpClient) { }

}
