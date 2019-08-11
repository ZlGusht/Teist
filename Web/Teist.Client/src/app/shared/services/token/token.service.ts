import { Injectable } from '@angular/core';
import {Configuration } from '../../config/app.config';
import { AuthenticationModel } from '../../models/contracts/authentication-model';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  private readonly config = Configuration;

  private authenticationModel?: AuthenticationModel;

  constructor() { }

  get token(): string | void {
    if (!this.authenticationModel) {
      const token = localStorage.getItem('IDENTITY_TOKEN');

      if (!token) {
        return;
      }

      this.fillToken(token);
    }

    const date = Date.now();
    if(this.authenticationModel.expirationTime > date){
      this.removeToken;
    }

    return this.authenticationModel.token;
  }

  public setToken(data: any): void {
    const decodedToken = jwt_decode(data.access_token);
    localStorage.setItem('IDENTITY_TOKEN', data.access_token);
    localStorage.setItem('IDENTITY_TOKEN_EXPIRY', decodedToken.exp);
    localStorage.setItem('IDENTITY_ROLE', decodedToken.Roles);
    this.fillToken(data.access_token);
  }

  public removeToken(): void {
    this.authenticationModel = undefined;
    localStorage.removeItem('IDENTITY_TOKEN');
  }

  get isLoggedIn(): boolean {
    return !!this.token;
  }

  private fillToken(token: string) {
    const decodedToken = jwt_decode(token);
    this.authenticationModel = new AuthenticationModel();
    this.authenticationModel.expirationTime = decodedToken.exp;
    this.authenticationModel.uniqueName = decodedToken.sub;
    this.authenticationModel.token = token;
  }

  get userName() {
    if (this.token) {
      return this.authenticationModel.uniqueName
    }
  }
}

