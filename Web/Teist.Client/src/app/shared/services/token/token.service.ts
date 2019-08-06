import { Injectable } from '@angular/core';
import { getConfig } from '../../config/app.config';
import { AuthenticationModel } from '../../models/contracts/authentication-model.interface';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  private readonly config = getConfig();

  private authenticationModel?: AuthenticationModel;

  constructor() { }

  get token(): string | void {
    if (!this.authenticationModel) {
      const tokenFromSessionStorage = sessionStorage.getItem(
        this.config.tokenName
      );

      if (!tokenFromSessionStorage) {
        return;
      }

      this.setToken(tokenFromSessionStorage, false);
    }

    if (Date.now() > this.authenticationModel.expirationTime) {

      this.removeToken();
      return;
    }

    return this.authenticationModel.token;
  }

  public setToken(token: string, setStorage: boolean): void {
    const decodedToken = jwt_decode(token);
    this.authenticationModel = {
      token,
      uniqueName: decodedToken.uniqueName,
      roles: decodedToken.role,
      expirationTime: decodedToken.exp
    };

    if (setStorage) {
      sessionStorage.setItem(
        this.config.tokenName,
        token
      );
    }
  }

  public removeToken(): void {
    this.authenticationModel = undefined;
    sessionStorage.removeItem(this.config.tokenName);
  }

  get isLoggedIn(): boolean {
    return !!this.token;
  }
}

