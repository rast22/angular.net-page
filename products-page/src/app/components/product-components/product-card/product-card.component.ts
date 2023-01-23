import {Component, Input, OnInit} from '@angular/core';
import {ProductModel} from "../../../Models/Product-models";
import {DomSanitizer} from "@angular/platform-browser";
import {CurrencyPipe} from "@angular/common";

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {
  @Input() product!: ProductModel;
  image!:string
  constructor(
    private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.image = this.sanitizer.bypassSecurityTrustUrl(this.product?.product_image) as string;
  }

}
