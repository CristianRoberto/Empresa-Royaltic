import { FormGroup } from "@angular/forms";

export class Categoria {
    categoriasId: number = 0;
    nombre: string = "";
    descripcion: string = "";
    estado: boolean = true; // Estado activo/inactivo, se asume que 1 es verdadero y 0 es falso
    fechaCreacion: Date = new Date();
    fechaActualizacion: Date | null = null;

    constructor(
        categoriaForm: FormGroup
    ) {
        this.categoriasId = categoriaForm.controls['categoriasId'].value || 0;
        this.nombre = categoriaForm.controls['nombre'].value || "";
        this.descripcion = categoriaForm.controls['descripcion'].value || "";
        this.estado = categoriaForm.controls['estado'].value ?? true; // Asume que el valor predeterminado es verdadero
        this.fechaCreacion = categoriaForm.controls['fechaCreacion'].value ? new Date(categoriaForm.controls['fechaCreacion'].value) : new Date();
        this.fechaActualizacion = categoriaForm.controls['fechaActualizacion'].value ? new Date(categoriaForm.controls['fechaActualizacion'].value) : null;
    }
}
