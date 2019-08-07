import { Injectable } from '@angular/core';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { User } from '../../models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenService } from '../token/token.service';
import { Configuration } from '../../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService{

  private config = Configuration;

  private headers = new HttpHeaders();

  constructor(private http: HttpClient) {
    this.headers.set('Content-Type', 'application/json');
  }

  public LogIn(form: any){
  this.http.post(this.config.restApi.prefix + this.config.restApi.authentication.login, form, );
  }

  public Register(form: any){
    this.http.post(this.config.restApi.prefix + this.config.restApi.authentication.register,
      form, {headers: this.headers});
    }
}
