import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoriasListComponent } from './categorias-list/categorias-list.component';
import { CategoriasFormComponent } from './categorias-form/categorias-form.component';

const routes: Routes = [
  {path: '', component: CategoriasListComponent},
  {path: 'new', component: CategoriasFormComponent},
  {path: ':id/edit', component: CategoriasFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriasRoutingModule { }
