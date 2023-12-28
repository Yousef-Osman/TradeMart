import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from '../../_shared/interfaces/iproduct';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {
  product!: IProduct;

  constructor(private route: ActivatedRoute, private shopService: ShopService) {

  }
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    if (id != null) {
      this.shopService.getProduct(id).subscribe({
        next: response => this.product = response,
        error: error => alert(error),
      });
    }
  }
}
