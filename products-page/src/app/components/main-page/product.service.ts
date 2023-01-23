import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Injectable} from "@angular/core";
import {IProductModel, IProductTypeModel} from "../../Models/Product-models";

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  apiBaseUrl: string;
  constructor(private http: HttpClient) {
    this.apiBaseUrl = environment.apiBaseUrl;
  }

  getProducts() {
    return this.http.get<IProductModel[]>(`${this.apiBaseUrl}/products/getproducts`);
  }

  getProduct(id: number) {
    return this.http.get<IProductModel>(`${this.apiBaseUrl}/products/getproduct?product_id=${id}`);
  }

  getTypes() {
    return this.http.get<IProductTypeModel[]>(`${this.apiBaseUrl}/products/gettypes`);
  }

  getType(id: number) {
    return this.http.get<IProductTypeModel>(`${this.apiBaseUrl}/products/gettype?type_id=${id}`);
  }

}
