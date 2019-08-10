import { Injectable } from '@angular/core';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { Configuration } from '../../config/app.config';
import { HttpClient } from '@angular/common/http';
import { TokenService } from '../token/token.service';
import { Piece } from '../../models/piece';

@Injectable({
  providedIn: 'root'
})
export class PieceDataService extends BaseHttpCrudService<Piece> {
  
  private config = Configuration;

  constructor(private http: HttpClient, private token: TokenService) {
    super(http, Configuration.restApi.prefix + Configuration.restApi.piece, token);
   }
}
