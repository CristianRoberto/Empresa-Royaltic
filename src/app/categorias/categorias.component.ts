import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Categoria } from 'src/models/categoria';
import { CategoriaService } from 'src/services/categoria.service';
import { timer } from 'rxjs';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent {
  loginForm: FormGroup;
  Categoria: Categoria[] = [];

  eliminacionExitosa: boolean = false;
  idEliminado: number | null = null; // Inicialmente no hay ID eliminado
  guardadoExitoso: boolean = false;
  ModificacionExitosa: boolean = false;


  constructor(private service: CategoriaService, private fb: FormBuilder) {
    this.loginForm = this.fb.group({      
    });
    this.inicializarForm();
  }

  ngOnInit(): void {
    this.obtenerCategoria();
  }

  obtenerCategoria() {
    this.service.obtenerCategoria().subscribe((dat) => {
      this.Categoria = dat;
    });
  }



  inicializarForm() {
    this.loginForm = this.fb.group({
      CategoriasID: [{ value: '', disabled: true }], // ID, deshabilitado para que no se edite directamente
      Nombre: ['', Validators.required], // Campo obligatorio para el nombre
      Descripcion: [''], // Campo opcional para la descripción
      Estado: [1, Validators.required], // Campo obligatorio, valor por defecto activo (1)
      FechaCreacion: [{ value: '', disabled: true }], // Fecha de creación, deshabilitada
      FechaActualizacion: [''] // Fecha de última actualización, opcional
    });
  }

  grabar() {
    // let req = new Producto(this.loginForm);
    // this.service.crearProducto(req).subscribe(
    //   () => {
    //     this.guardadoExitoso = true; // Mostrar el mensaje de guardado exitoso
    //     this.obtenerProducto(); // Actualiza la lista de Productos después de guardar
    //     setTimeout(() => {
    //       this.guardadoExitoso = false; // Ocultar el mensaje después de unos segundos
    //     }, 3000); // Ocultar después de 3 segundos
    //   },
    //   (error) => {
    //     console.error('Error al guardar el Producto', error);
    //     // Manejo de errores si es necesario
    //   }
    // );
  }
  
  eliminarRequerimiento(categoriasId: any) {
    // Verifica el ID recibido
    console.log(`ID recibido para eliminación: ${categoriasId}`);
  
    this.service.deleteCategoria(categoriasId).subscribe(
      () => {
        // Elimina el requerimiento y actualiza la lista
        console.log(`Requerimiento ${categoriasId} eliminado con éxito`);
        this.obtenerCategoria(); // Actualiza la lista de categorías después de guardar
        this.eliminacionExitosa = true; // Mostrar el mensaje de éxito
        this.idEliminado = categoriasId; // Guardar el ID eliminado
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

}


