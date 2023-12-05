import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { IPagedResult } from '../_shared/interfaces/ipaged-result';
import { IProduct } from '../_shared/interfaces/iproduct';


@Injectable({
  providedIn: 'root'
})
export class ShopService  {
  baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(){
    return this.http.get<IPagedResult<IProduct>>(this.baseUrl + 'products' + '?PageNumber=1&pageSize=12');
  }
}
