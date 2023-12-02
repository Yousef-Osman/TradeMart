import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  brands: string[] = [
    './assets/images/site/brands/lenovo.png',
    './assets/images/site/brands/dell.png',
    './assets/images/site/brands/hp.png',
    './assets/images/site/brands/toshiba.png',
    './assets/images/site/brands/asus.png',
    './assets/images/site/brands/apple.png',
    './assets/images/site/brands/fujitsu.png',
    './assets/images/site/brands/samsung.png',
    './assets/images/site/brands/acer.png',
    './assets/images/site/brands/canon.png',
    './assets/images/site/brands/sony.png',
    './assets/images/site/brands/xiaomi.png',
  ];

  categories: string[] = [
    './assets/images/site/categories/pc.png',
    './assets/images/site/categories/laptop.png',
    './assets/images/site/categories/tv.png',
    './assets/images/site/categories/phone.png',
    './assets/images/site/categories/camera.png',
    './assets/images/site/categories/tablet.png',
    './assets/images/site/categories/headphone.png',
    './assets/images/site/categories/playstration.png',
    './assets/images/site/categories/watch.png',
    './assets/images/site/categories/accessories.png',
  ];
}
