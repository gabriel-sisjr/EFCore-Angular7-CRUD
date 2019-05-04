import { Component, OnInit } from '@angular/core';
import { Categoria } from '../../shared/categoria.model';
import { CategoriaService } from '../../shared/categoria.service';
import toastr from 'toastr';

@Component({
  selector: 'app-categorias-list',
  templateUrl: './categorias-list.component.html',
  styleUrls: ['./categorias-list.component.css']
})
export class CategoriasListComponent implements OnInit {

  private categorias: Categoria[] = [];
  constructor(private categoriaService: CategoriaService) { }

  ngOnInit() {
    this.categoriaService.obterTodos().subscribe(
      categorias => this.categorias = categorias.sort((a, b) => a.id - b.id),
      () => toastr.error('Falha ao carregar os itens!!')
    );
  }

  deletar(categoria: Categoria) {
    const confirmacao = confirm('Confirmar exclusao');

    if (confirmacao) {
      this.categoriaService.deletar(categoria.id).subscribe(
        () => {
          this.categorias = this.categorias.filter(element => element !== categoria),
          toastr.success('Deletado com sucesso!!');
        },
        () => alert('falha ao deletar!')
      );
    }
  }
}
