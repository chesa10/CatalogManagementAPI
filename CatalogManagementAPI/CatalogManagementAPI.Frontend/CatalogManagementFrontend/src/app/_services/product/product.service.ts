import { Injectable } from '@angular/core';
import {HttpClient, HttpParams } from '@angular/common/http'
import { map, Observable, of } from 'rxjs';
import { PaginatedResult } from 'src/app/_modes/pagination/pagination';
import { UserParams } from 'src/app/_modes/UserParams';
import { config } from 'src/app/Config/Config';
import { environment } from 'src/app/Environments/environment';
import { productModel } from 'src/app/_modes/product/productModel';


const endpoints = config.endpoints;

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  productCache = new Map();
  constructor(private http: HttpClient) { }

getScrollList<T>(userParams: UserParams, forceRefresh: boolean = true) {
      const response = this.productCache.get(Object.values(userParams).join('-'));
      if (response && forceRefresh) {
      return of(response);
      }

      const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();

      return this.http.get<T>(environment.API_BASE + endpoints.GET_ALL_PRODUCTS, {
          observe: 'response',
          params: new HttpParams()
          .set('pageNumber', userParams.pageNumber.toString())
          .set('pageSize', userParams.pageSize.toString())
          .set('name', userParams.name || '')
          .set('categoryId', userParams.categoryId || '')
                 
      }).pipe(
          map(res => {
              if (res.body) {
                paginatedResult.result = res.body;
                  //var resd = res.body;
              }

              const pagination = res.headers.get('Pagination');
              if (pagination) {
                paginatedResult.pagination = JSON.parse(pagination);
              }

              this.productCache.set(Object.values(userParams).join('-'), paginatedResult);
              return paginatedResult;
          })            
      );        
  }

  public deleteProduct(id: number) :Observable<any>{
    return this.http.delete<any>(environment.API_BASE + endpoints.DELETE_PRODUCT + "/" +id.toString());
  }
  public addNewProduct(product: productModel) {
      return this.http.post<any>(environment.API_BASE + endpoints.ADD_PRODUCT, product)
  }

    public putProduct(id: number, product: productModel) {
      return this.http.put<any>(environment.API_BASE + endpoints.PRODUCT_API + "/" +id.toString(), product)
  }

  GetProductById(id: number) : Observable<productModel> {
      return this.http.get<any>(environment.API_BASE + endpoints.PRODUCT_API +"/"+id.toString() ).pipe(
          map(res => {
            return res;
          })            
      )
  }

}
