import { Component, Inject } from '@angular/core';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  dataSource: any;
  CompanyForeignDataSource: any;

  constructor(@Inject('BASE_URL') baseUrl: string) {

    this.dataSource = this.dataSource = AspNetData.createStore({
      key: 'id',
      loadUrl: baseUrl + 'api/Salary'
    });

    this.CompanyForeignDataSource = {
      store: AspNetData.createStore({
        key: 'id',
        loadUrl: baseUrl + 'api/Company',
      }),
      pagenate: true
    }
  }
}
