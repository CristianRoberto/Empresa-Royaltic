import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Producto } from 'src/models/productos';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  urlApi?: string = "https://localhost:7240/api/Producto";

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.obtenerProducto();
  }

  obtenerProducto(): Observable<Producto[]> {
    const endpoint = `${this.urlApi}/ListaProductos/`;
    return this.http.get<Producto[]>(endpoint, {}).pipe(
      tap(ret => {
        console.log(ret)
      })
    );
  }

//Servicio para crear un nuevo Producto metodo post
crearProducto(req: any): Observable<any> {
    console.table(JSON.stringify(req));
    const endpoint = `${this.urlApi}/Guardar/`;
    return this.http.post<any>(endpoint, req).pipe(
      tap(ret => {
        console.log('correcto');
        let p = 0;
      })
    );
  }

    // HttpClient API delete() method => Delete 

    deleteProducto(id: any): Observable<void> {
    const url = `${this.urlApi}/Eliminar/${id}`; // Cambia la URL según tu API
    return this.http.delete<void>(url);
  }

  actualizarRequerimiento(id: number, requerimiento: Producto): Observable<any> {
    const url = `${this.urlApi}/Editar/`; // Ajusta la URL según tu API
    return this.http.put(url, requerimiento);
  }
}