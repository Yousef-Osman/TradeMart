import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from '../_shared/interfaces/icategory';
import { IBrand } from '../_shared/interfaces/ibrand';
import { IPagedResult } from '../_shared/interfaces/ipaged-result';
import { IProduct } from '../_shared/interfaces/iproduct';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  baseUrl: string = environment.apiUrl + 'products';
  
  constructor(private http:HttpClient) { }

  getLatestProducts() {
    return this.http.get<IPagedResult<IProduct>>(this.baseUrl + '?PageNumber=1&PageSize=16');
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + '/categories');
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + '/brands');
  }
}
