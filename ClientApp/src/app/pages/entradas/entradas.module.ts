import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EntradasRoutingModule } from './entradas-routing.module';
import { EntradaFormComponent } from './entrada-form/entrada-form.component';
import { EntradaListComponent } from './entrada-list/entrada-list.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [EntradaFormComponent, EntradaListComponent],
  imports: [
    CommonModule,
    EntradasRoutingModule,
    ReactiveFormsModule
  ]
})
export class EntradasModule { }
