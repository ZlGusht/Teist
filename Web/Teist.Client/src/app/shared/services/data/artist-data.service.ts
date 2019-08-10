import { Injectable } from '@angular/core';
import { Configuration } from '../../config/app.config';
import { TokenService } from '../token/token.service';
import { HttpClient } from '@angular/common/http';
import { BaseHttpCrudService } from '../http/base-http-crud.service';
import { Artist } from '../../models/artist';

@Injectable({
  providedIn: 'root'
})
export class ArtistDataService extends BaseHttpCrudService<Artist> {
  
  private config = Configuration;

  constructor(private http: HttpClient, private token: TokenService) {
    super(http, Configuration.restApi.prefix + Configuration.restApi.artist, token);
   }
}
