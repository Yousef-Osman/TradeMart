import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ICategory } from '../../_shared/interfaces/icategory';
import { IBrand } from '../../_shared/interfaces/ibrand';
import { ShopService } from '../shop.service';
import { ProductParams } from '../../_shared/models/product_params';

@Component({
  selector: 'app-sidebar-filters',
  templateUrl: './sidebar-filters.component.html',
  styleUrl: './sidebar-filters.component.scss'
})
export class SidebarFiltersComponent implements OnInit {
  categories!: ICategory[];
  brands!: IBrand[];
  filterParams = new ProductParams();
  @Output() filtersEmitter = new EventEmitter<ProductParams>();

  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getBrands();
  }

  getCategories(){
    this.shopService.getCategories().subscribe({
      next: data => this.categories = data,
      error: error => alert(error),
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe({
      next: data => this.brands = data,
      error: error => alert(error),
    });
  }

  onCategoryChange(categoryId:string){
    this.filterParams.category = categoryId;
  }

  onBrandClick(target:any){
    if(target.checked){
      this.filterParams.brands.push(target.value);
    }else{
      this.filterParams.brands = this.filterParams.brands.filter(br => br !== target.value);
    }
  }

  applyFilters(){
    this.filtersEmitter.emit(this.filterParams);
  }

  resetFilters(){
    this.filterParams = new ProductParams();
    this.applyFilters();
    this.ngOnInit(); //to reset UI for selections
  }
}
