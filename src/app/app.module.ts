import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CommonModule } from '@angular/common';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { PropertyCardComponent } from './property/property-card/property-card.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertDetailComponent } from './property/property-detail/property-detail.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserServiceService } from './services/user-service.service';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { PropertyDetailResolverService } from './property/property-detail/Property-detail-resolver.service';
import { FilterPipe } from './Pipes/filter.pipe';
import { SortPipe } from './Pipes/sort.pipe';


const appRoutes: Routes = [
{path: '', component: PropertyListComponent},
{path: 'rent-property', component: PropertyListComponent},
{path: 'add-property', component: AddPropertyComponent},
{path: 'property-detail/:id',
                    component: PropertDetailComponent,
                    resolve: {prp: PropertyDetailResolverService}}, // , resolve: {prp: PropertyDetailResolverService}},
{path: 'user/login', component: UserLoginComponent},
{path: 'user/register', component: UserRegisterComponent},
{path: '**', component: PropertyListComponent}
// tslint:disable-next-line: align
];

@NgModule({
  declarations: [
    AppComponent,
    PropertyCardComponent,
      NavBarComponent,
      AddPropertyComponent,
      PropertDetailComponent,
      UserLoginComponent,
      UserRegisterComponent,
      PropertyListComponent,
      FilterPipe,
      SortPipe

   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    CommonModule,
    NgxGalleryModule




  ],
  providers: [
    HousingService,
    UserServiceService,
    AlertifyService,
    AuthService,
    PropertyDetailResolverService


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
