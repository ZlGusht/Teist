import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest, HttpParams } from '@angular/common/http';
import { Configuration } from '../../config/app.config';
import { TokenService } from '../token/token.service';
import { map, catchError } from 'rxjs/operators';
import { EmptyObservable } from 'rxjs-compat/observable/EmptyObservable';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private config = Configuration;

  private headers = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded');

  private httpRequest: HttpRequest<any>;

  constructor(private http: HttpClient, private tokenService: TokenService) {
  }

  public LogIn(form: any) {
    const payload = new HttpParams()
    .set('email', form.email)
    .set('password', form.password)
    .toString();
    let request = this.makeRequestOptions('POST', this.config.restApi.prefix +
    this.config.restApi.authentication.login, payload);

    request = request.clone({headers: this.headers});
    console.log(request);

    return this.http.post(this.config.restApi.prefix +
      this.config.restApi.authentication.login, payload, {headers: this.headers}).pipe
      (map((data: any) => {
        this.tokenService.setToken(data);

        return EmptyObservable.create();
    }),
    catchError(err => ErrorObservable.create(err)));
  }

  public Register(form: any) {
    let request = this.makeRequestOptions('POST', this.config.restApi.prefix +
    this.config.restApi.authentication.register, form);

    request = request.clone({headers: this.headers});

    this.http.request(request).pipe(
      map((data: any) => {
      this.tokenService.setToken(data);
  }));
  }

  protected makeRequestOptions(method, url, optional?): HttpRequest<any> {
    return new HttpRequest(method, url, optional);
  }
}
