import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: 'categorias', loadChildren: './pages/categorias/categorias.module#CategoriasModule'},
  {path: 'entradas', loadChildren: './pages/entradas/entradas.module#EntradasModule'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
