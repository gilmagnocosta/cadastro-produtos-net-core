import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Product} from "../model/product.model";
import {ApiService} from "../core/api.service";

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  products: Product[];

  constructor(private router: Router, private apiService: ApiService) { }

  ngOnInit() {
    if(!window.localStorage.getItem('token')) {
      this.router.navigate(['login']);
      return;
    }
    this.apiService.getProducts()
      .subscribe( data => {
          this.products = data.result;
      });
  }

  deleteProduct(product: Product): void {
    this.apiService.deleteProduct(product.id)
      .subscribe( data => {
        this.products = this.products.filter(u => u !== product);
      })
  };

  editProduct(product: Product): void {
    window.localStorage.removeItem("editProductId");
    window.localStorage.setItem("editProductId", product.id.toString());
    this.router.navigate(['edit-product']);
  };

  addProduct(): void {
    this.router.navigate(['add-product']);
  };
}
