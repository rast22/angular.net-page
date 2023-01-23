import { Component, OnInit } from '@angular/core';
import {IProductModel, IProductTypeModel, ProductModel} from "../../Models/Product-models";
import {ProductService} from "./product.service";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {
  products!: ProductModel[];
  isLoad: boolean = false;


  constructor(
    private productService: ProductService
  )  {}

  ngOnInit(){
    this.isLoad = true;
      this.productService.getTypes().subscribe({
        next: (types:IProductTypeModel[]) => {
          this.productService.getProducts().subscribe({
            next: (products:IProductModel[]) => {
              this.products = products.map((product:IProductModel) => {
                return {
                  ...product,
                  product_type: types.find((type:IProductTypeModel) => type.type_id === product.type_id)
                }
              })
              this.isLoad = false;
            }
          })
        }
      });
  }

}
