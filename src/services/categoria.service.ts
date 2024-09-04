import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Categoria } from 'src/models/categoria';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  urlApi?: string = "https://localhost:7240/api/Categoria";
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.obtenerCategoria();
  }

  obtenerCategoria(): Observable<Categoria[]> {
    const endpoint = `${this.urlApi}/ListaCategorias/`;
    return this.http.get<Categoria[]>(endpoint, {}).pipe(
      tap(ret => {
        console.log(ret)
      })
    );
  }

  deleteCategoria(categoriasId: any): Observable<void> {
    const url = `${this.urlApi}/Eliminar/${categoriasId}`; // Cambia la URL según tu API
    return this.http.delete<void>(url);
  }

}
