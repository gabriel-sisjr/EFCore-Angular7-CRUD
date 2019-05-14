import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EntradaListComponent } from './entrada-list/entrada-list.component';
import { EntradaFormComponent } from './entrada-form/entrada-form.component';

const routes: Routes = [
  {path: '', component: EntradaListComponent},
  {path: 'new', component: EntradaFormComponent},
  {path: ':id/edit', component: EntradaFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EntradasRoutingModule { }
