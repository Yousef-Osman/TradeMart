import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './_core/components/not-found/not-found.component';
import { HomeComponent } from './_core/components/home/home.component';

const routes: Routes = [
  { path: 'shop', loadChildren: () => import('./_shop/shop.module').then(mod => mod.ShopModule) },
  { path: 'cart', loadChildren: () => import('./_shopping-cart/shopping-cart.module').then(mod => mod.ShoppingCartModule) },
  { path: '', component: HomeComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
