import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Configuration } from '../../config/app.config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private config = Configuration;

  private headers = new HttpHeaders().set('Content-Type', 'application/json');

  private httpRequest: HttpRequest<any>;

  constructor(private http: HttpClient) {
    console.log(this.headers.get('Content-Type'), 'maika ti');
  }

  public LogIn(form: any) {
    let request = this.makeRequestOptions('POST', this.config.restApi.prefix +
    this.config.restApi.authentication.login, form);

    request = request.clone({headers: this.headers})

    this.http.request(request).subscribe(value => {console.log(value)});
  }

  public Register(form: any) {
    let request = this.makeRequestOptions('POST', this.config.restApi.prefix +
    this.config.restApi.authentication.register, form);

    request = request.clone({headers: this.headers})

    this.http.request(request).subscribe(value => {console.log(value)});
  }

  protected makeRequestOptions(method, url, optional?): HttpRequest<any> {
    return new HttpRequest(method, url, optional);
  }
}
