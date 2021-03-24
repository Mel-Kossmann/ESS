import { Component, Inject } from '@angular/core';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-about-us-component',
  templateUrl: './about-us.component.html'
})
export class AboutUsComponent {

  constructor(@Inject('BASE_URL') baseUrl: string) {
    
  }
}
