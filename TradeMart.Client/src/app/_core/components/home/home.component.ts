import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../home.service';
import { IBrand } from '../../../_shared/interfaces/ibrand';
import { ICategory } from '../../../_shared/interfaces/icategory';
import { IProduct } from '../../../_shared/interfaces/iproduct';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  brands!: IBrand[];
  categories!: ICategory[];
  products!: IProduct[];

  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getBrands();
    this.getProducts();
  }

  getCategories(){
    this.homeService.getCategories().subscribe({
      next: response => this.categories = response,
      error: error => alert(error),
    });
  }

  getBrands(){
    this.homeService.getBrands().subscribe({
      next: response => this.brands = response,
      error: error => alert(error),
    });
  }

  getProducts(){
    this.homeService.getLatestProducts().subscribe({
      next: response => this.products = response.data,
      error: error => alert(error),
    });
  }

  getProductsByCategory(id:string){

  }

  getProductsByBrand(id:string){

  }
}
