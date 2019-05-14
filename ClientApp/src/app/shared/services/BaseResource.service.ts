import { BaseResourceModel } from '../models/BaseResource.model';
import { Observable, throwError } from 'rxjs';
import { Injector, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

export abstract class BaseResourceService<T extends BaseResourceModel> {

    // Variavel a ser injetada
    protected http: HttpClient;
    protected obj: T;

    constructor(protected apiPath: string, protected injetor: Injector, private tipo: new() => T) {
        // Injetando a instancia do HTTPClient presente, a variavel
        this.http = injetor.get(HttpClient);
        //this.obj = injetor.get(typeof(T));
    }
    obterTodos(): Observable<T[]> {
        return this.http.get(this.apiPath).pipe(
            catchError(this.LancarError),
            map(this.ObjetosToJson)
        );
    }

    obterPorId(id: number): Observable<T> {
        return this.http.get(`${this.apiPath}/${id}`).pipe(
            catchError(this.LancarError),
            map(this.ObjetoToJson)
        );
    }

    inserir(objeto: T): Observable<T> {
        return this.http.post(this.apiPath, objeto).pipe(
            catchError(this.LancarError),
            map(this.ObjetoToJson)
        );
    }

    atualizar(objeto: T): Observable<T> {
        return this.http.put(`${this.apiPath}/${objeto.id}`, objeto).pipe(
            catchError(this.LancarError),
            map(() => objeto)
        );
    }

    deletar(id: number): Observable<any> {
        return this.http.delete(`${this.apiPath}/${id}`).pipe(
            catchError(this.LancarError),
            map(() => Boolean)
        );
    }

    // Metodos auxiliares
    protected LancarError(error: any): Observable<any> {
        // Aqui virá o erro do servido do backend.
        // Configurar o codigo do erro.
        // Toast permanecendo no path atual.
        console.log('Erro -> ', error);
        return throwError(error);
    }

    protected ObjetosToJson(jsonData: any[]): T[] {
        const objetos: T[] = [];
        jsonData.forEach(element => objetos.push(Object.assign(this.tipo, element)));
        return objetos;
    }

    protected ObjetoToJson(jsonData: any): T {
        return Object.assign(this.tipo, jsonData);
    }
}
