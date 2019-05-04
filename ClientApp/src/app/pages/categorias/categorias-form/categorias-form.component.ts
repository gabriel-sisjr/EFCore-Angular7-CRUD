import { Component, OnInit, AfterContentChecked, Injector } from '@angular/core';
import { FormGroup, FormControl , FormBuilder, Validators } from '@angular/forms';
import { Categoria } from '../../shared/categoria.model';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoriaService } from '../../shared/categoria.service';
import toastr from 'toastr';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-categorias-form',
  templateUrl: './categorias-form.component.html',
  styleUrls: ['./categorias-form.component.css']
})
export class CategoriasFormComponent implements OnInit, AfterContentChecked {
  // Variaveis
  actionAtual: string;
  tituloPagina: string;
  dadosForm: FormGroup;
  erroServidor: string[];
  formEnviado = false;
  categoria: Categoria;

  constructor(
    private rota: ActivatedRoute,
    private roteador: Router,
    private categoriaService: CategoriaService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    // Ao iniciar, seta a sessao/regras do form e carrega a categoria (caso seja edição)
    this.SetActionAtual();
    this.BuildDadosForm();
    this.CarregarCategoria();
  }

  ngAfterContentChecked(): void {
    this.SetTitulo();
  }

  // Metodos
  EnviarForm() {
    this.formEnviado = true;

    if (this.actionAtual === 'new') {
      this.Inserir();
    } else {
      this.Atualizar();
    }
  }


  // Metodos Privados!!
  private BuildDadosForm(): void {
    // Aqui será passado o comportamento do formulario..
    // Validações, campos obrigatórios, etc.
    this.dadosForm = this.formBuilder.group({
      id: [0],
      nome: [null, [Validators.required, Validators.minLength(3)]],
      descricao: [null]
    });
  }

  private Inserir() {
    this.categoria = Object.assign(new Categoria(), this.dadosForm.value);

    this.categoriaService.inserir(this.categoria).subscribe(
      c => this.SucessoSolicitacao(),
      () => this.RetornarErros()
      );
  }

  private CarregarCategoria() {
    if (this.actionAtual === 'edit') {
      this.rota.paramMap.pipe(
        switchMap(parametros => this.categoriaService.obterPorId(+parametros.get('id')))
      ).subscribe(
        c => {
          this.categoria = c,
          this.dadosForm.patchValue(c); // Passando os valores para o formulario
        },
        () => toastr.error('Erro!!')
      );
    }
  }

  private Atualizar() {
    this.categoria = Object.assign(new Categoria(), this.dadosForm.value);

    this.categoriaService.atualizar(this.categoria).subscribe(
      c => this.SucessoSolicitacao(),
      () => this.ErroSolicitacao()
    );
  }

  // Metodos Auxiliares
  private SetActionAtual() {
    // Pega a ultima parte da rota.. new ou edit e seta na variavel.
    if (this.rota.snapshot.url[0].path === 'new') {
      this.actionAtual = 'new';
    } else {
      this.actionAtual = 'edit';
    }
  }

  private SetTitulo() {
    if (this.actionAtual === 'new') {
      this.tituloPagina = 'Nova Categoria';
    } else {
      this.tituloPagina = 'Editar Categoria';
    }
  }

  private RetornarErros() {

  }

  private ErroSolicitacao() {
    toastr.error('Erro ao realizar a solicitação!!');
  }

  private SucessoSolicitacao() {
    toastr.success('Solicitação feita com sucesso!!');

    this.roteador.navigate(['categorias']);

    // ===== Essa merda simplismente nao funciona. Desgreta! =====
    // this.roteador.navigateByUrl('categorias', {skipLocationChange: true}).then(
    //   () => this.roteador.navigate(['categorias', categoria.id, 'edit'])
    // );
  }
}
