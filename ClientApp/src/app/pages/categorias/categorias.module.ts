import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriasRoutingModule } from './categorias-routing.module';
import { CategoriasListComponent } from './categorias-list/categorias-list.component';
import { CategoriasFormComponent } from './categorias-form/categorias-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [CategoriasListComponent, CategoriasFormComponent],
  imports: [
    CommonModule,
    CategoriasRoutingModule,
    ReactiveFormsModule
  ]
})
export class CategoriasModule { }
