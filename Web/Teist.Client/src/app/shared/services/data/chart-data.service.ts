import { Injectable } from '@angular/core';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { Chart } from '../../models/chart';
import { Configuration } from '../../config/app.config';
import { TokenService } from '../token/token.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChartDataService extends BaseHttpCrudService<Chart> {

  private config = Configuration;

  constructor(private http: HttpClient, private token: TokenService) {
    super(http, Configuration.restApi.prefix + Configuration.restApi.chart, token);
   }
}
