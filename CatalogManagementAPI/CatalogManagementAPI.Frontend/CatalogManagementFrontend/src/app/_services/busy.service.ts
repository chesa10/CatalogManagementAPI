import { inject, Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busiRequestCounter = 0;
  private spinnerService = inject(NgxSpinnerService);

  busy() {
    this.busiRequestCounter++;
    this.spinnerService.show(undefined, {
      type: 'ball-scale-multiple',
      bdColor: 'rgba(255, 255, 255,0)',
      color: '#333333'
    });
  }

  idle() {
    this.busiRequestCounter--;
    if (this.busiRequestCounter <= 0) {
      this.busiRequestCounter = 0;
      this.spinnerService.hide();
    }
  }
}