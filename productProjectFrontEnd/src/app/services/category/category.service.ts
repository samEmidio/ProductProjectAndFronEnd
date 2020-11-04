import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const baseUrl = 'v1/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  create(category): Observable<any> {
    return this.http.post(`${baseUrl}`, category);
  }

  getCategories(): Observable<any> {
    return this.http.get(`${baseUrl}`);
  }

  update(id,category): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, category);
  }
 

  delete(id):Observable<any>{
    return this.http.delete(`${baseUrl}/${id}`);
  }

}
