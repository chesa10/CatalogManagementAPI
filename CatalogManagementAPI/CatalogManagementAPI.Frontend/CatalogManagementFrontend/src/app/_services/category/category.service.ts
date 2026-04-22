import { Injectable } from '@angular/core';
import {HttpClient, HttpParams } from '@angular/common/http'
import { map, Observable, of } from 'rxjs';
import { config } from 'src/app/Config/Config';
import { categoryDropDown } from 'src/app/_modes/category/categoryDropDownModel';
import { environment } from 'src/app/Environments/environment';

const endpoints = config.endpoints;
@Injectable({
  providedIn: 'root'
})
export class CategoryService {
    productCache = new Map();
    constructor(private http: HttpClient) { }

    GetAllCategories() : Observable<categoryDropDown[] | []> {
        return this.http.get<any>(environment.API_BASE + endpoints.GET_ALL_Categories).pipe(
            map(res => {
              return res;
            })            
        )
    }
  
}
