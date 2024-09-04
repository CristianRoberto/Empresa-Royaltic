import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrincipalComponent } from './principal/principal.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { ProductosComponent } from './productos/productos.component';


const routes: Routes = [
  { path: '', component: PrincipalComponent }, // Agrega la nueva ruta
  { path: 'categorias', component: CategoriasComponent }, // Ruta para Categorías
  { path: 'productos', component: ProductosComponent }, // Ruta para Productos

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
