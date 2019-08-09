import { Injectable } from '@angular/core';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { HttpClient } from '@angular/common/http';
import { Configuration } from '../../config/app.config';
import { TokenService } from '../token/token.service';
import { Album } from '../../models/album';

@Injectable({
  providedIn: 'root'
})
export class AlbumDataService extends BaseHttpCrudService<Album> {

  private config = Configuration;

  constructor(private http: HttpClient, private token: TokenService) {
    super(http, Configuration.restApi.prefix + Configuration.restApi.album, token);
   }
}
