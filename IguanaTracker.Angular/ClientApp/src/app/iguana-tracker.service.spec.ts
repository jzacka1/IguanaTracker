import { TestBed } from '@angular/core/testing';

import { IguanaTrackerService } from './iguana-tracker.service';

describe('IguanaTrackerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: IguanaTrackerService = TestBed.get(IguanaTrackerService);
    expect(service).toBeTruthy();
  });
});
