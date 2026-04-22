import { Component, OnInit, ViewChild } from '@angular/core';
import { UserParams } from 'src/app/_modes/UserParams';
import { ProductService } from 'src/app/_services/product/product.service';
import { MatTableDataSource,MatTableModule } from '@angular/material/table'
import { productist } from 'src/app/_modes/product/product-list';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { DeleteProductPopupComponent } from './delete-product-popup/delete-product-popup.component';
import { Pagination } from 'src/app/_modes/pagination/pagination';
import { AddEditProductComponent } from './add-edit-product/add-edit-product.component';
import { CategoryService } from 'src/app/_services/category/category.service';
import { categoryDropDown } from 'src/app/_modes/category/categoryDropDownModel';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

    dataSource = new MatTableDataSource<productist>([]);
    userParams: UserParams | undefined;
    pagination: Pagination | undefined;
    displayedColumns: string[] = [ 'name', 'description','sku','price', 'quantity', 'actions'];
    @ViewChild(MatSort) sort: MatSort;
      catList: categoryDropDown[];

    data: any = {
    name: '',
    categoryId: 0,
  };

    constructor(private productservice: ProductService,
                private dialog: MatDialog,
                private toaster: ToastrService,
                private categoryservice: CategoryService,
    ) {
        this.userParams = new UserParams();
    }

    ngOnInit(): void {
    //get category list
        this.categoryservice.GetAllCategories().subscribe(res => {
            if(res) {
                  this.catList = res;
                } else {
                  this.toaster.error('Something went wrong!');
                }
        });
       (async () => {
          await this.getProductLIst();
        })()
    }

    editRow(id: number) {
      this.AddEditProduct(id)
    }

  pageChanged(event: any) {
    this.userParams = new UserParams();
    this.userParams.pageNumber = event.page;
    this.userParams.pageSize = 5;
    
    this.userParams.name = this.data.name;
    this.userParams.categoryId = this.data.categoryId;

  this.productservice.getScrollList<productist[]>(this.userParams)
    .subscribe(res => {
      this.dataSource = new MatTableDataSource(res.result);
      this.pagination = res.pagination;
    });
  }

  async getProductLIst() : Promise<void> {
            // default list params
      this.userParams = new UserParams();
      this.userParams.pageNumber = 1;
      this.userParams.pageSize = 5;
      
      this.productservice.getScrollList<productist[]>(this.userParams)
          .subscribe(res => {
            this.dataSource = new MatTableDataSource(res.result);
            this.pagination = res.pagination;
          })
  }

  applyAdvancedFilter(refresh:boolean = true) {
    this.userParams = new UserParams();
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 5;
    this.userParams.name = this.data.name;
    this.userParams.categoryId = this.data.categoryId;

  this.productservice.getScrollList<productist[]>(this.userParams, refresh)
    .subscribe(res => {
      this.dataSource = new MatTableDataSource(res.result);
      this.dataSource.sort = this.sort;
      this.pagination = res.pagination;
    });
}
    
  AddEditProduct(id: number = 0) {
      var _popup = this.dialog.open(AddEditProductComponent, {
        width: '40%',
        data: {
            title: id > 0 ? 'Edit Product' : 'Add New Product',
            id: id
        }
    });
    _popup.afterClosed().subscribe(result => {
        this.applyAdvancedFilter(false);
    });
    }

  deleteProduct(id: number) {
    const _popup = this.dialog.open(DeleteProductPopupComponent, {
      width: '40%',
      data: {
        title: 'Delete Product',
        refNumber: 0
      }
    });
    _popup.afterClosed().subscribe(result => {

      if (result) {
        this.productservice.deleteProduct(id).subscribe({
             next: data => {
                 this.toaster.success('Product deleted successfully');
              },
              error: error => {
                console.error(error)
                  this.toaster.error('Failed to delete Product')
              },
              complete: () => {
                this.applyAdvancedFilter(false);
              }
            });
      } else {
      }
    });
   }
}
