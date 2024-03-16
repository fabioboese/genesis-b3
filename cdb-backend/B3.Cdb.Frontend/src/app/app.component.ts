import { Component } from '@angular/core';
import { Operation } from './model/operation';
import { CdbService } from './services/cdb-service';
import { Position } from './model/position';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'B3.Cdb.Frontend';
  operation = new Operation();
  showResults = false;

  grosssValue = 0;
  tax = 0;
  netValue = 0;
  constructor(private service : CdbService) {
    
  }

  reset() {
    this.showResults = false;
  }

  calculateOperation() {
    this.service.calculatePosition(this.operation)
      .subscribe(pos =>{
        this.grosssValue = pos.grossValue;
        this.tax = pos.incomeTax;
        this.netValue = pos.netValue;
        this.showResults = true;
      });
  }

}
