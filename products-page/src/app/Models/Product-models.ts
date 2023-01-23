interface IProductModel {
  product_id: number;
  product_name: string;
  product_description: string;
  product_price: number;
  product_image: string;
  type_id: number;
}

interface IProductTypeModel {
  type_id: number;
  type_name: string;
}


type ProductModel = IProductModel & {
  product_type: IProductTypeModel|undefined;
}

export { IProductModel, ProductModel, IProductTypeModel };
