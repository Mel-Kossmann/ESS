import { Component, Inject } from '@angular/core';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-average-salary-component',
  templateUrl: './average-salary.component.html'
})
export class AverageSalaryComponent {
  dataSource: any;
  CompanyForeignDataSource: any;

  constructor(@Inject('BASE_URL') baseUrl: string) {

    this.dataSource = this.dataSource = AspNetData.createStore({
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
