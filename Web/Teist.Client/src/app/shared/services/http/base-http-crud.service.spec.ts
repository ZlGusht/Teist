import { TestBed } from '@angular/core/testing';

import { BaseHttpCrudService } from './base-http-crud.service';

describe('BaseHttpCrudService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BaseHttpCrudService = TestBed.get(BaseHttpCrudService);
    expect(service).toBeTruthy();
  });
});
