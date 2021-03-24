import { Component, Inject } from '@angular/core';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-add-company-component',
  templateUrl: './add-company.component.html'
})
export class AddCompanyComponent {
  dataSource: any;
  CompanyForeignDataSource: any;

  constructor(@Inject('BASE_URL') baseUrl: string) {

    this.dataSource = this.dataSource = AspNetData.createStore({
      key: 'id',
      loadUrl: baseUrl + 'api/Company',
      updateUrl: baseUrl + 'api/Company',
      insertUrl: baseUrl + 'api/Company',
      deleteUrl: baseUrl + 'api/Company'
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
