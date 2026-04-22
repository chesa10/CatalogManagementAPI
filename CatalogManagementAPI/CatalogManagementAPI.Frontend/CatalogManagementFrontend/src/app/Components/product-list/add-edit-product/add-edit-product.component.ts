import { Component, Inject, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validator, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ProductService } from 'src/app/_services/product/product.service';
import { productist } from 'src/app/_modes/product/product-list';
import { productModel } from 'src/app/_modes/product/productModel';
import { CategoryService } from 'src/app/_services/category/category.service';
import { categoryDropDown } from 'src/app/_modes/category/categoryDropDownModel';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.scss']
})
export class AddEditProductComponent implements OnInit {
  title: '';
  id: 0;
  productM: productModel;
  catList: categoryDropDown[];
 
   form: FormGroup = new FormGroup({})
  constructor(@Inject(MAT_DIALOG_DATA) public data:any,
        private fb:FormBuilder,
        private ref:MatDialogRef<AddEditProductComponent>,
        private productservice: ProductService,
        private categoryservice: CategoryService,
        private toaster: ToastrService) {
          this.title = data.title;
          this.id = data.id;
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

    this.initializeForm();
    this.setupComponent();
  }  

  initializeForm() {
    this.form = this.fb.group({  
            name: ["", [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
            description: ["", Validators.required],
            sku: ["", Validators.required],
            price: [1, Validators.required],
            quantity: [0, Validators.required],
            category: [null, Validators.required],
    
    })
}



  private setupComponent = () => {
    if(this.id > 0) {
      this.productservice.GetProductById(this.id )
    .subscribe(res => {
        if(res) {
          this.productM = res;
              if(this.productM) {
                this.form.patchValue ({
                  name: this.productM.name,
                  description: this.productM.description,
                  sku: this.productM.sku,
                  price: this.productM.price,
                  quantity: this.productM.quantity,
                  category: this.productM.categoryId
                });
            } 
            } else {
              this.toaster.error('Something went wrong!');
            }
    });
    }        
  }; 

  closeDialog() {
     this.ref.close();
  }

 addProduct() {   
    var product = new productModel();
  product.id = this.id;
  product.name = this.form.controls['name'].value
  product.description = this.form.controls['description'].value
  product.quantity = this.form.controls['quantity'].value
  product.price = this.form.controls['price'].value
  product.categoryId = this.form.controls['category'].value
  product.sku = this.form.controls['sku'].value

   if(this.id > 0) {
     this.productservice.putProduct(this.id, product)
    .subscribe(res => {
        if(res) {
          this.toaster.success('Product successfully updated.');
          this.closeDialog();
        } else {
          this.toaster.error('Something went wrong!');
        }
    })

   } else {

     this.productservice.addNewProduct(product)
    .subscribe(res => {
        if(res) {
          this.toaster.success('Product successfully Added.');
          this.closeDialog();
        } else {
          this.toaster.error('Something went wrong!');
        }
    })
   }
  }
}
