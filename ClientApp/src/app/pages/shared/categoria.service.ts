import { Injector, Injectable } from '@angular/core';
import { BaseResourceService } from 'src/app/shared/services/BaseResource.service';
import { Categoria } from './categoria.model';
import { API_PATH_CATEGORIAS } from 'src/app/shared/apiPath';

@Injectable()
export class CategoriaService extends BaseResourceService<Categoria> {
    constructor(protected injetor: Injector) {
        super(API_PATH_CATEGORIAS, injetor);
    }
}
