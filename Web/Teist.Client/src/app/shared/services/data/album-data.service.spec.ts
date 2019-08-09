import { TestBed } from '@angular/core/testing';

import { AlbumDataService } from './album-data.service';

describe('AlbumDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AlbumDataService = TestBed.get(AlbumDataService);
    expect(service).toBeTruthy();
  });
});
