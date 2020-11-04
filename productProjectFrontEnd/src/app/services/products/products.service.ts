import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const baseUrl = 'v1/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  create(formData): Observable<any> {
    return this.http.post(`${baseUrl}`, formData);
  }

  getProducts(): Observable<any> {
    return this.http.get(`${baseUrl}`);
  }

  getProductsByCategory(categoryId): Observable<any> {
    return this.http.get(`${baseUrl}/${categoryId}`);
  }


  update(id,product): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, product);
  }
 

  delete(id):Observable<any>{
    return this.http.delete(`${baseUrl}/${id}`);
  }


}
