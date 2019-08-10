import { TestBed } from '@angular/core/testing';

import { PieceDataService } from './piece-data.service';

describe('PieceDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PieceDataService = TestBed.get(PieceDataService);
    expect(service).toBeTruthy();
  });
});
