import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_home/home.component';

const routes: Routes = [
  { path: 'shop', loadChildren: () => import('./_shop/shop.module').then(mod => mod.ShopModule) },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
