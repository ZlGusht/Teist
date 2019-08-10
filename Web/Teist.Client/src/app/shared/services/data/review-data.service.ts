import { Injectable } from '@angular/core';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { Configuration } from '../../config/app.config';
import { TokenService } from '../token/token.service';
import { HttpClient } from '@angular/common/http';
import { Review } from '../../models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewDataService extends BaseHttpCrudService<Review> {

  private config = Configuration;

  constructor(private http: HttpClient, private token: TokenService) {
    super(http, Configuration.restApi.prefix + Configuration.restApi.review, token);
   }
}
