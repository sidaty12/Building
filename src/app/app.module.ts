import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import{Routes, RouterModule} from '@angular/router'

import { AppComponent } from './app.component';
import { PropertyCardComponent } from './property/property-card/property-card/property-card.component';
import { PropertListComponent } from './property/propert-list/propert-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';


const appRoutes: Routes = [
  {path: '', component: PropertListComponent},
  {path: 'rent-property', component: PropertListComponent},
  {path: 'add-property', component: AddPropertyComponent},
  //{path: 'property-detail/:id', component: PropertyDetailComponent, resolve: {prp: PropertyDetailResolverService}},
  ////{path: 'user/login', component: UserLoginComponent},
 // {path: 'user/register', component: UserRegisterComponent},
  {path: '**', component: PropertListComponent}
];@NgModule({
  declarations: [
    AppComponent,
    PropertyCardComponent,
    PropertListComponent,
      NavBarComponent,
      AddPropertyComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)

  ],
  providers: [
    HousingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
