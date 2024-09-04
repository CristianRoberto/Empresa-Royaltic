import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Producto } from 'src/models/productos';
import { ApiService } from 'src/services/api.service';
import { timer } from 'rxjs';


@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {
  loginForm: FormGroup;
  Producto: Producto[] = [];

  eliminacionExitosa: boolean = false;
  idEliminado: number | null = null; // Inicialmente no hay ID eliminado
  guardadoExitoso: boolean = false;
  ModificacionExitosa: boolean = false;


  constructor(private service: ApiService, private fb: FormBuilder) {
    this.loginForm = this.fb.group({      
    });
    this.inicializarForm();
  }

    ngOnInit(): void {
    this.obtenerProducto();
  }

  obtenerProducto() {
    this.service.obtenerProducto().subscribe((dat) => {
      this.Producto = dat;
    });
  }

  grabar() {
    let req = new Producto(this.loginForm);
    this.service.crearProducto(req).subscribe(
      () => {
        this.guardadoExitoso = true; // Mostrar el mensaje de guardado exitoso
        this.obtenerProducto(); // Actualiza la lista de Productos después de guardar
        setTimeout(() => {
          this.guardadoExitoso = false; // Ocultar el mensaje después de unos segundos
        }, 3000); // Ocultar después de 3 segundos
      },
      (error) => {
        console.error('Error al guardar el Producto', error);
        // Manejo de errores si es necesario
      }
    );
  }


    
  eliminarProducto(productoId: any) {
    // Verifica el ID recibido
    console.log(`ID recibido para eliminación: ${productoId}`);
  
    this.service.deleteProducto(productoId).subscribe(
      () => {
        // Elimina el requerimiento y actualiza la lista
        console.log(`Requerimiento ${productoId} eliminado con éxito`);
        this.obtenerProducto(); // Actualiza la lista de categorías después de guardar
        this.eliminacionExitosa = true; // Mostrar el mensaje de éxito
        this.idEliminado = productoId; // Guardar el ID eliminado
        // Oculta el mensaje después de unos segundos
        setTimeout(() => {
          this.eliminacionExitosa = false; // Ocultar el mensaje después de unos segundos
        }, 3000); // Ocultar después de 3 segundos
      },
      (error) => {
        // Manejo de errores
        console.error('Error al eliminar el requerimiento', error);
      }
    );
  }
  
  clear(){   
    this.loginForm.reset(); // Esto limpiará todos los campos del formulario
  }


  inicializarForm() {
    this.loginForm = this.fb.group({
      ProductoID: [{ value: '', disabled: true }], // ID, deshabilitado
  
      Nombre: ['', Validators.required], // Nombre obligatorio
      Descripcion: [''], // Descripción opcional
      Precio: ['', [Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]], // Precio obligatorio, formato decimal
      Stock: ['', [Validators.required, Validators.min(0)]], // Stock obligatorio, debe ser mayor o igual a 0
      SKU: ['', [Validators.required, Validators.pattern(/^[a-zA-Z0-9_-]{1,50}$/)]], // SKU obligatorio, único y alfanumérico
      Proveedor: [''], // Proveedor opcional
      FechaIngreso: [{ value: '', disabled: true }], // Fecha de ingreso deshabilitada
      Estado: [1, Validators.required], // Estado obligatorio
      FechaCreacion: [{ value: '', disabled: true }], // Fecha de creación deshabilitada
      FechaActualizacion: [''] // Fecha de última actualización opcional
    });
  }
  
}



