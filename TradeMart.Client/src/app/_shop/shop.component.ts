import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../_shared/interfaces/iproduct';
import { IPagination } from '../_shared/interfaces/ipagination';
import { ProductParams } from '../_shared/models/product_params';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {

  products!: IProduct[];
  pagination!: IPagination;
  productParams = new ProductParams();

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts(this.productParams).subscribe({
      next: response => {
        this.products = response.data;
        this.pagination = {
          currentPage: response.currentPage,
          pageSize: response.pageSize,
          totalCount: response.totalCount,
          totalPages: response.totalPages
        };
      },
      error: error => alert(error)
    });
  }

  onParentPageChanged(newPageNumber: number) {
    this.productParams.pageNumber = newPageNumber;
    this.getProducts();
  }

  setFilters(filters: ProductParams){
    this.productParams = filters;
    this.getProducts();
  }
}
