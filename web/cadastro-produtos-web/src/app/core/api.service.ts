import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Product} from "../model/product.model";
import {Observable, of} from "rxjs/index";
import {ApiResponse} from "../model/api.response";
import { catchError } from 'rxjs/operators';

@Injectable()
export class ApiService {
  baseUrl: string = 'http://localhost:8080/products/';

  constructor(private http: HttpClient) { }

  login(loginPayload) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>('http://localhost:8080/'+ 'token/generate-token', loginPayload)
    .pipe(
      catchError(val => of(val)));
      };

  getProducts() : Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseUrl);
  }

  getProductById(id: number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseUrl + id);
  }

  createProduct(product: Product): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl, product);
  }

  updateProduct(product: Product): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(this.baseUrl + product.id, product);
  }

  deleteProduct(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(this.baseUrl + id);
  }
}
