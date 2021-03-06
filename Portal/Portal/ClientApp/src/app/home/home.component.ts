import { Component,Inject } from '@angular/core';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  dataSource: any;
  CompanyForeignDataSource: any;

  constructor(@Inject('BASE_URL') baseUrl: string) {

    this.dataSource = this.dataSource = AspNetData.createStore({
      key: 'id',
      loadUrl: baseUrl + 'api/Employee',
      updateUrl: baseUrl + 'api/Employee',
      insertUrl: baseUrl + 'api/Employee',
      deleteUrl: baseUrl + 'api/Employee'
    });

    this.CompanyForeignDataSource = {
      store: AspNetData.createStore({
        key: 'id',
        loadUrl: baseUrl + 'api/Company',
      }),
      pagenate:true
    }
  }

}
