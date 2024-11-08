import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private url = "https://localhost:7162/api/Aliens/";

  constructor(private http:HttpClient) {}

  getAliens() {
    return this.http.get(this.url);
  }



  updateAlien(alien:any){
    return this.http.put(this.url+alien.id, alien);
  }

  deleteteAlien(alien:any){
    return this.http.delete(this.url+alien.id);
  }

  postAlien(alien:any){
    return this.http.post(this.url, alien);
  }
}
