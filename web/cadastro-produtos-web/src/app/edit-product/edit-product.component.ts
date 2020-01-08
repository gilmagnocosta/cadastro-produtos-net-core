import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Product} from "../model/product.model";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";
import {ApiService} from "../core/api.service";

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  product: Product;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: ApiService) { }

  ngOnInit() {
    let productId = window.localStorage.getItem("editProductId");
    if(!productId) {
      alert("Invalid action.")
      this.router.navigate(['list-product']);
      return;
    }
    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      value: ['', Validators.required]
    });
    this.apiService.getProductById(+productId)
      .subscribe( data => {
        this.editForm.setValue(data.result);
      });
  }

  onSubmit() {
    this.apiService.updateProduct(this.editForm.value)
      .pipe(first())
      .subscribe(
        data => {
          if(data.status === 200) {
            alert('Produto atualizado com sucesso');
            this.router.navigate(['list-product']);
          }else {
            alert(data.message);
          }
        },
        error => {
          alert(error);
        });
  }

}
