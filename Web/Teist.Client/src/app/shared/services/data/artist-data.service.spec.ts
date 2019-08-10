import { TestBed } from '@angular/core/testing';

import { ArtistDataService } from './artist-data.service';

describe('ArtistDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ArtistDataService = TestBed.get(ArtistDataService);
    expect(service).toBeTruthy();
  });
});
