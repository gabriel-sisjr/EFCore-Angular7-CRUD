import { BaseResourceService } from 'src/app/shared/services/BaseResource.service';
import { Entrada } from './entrada.model';
import { Injector, Injectable } from '@angular/core';
import { API_PATH_ENTRADAS } from 'src/app/shared/apiPath';
import { Observable } from 'rxjs';

@Injectable()
export class EntradaService extends BaseResourceService<Entrada> {
    constructor(protected injetor: Injector) {
        super(API_PATH_ENTRADAS, injetor, Entrada);
    }

    obterTodos(): Observable<Entrada[]> {
        return super.obterTodos();
    }

    obterPorId(id?: number): Observable<Entrada> {
        return super.obterPorId(id);
    }

    // Private methods
    protected ObjetosToJson(jsonData: any[]): Entrada[] {
        const objetos: Entrada[] = [];
        jsonData.forEach(element => objetos.push(Object.assign(new Entrada, element)));
        return objetos;
    }

    protected ObjetoToJson(jsonData: any): Entrada {
        return Object.assign(new Entrada, jsonData);
    }
}