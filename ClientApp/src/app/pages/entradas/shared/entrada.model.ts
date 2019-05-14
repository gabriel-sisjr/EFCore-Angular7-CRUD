import { Categoria } from '../../shared/categoria.model';

export class Entrada {
    constructor(
        public id?: number,
        public nome?: string,
        public descricao?: string,
        public tipo?: string,
        public valor?: string,
        public data?: string,
        public pago?: boolean,
        public categoriaId?: number,
        public categoria?: Categoria
    ) {}

    static tipos = {
        expense: 'Despesa',
        revenue: 'Receita'
    }

    getTextoPago(): string {
        return this.pago ? 'Pago' : 'Pendente';
    }

    getTipoEntrada(): string {
        return this.tipo == 'revenue' ? 'Despesa' : 'Receita';
    }
}