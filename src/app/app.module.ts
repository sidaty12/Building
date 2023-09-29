import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CommonModule, DatePipe } from '@angular/common';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpErrorInterceptorService } from './services/httperor-interceptor.service';


import { AppComponent } from './app.component';
import { PropertyCardComponent } from './property/property-card/property-card.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertDetailComponent } from './property/property-detail/property-detail.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { PhotoEditorComponent } from './property/PhotoEditor/PhotoEditor.component';
//import { UserServiceService } from './services/user-service.service';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { PropertyDetailResolverService } from './property/property-detail/Property-detail-resolver.service';
import { FilterPipe } from './Pipes/filter.pipe';
import { SortPipe } from './Pipes/sort.pipe';
import { FileUploadModule } from 'ng2-file-upload';
import { EditPropertyComponent } from './property/edit-property/edit-property.component';
import { DashboardComponent } from './dashboard/dashboard.component';


const appRoutes: Routes = [
{path: '', component: PropertyListComponent},
{path: 'rent-property', component: PropertyListComponent},
{path: 'add-property', component: AddPropertyComponent},
{path: 'property-detail/:id',
                    component: PropertDetailComponent,
                    resolve: {prp: PropertyDetailResolverService}},
{path: 'user/login', component: UserLoginComponent},
{path: 'user/register', component: UserRegisterComponent},
{ path: 'dashboard', component: DashboardComponent },
{ path: 'edit-property/:id', component: EditPropertyComponent },
{path: '**', component: PropertyListComponent},
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
      PhotoEditorComponent,
      FilterPipe,
      SortPipe,
      EditPropertyComponent,
      DashboardComponent

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
    NgxGalleryModule,
    FileUploadModule




  ],
  providers: [

    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true
    },
    DatePipe,
    HousingService,
    AlertifyService,
    AuthService,
    PropertyDetailResolverService


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
