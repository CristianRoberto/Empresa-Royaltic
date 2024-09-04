import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Requerimiento } from 'src/models/requerimiento';
import { ApiService } from 'src/services/api.service';
import { timer } from 'rxjs';
@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent {


//   eliminacionExitosa: boolean = false;
//   idEliminado: number | null = null; // Inicialmente no hay ID eliminado

//   guardadoExitoso: boolean = false;

//   ModificacionExitosa: boolean = false;

//   title = 'Gilces';
//   requerimiento: Requerimiento[] = [];
//   loginForm: FormGroup;

//   constructor(private service: ApiService, private fb: FormBuilder) {
//     this.loginForm = this.fb.group({      
//     });
//     this.inicializarForm();
//   }

//   ngOnInit(): void {
//     this.obtenerRequerimiento();
//   }
  

//   ruta(){
    
//   }
//   onSetData(req: Requerimiento) {
//     this.loginForm.patchValue({
//       id: req.id,
//       cantidad_bultos: req.cantidad_bultos,
//       cantidad_contenedores_unidades: req.cantidad_contenedores_unidades,
//       tipo_carga: req.tipo_carga,
//       tipo_contenedor: req.tipo_contenedor,
//       deposito_devolucion_registro_vacio: req.deposito_devolucion_registro_vacio,
//       dimensiones: req.dimensiones,
//       direccion_bodega: req.direccion_bodega
//     });
//   }
  

//   clear(){   
//       this.loginForm.reset(); // Esto limpiará todos los campos del formulario
//     }
    

  
//   obtenerRequerimiento() {
//     this.service.obtenerRequerimiento().subscribe((dat) => {
//       this.requerimiento = dat;
//     });
//   }

//   grabar() {
//     let req = new Requerimiento(this.loginForm);
//     this.service.crearRequerimiento(req).subscribe(
//       () => {
//         this.guardadoExitoso = true; // Mostrar el mensaje de guardado exitoso
//         this.obtenerRequerimiento(); // Actualiza la lista de requerimientos después de guardar
//         setTimeout(() => {
//           this.guardadoExitoso = false; // Ocultar el mensaje después de unos segundos
//         }, 3000); // Ocultar después de 3 segundos
//       },
//       (error) => {
//         console.error('Error al guardar el requerimiento', error);
//         // Manejo de errores si es necesario
//       }
//     );
//   }



  

//   modificarRequerimiento(id: number) {
//     const updatedRequerimiento: Requerimiento = {
//       id: this.loginForm.get('id')?.value,
//       cantidad_bultos: this.loginForm.get('cantidad_bultos')?.value,
//       cantidad_contenedores_unidades: this.loginForm.get('cantidad_contenedores_unidades')?.value,
//       tipo_carga: this.loginForm.get('tipo_carga')?.value,
//       tipo_contenedor: this.loginForm.get('tipo_contenedor')?.value,
//       deposito_devolucion_registro_vacio: this.loginForm.get('deposito_devolucion_registro_vacio')?.value,
//       dimensiones: this.loginForm.get('dimensiones')?.value,
//       direccion_bodega: this.loginForm.get('direccion_bodega')?.value
//     };   
//     console.log(updatedRequerimiento);
//     this.service.actualizarRequerimiento(id, updatedRequerimiento).subscribe(
//       () => {
//         console.log(`Requerimiento Actualizado con éxito`);
//         this.ModificacionExitosa = true; // Mostrar el mensaje de éxito

//         this.obtenerRequerimiento(); // Llamada al método que obtiene los requerimientos

//         // Actualiza la lista de requerimientos después de eliminar si es necesario
//         timer(3000).subscribe(() => {
//           this.ModificacionExitosa = false; // Ocultar el mensaje después de 3 segundos
// });
//         // Aquí puedes realizar acciones adicionales después de actualizar, si es necesario
//       },
//       (error) => {
//         console.error('Error al actualizar el requerimiento', error);
//         // Manejo de errores si es necesario
//       }
//     );
//     }
  
//   inicializarForm() {
//     this.loginForm = this.fb.group({      
//       id: { value: '',  }, // Deshabilita el campo 'id'

//       cantidad_bultos: ['', Validators.required],
//       cantidad_contenedores_unidades: ['', Validators.required],
//       tipo_carga: ['', Validators.required],
//       tipo_contenedor: ['', Validators.required],
//       deposito_devolucion_registro_vacio: [''],
//       dimensiones: ['', Validators.required],
//       direccion_bodega: ['', Validators.required]
//     });
//   }
}








  





