import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ShopRoutingModule } from './shop-routing.module';
import { ProductItemComponent } from './product-item/product-item.component';
import { SidebarFiltersComponent } from './sidebar-filters/sidebar-filters.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    SidebarFiltersComponent
  ],
  imports: [
    CommonModule,
    ShopRoutingModule,
    FormsModule
  ],
  exports:[
    ShopComponent
  ]
})
export class ShopModule { }
