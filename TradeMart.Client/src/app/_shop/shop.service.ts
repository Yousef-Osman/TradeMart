import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { IPagedResult } from '../_shared/interfaces/ipaged-result';
import { IProduct } from '../_shared/interfaces/iproduct';
import { ProductParams } from '../_shared/models/product_params';
import { ICategory } from '../_shared/interfaces/icategory';
import { IBrand } from '../_shared/interfaces/ibrand';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl: string = environment.apiUrl + 'products';

  constructor(private http: HttpClient) { }

  getProducts(productParams: ProductParams) {
    let params = this.setHttpParams(productParams);
    return this.http.get<IPagedResult<IProduct>>(this.baseUrl, { params: params });
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + '/categories/names');
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + '/brands/names');
  }

  setHttpParams(productParams: ProductParams) {
    let params = new HttpParams();
    params = params.append('pageNumber', productParams.pageNumber);
    params = params.append('pageSize', productParams.pageSize);

    if (this.isNotNullOrWhitespace(productParams.searchValue))
      params = params.append('searchValue', productParams.searchValue);

    if (this.isNotNullOrWhitespace(productParams.orderBy))
      params = params.append('orderBy', productParams.orderBy);

    if (this.isNotNullOrWhitespace(productParams.category))
      params = params.append('categoryId', productParams.category);

    if (productParams.brands.length > 0)
      productParams.brands.forEach(brand => params = params.append('brands', brand));

    return params;
  }

  isNotNullOrWhitespace(input: string) {
    return input && input.trim();
  }
}
