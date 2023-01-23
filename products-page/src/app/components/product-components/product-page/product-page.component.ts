import { Component, OnInit } from '@angular/core';
import {IProductModel, ProductModel} from "../../../Models/Product-models";
import {ProductService} from "../../main-page/product.service";
import {ActivatedRoute} from "@angular/router";
import {lastValueFrom} from "rxjs";

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent implements OnInit {
  isLoad: boolean = false;
  product_id:number;
  product!:ProductModel;
  constructor(private route: ActivatedRoute,
              private productService: ProductService) {
    this.product_id = this.route.snapshot.params['id'];
    this.isLoad = true;
  }

  async ngOnInit() {
    this.productService.getProduct(this.product_id).subscribe({
      next: async (data:IProductModel) => {
        this.product = {...data, product_type: (await lastValueFrom(this.productService.getType(data.type_id)))};
        this.isLoad = false;
      },
      error: (err) => {
        console.log(err);
      }
    })

  }

}
