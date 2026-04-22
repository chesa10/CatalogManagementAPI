import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { config } from './Config/Config';
import { productist } from './_modes/product/product-list';
import { NotFoundComponent } from './Components/ErrorsHandlersComponents/not-found/not-found.component';
import { ServerErrorComponent } from './Components/ErrorsHandlersComponents/server-error/server-error.component';
import { ProductListComponent } from './Components/product-list/product-list.component';

const appRoutes = config.routes;
const routes: Routes = [
    { path: '', redirectTo: appRoutes.productsList.path, pathMatch: 'full' },
    {path: appRoutes.productsList.path, component: ProductListComponent,},
    {path: appRoutes.notFound.path, component: NotFoundComponent},
    {path: appRoutes.internalServerError.path, component: ServerErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
