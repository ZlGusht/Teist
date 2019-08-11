import { Injectable, Inject } from '@angular/core';
import { map } from 'rxjs/operators';

import { HttpRequest, HttpClient, HttpResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { TokenService } from '../token/token.service';
import { BaseEntity } from '../../models/contracts/base-entity.interface';

@Injectable()
export abstract class BaseHttpCrudService<TEntity extends BaseEntity> {

  /**
   * The headers which would be applied to every Request
   */
  protected headers: HttpHeaders;

  /**
   * The base URL of the API we would request to
   */
  protected apiUrl: string;

  constructor(protected httpClient: HttpClient,
              protected baseUrl: string,
              private readonly tokenService: TokenService) {
    this.headers = new HttpHeaders();

    // Set all base headers
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.apiUrl = baseUrl;
  }

  /**
   * Executes a request with the specified request options
   */
  public request<TResult>(requestOptions: HttpRequest<TResult>): Promise<TResult> {
    if (this.tokenService.isLoggedIn) {
      if (this.headers.has('Authorization')) {
        this.headers = this.headers.set('Authorization', `Bearer ${this.tokenService.token}`);
      } else {
        this.headers = this.headers.append('Authorization', `Bearer ${this.tokenService.token}`);
      }
    }

    // Applies base headers
    requestOptions = requestOptions.clone({headers: this.headers});

    return this.httpClient.request(requestOptions).pipe(
      map((res: HttpResponse<TResult>) => {
        return res.body;
      }))
      .toPromise<TResult>();
  }

  /**
   * Get an entity by ID
   * @param id - the ID of the searched entity
   * @param searchString - optional param for a searchString to be applied to the
   * GET request
   */
  // TODO: Id type should be generic
  public get(id: number | string, searchString?: string) {
    const url = `${this.apiUrl}/${id}`;
    const request = this.makeRequestOptions('GET', url);

    return this.request<TEntity>(request);
  }

  /**
   * Gets all entities
   */
  public getAll(searchString?: string): Promise<TEntity[]> {
    let parameters = new HttpParams();

    if (searchString) {
      parameters = parameters.set('filter', searchString);
    }

    const request = this.makeRequestOptions('GET', this.apiUrl, { params: parameters });

    return this.request<TEntity[]>(request);
  }

  /**
   * Create an entity
   * @param entity - the entity to be created
   */
  public create(entity: TEntity) {
    const request = this.makeRequestOptions('POST', this.apiUrl, entity);

    // TODO: Id type should be generic
    return this.request<number | string>(request);
  }

  /**
   * Updates an entity
   * @param entity - the updated entity
   */
  public update(name: string, entity: TEntity) {
    const url = `${this.apiUrl}/${name}`;

    const request = this.makeRequestOptions('PUT', url, entity);

    return this.request<void>(request);
  }

  /**
   * Deletes the supplied entity from the REST API
   * @param entity - the entity to be deleted
   */
  public delete(id: string) {
    const url = `${this.apiUrl}/${id}`;

    const request = this.makeRequestOptions('DELETE', url);

    return this.request<void>(request);
  }

  /**
   * Makes a Request object with the given options
   * @param options - the request options
   */
  protected makeRequestOptions(method, url, optional?): HttpRequest<any> {
    return new HttpRequest(method, url, optional);
  }

}
