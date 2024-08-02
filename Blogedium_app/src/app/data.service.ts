import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DataService {
  token: string;

  constructor(
    public http: HttpClient
  ) { 
    this.token = localStorage.getItem('token') || '';
  }

  get(url: string){
    return this.http.get(url, {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.token}`
      })
    })
  }

  post(url: string, body: any){
    return this.http.post(url, body, {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.token}`
      })
    })
  }

  update(url: string, body: string){
    return this.http.put(url, body, {
      headers: new HttpHeaders({
        "Authorization": `Bearer ${this.token}`
      })
    })
  }

  delete(url: string){
    return this.http.delete(url, {
      headers: new HttpHeaders({
        "Authorization": `Bearer ${this.token}`
      })
    })
  }
}
