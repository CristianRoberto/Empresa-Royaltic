import { FormGroup } from "@angular/forms";

export class Producto {
    productoId: number = 0;
    nombre: string = "";
    descripcion: string = "";
    precio: number = 0;
    stock: number = 0;
    sku: string = "";
    proveedor: string = "";
    fechaIngreso: Date = new Date();
    estado: boolean = true; // O puedes usar 1 o 0, según tus necesidades
    fechaCreacion: Date = new Date();
    fechaActualizacion: Date | null = null;

    constructor(
        productoForm: FormGroup
    ) {
        this.productoId = productoForm.controls['productoId'].value || 0;
        this.nombre = productoForm.controls['nombre'].value || "";
        this.descripcion = productoForm.controls['descripcion'].value || "";
        this.precio = Number(productoForm.controls['precio'].value) || 0;
        this.stock = Number(productoForm.controls['stock'].value) || 0;
        this.sku = productoForm.controls['sku'].value || "";
        this.proveedor = productoForm.controls['proveedor'].value || "";
        this.fechaIngreso = productoForm.controls['fechaIngreso'].value ? new Date(productoForm.controls['fechaIngreso'].value) : new Date();
        this.estado = productoForm.controls['estado'].value ?? true; // Asume que el valor predeterminado es verdadero
        this.fechaCreacion = productoForm.controls['fechaCreacion'].value ? new Date(productoForm.controls['fechaCreacion'].value) : new Date();
        this.fechaActualizacion = productoForm.controls['fechaActualizacion'].value ? new Date(productoForm.controls['fechaActualizacion'].value) : null;
    }
}
