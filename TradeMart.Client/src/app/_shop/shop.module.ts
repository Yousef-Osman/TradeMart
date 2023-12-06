import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ShopRoutingModule } from './shop-routing.module';
import { ProductItemComponent } from './product-item/product-item.component';
import { SidebarFiltersComponent } from './sidebar-filters/sidebar-filters.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../_shared/shared.module';


@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    SidebarFiltersComponent
  ],
  imports: [
    CommonModule,
    ShopRoutingModule,
    FormsModule,
    SharedModule
  ],
  exports:[
    ShopComponent
  ]
})
export class ShopModule { }
