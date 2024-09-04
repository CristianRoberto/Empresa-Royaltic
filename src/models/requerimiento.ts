import { FormGroup } from "@angular/forms";


export class Requerimiento {
    id: number =0;
    cantidad_bultos: number =0;
    cantidad_contenedores_unidades: number =0;
    tipo_carga: string ="";
    tipo_contenedor: string =""; 
    deposito_devolucion_registro_vacio: string ="";
    dimensiones: string ="";
    direccion_bodega: string ="";

    constructor(
        loginForm: FormGroup
    ) {
        this.id = 0;
        this.cantidad_bultos = Number(loginForm.controls['cantidad_bultos'].value);
        this.cantidad_contenedores_unidades = loginForm.controls['cantidad_contenedores_unidades'].value;
        this.tipo_carga = loginForm.controls['tipo_carga'].value;
        this.tipo_contenedor = loginForm.controls['tipo_contenedor'].value;
        this.deposito_devolucion_registro_vacio = loginForm.controls['deposito_devolucion_registro_vacio'].value;
        this.dimensiones = loginForm.controls['dimensiones'].value;
        this.direccion_bodega = loginForm.controls['direccion_bodega'].value;
    }
}