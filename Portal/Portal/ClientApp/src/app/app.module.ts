import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AverageSalaryComponent } from './average-salary/average-salary.component';
import { DetailedViewComponent } from './detailed-view/detailed-view.component';
import { DxAccordionModule, DxButtonModule, DxChartModule, DxCheckBoxModule, DxDataGridModule, DxDropDownBoxModule, DxFormModule, DxGalleryModule, DxPieChartModule, DxPopoverModule, DxPopupModule, DxScrollViewModule, DxSelectBoxModule, DxSliderModule, DxTabPanelModule, DxTabsModule, DxTagBoxModule, DxTemplateModule, DxTooltipModule, DxTreeViewModule } from 'devextreme-angular';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AverageSalaryComponent,
    DetailedViewComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    DxTabPanelModule,
    DxTreeViewModule,
    DxTemplateModule,
    DxTooltipModule,
    DxPopupModule,
    DxDataGridModule,
    DxButtonModule,
    FormsModule,
    DxFormModule,
    DxPopoverModule,
    DxGalleryModule,
    DxTabsModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    DxScrollViewModule,
    DxChartModule,
    DxDropDownBoxModule,
    DxAccordionModule,
    DxSliderModule,
    DxTagBoxModule,
    DxPieChartModule,  
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'average-salary', component: AverageSalaryComponent },
      { path: 'detailed-view', component: DetailedViewComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
