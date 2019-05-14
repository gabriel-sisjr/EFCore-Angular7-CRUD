import { Component, OnInit } from '@angular/core';
import { Entrada } from '../shared/entrada.model';
import { EntradaService } from '../shared/entrada.service';
import toastr from "toastr";

@Component({
  selector: 'app-entrada-list',
  templateUrl: './entrada-list.component.html',
  styleUrls: ['./entrada-list.component.css']
})
export class EntradaListComponent implements OnInit {

  entradas: Entrada[] = [];

  constructor(private entradaService: EntradaService) { }

  ngOnInit() {
    this.entradaService.obterTodos().subscribe(
      entrada => this.entradas = entrada.sort((a,b) => a.id - b.id),
      error => toastr.error(error)
    );
  }
  
  deletarEntrada(entrada: Entrada) {
    const deletar = confirm('Deseja deletar?');

    if (deletar) {
      this.entradaService.deletar(entrada.id).subscribe(
        () => this.entradas = this.entradas.filter(element => element != entrada),
        () => toastr.error('Erro ao deletar')
      );
    }
  }

}
