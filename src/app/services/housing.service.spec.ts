/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HoustingService } from './housing.service';

describe('Service: Housting', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HoustingService]
    });
  });

  it('should ...', inject([HoustingService], (service: HoustingService) => {
    expect(service).toBeTruthy();
  }));
});
