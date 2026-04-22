import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NLMaterialModuler } from './material-module';
import { HTTP_INTERCEPTORS, HttpClientModule, withInterceptors } from '@angular/common/http';
import {MatExpansionModule} from '@angular/material/expansion';
//import { MaterialElevationDirective } from './directives/material-elevation.directive';
import {FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { PaginationModule } from 'ngx-bootstrap/pagination';
//import { DateInputComponent } from './components/common/inputs/date-input/date-input.component';
import { TabsModule, TabsetConfig } from 'ngx-bootstrap/tabs';
//import { ErrorInterceptor } from './_interceptor/error.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
//import { LoadingInterceptor } from './_interceptor/loading.interceptor';
import { ToastrModule } from 'ngx-toastr';
//import { NotFoundComponent } from './errors/not-found/not-found.component';
//import { ServerErrorComponent } from './errors/server-error/server-error.component';
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {AsyncPipe} from '@angular/common';

import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
//import {MatButtonModule} from '@angular/material/button';
//import { ConfirmDeleteDialogComponent } from './confirm-delete-dialog/confirm-delete-dialog.component';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';
//import { SeparatorDirective } from './directives/separator.directive';

import { ProductListComponent } from './Components/product-list/product-list.component';
import { DeleteProductPopupComponent } from './Components/product-list/delete-product-popup/delete-product-popup.component';
import { MatTableModule } from '@angular/material/table';
import { WinAuthInterceptorInterceptor } from './_interceptors/win-auth-interceptor.interceptor';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import {LoadingInterceptor } from './_interceptors/loading.interceptor';
import { NotFoundComponent } from './Components/ErrorsHandlersComponents/not-found/not-found.component';
import { ServerErrorComponent } from './Components/ErrorsHandlersComponents/server-error/server-error.component';
import { NavComponent } from './Components/nav/nav.component'

import {MatIconModule } from '@angular/material/icon';
import { AddEditProductComponent } from './Components/product-list/add-edit-product/add-edit-product.component'

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    DeleteProductPopupComponent,
    NotFoundComponent,
    ServerErrorComponent,
    NavComponent,
    AddEditProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NLMaterialModuler,
    BrowserAnimationsModule,
    HttpClientModule,
    MatExpansionModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    TabsModule,
    MatDialogModule,
    PaginationModule.forRoot(),
    NgxSpinnerModule,
     AsyncPipe,
     MatAutocompleteModule,
     MatInputModule,
     MatFormFieldModule,
    ToastrModule.forRoot  ({ closeButton: true, timeOut: 5000}),
  ],
  providers: [
     {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
     {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: WinAuthInterceptorInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
