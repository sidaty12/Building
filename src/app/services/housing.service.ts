import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Observable } from 'rxjs';
import { IProperty } from '../model/iproperty';
import { IPropertyBase } from '../model/ipropertybase';
import { Property } from '../model/property';
import { environment } from 'src/environments/environment';
import { Ikeyvaluepaire } from '../model/ikeyvaluepaire';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

 getAllCities(): Observable<string[]>{
    return this.http.get<string[]>(this.baseUrl + '/city/cities');
  }

  getPropertyTypes(): Observable<Ikeyvaluepaire[]>{
    return this.http.get<Ikeyvaluepaire[]>(this.baseUrl + '/propertytype/list');
  }

  getFurnishingTypes(): Observable<Ikeyvaluepaire[]>{
    return this.http.get<Ikeyvaluepaire[]>(this.baseUrl + '/furnishingtype/list');
  }

getProperty(id:number){
  return this.http.get<Property>(this.baseUrl + '/property/detail/'+ id.toString());

}

  getAllProperties(SellRent?: string): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseUrl + '/property/list/'+SellRent.toString());
 }

  addProperty(property: Property) {
    const httpOptions = {
      headers: new HttpHeaders ({
          Authorization: 'Bearer '+ localStorage.getItem('token')
       })
  };

    return this.http.post(this.baseUrl + '/property/add', property, httpOptions);
  }

  updateProperty(property: Property) {
    const httpOptions = {
        headers: new HttpHeaders({
            Authorization: 'Bearer ' + localStorage.getItem('token')
        })
    };
    return this.http.patch<Property>(`${this.baseUrl}/property/update/${property.id}`, property, httpOptions);
}

// Méthode pour obtenir les propriétés de l'utilisateur connecté
getUserProperties(): Observable<Property[]> {
  const httpOptions = {
      headers: new HttpHeaders({
          Authorization: 'Bearer ' + localStorage.getItem('token')
      })
  };
  return this.http.get<Property[]>(`${this.baseUrl}/property/userproperties`, httpOptions);
}


  deleteProperty(propertyId: number) {
    const httpOptions = {
        headers: new HttpHeaders({
            Authorization: 'Bearer '+ localStorage.getItem('token')
        })
    };
    return this.http.delete(`${this.baseUrl}/property/delete/${propertyId}`, httpOptions);

}


  newPropID(){
    if (localStorage.getItem('PID')) {
      localStorage.setItem('PID', String(+localStorage.getItem('PID') + 1));
      return +localStorage.getItem('PID');
    } else {
      localStorage.setItem('PID', '101');
      return 101;

    }
  }

  getPropertyAge(dateofEstablishment: string): string
    {
        const today = new Date();
        const estDate = new Date(dateofEstablishment);
        let age = today.getFullYear() - estDate.getFullYear();
        const m = today.getMonth() - estDate.getMonth();

        // Current month smaller than establishment month or
        // Same month but current date smaller than establishment date
        if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
            age --;
        }

        // Establshment date is future date
        if(today < estDate) {
            return '0';
        }

        // Age is less than a year
        if(age === 0) {
            return 'Less than a year';
        }

        return age.toString();
    }

    setPrimaryPhoto(propertyId: number, propertyPhotoId: string) {
      const httpOptions = {
          headers: new HttpHeaders({
              Authorization: 'Bearer '+ localStorage.getItem('token')
          })
      };
      return this.http.post(this.baseUrl + '/property/set-primary-photo/'+String(propertyId)
          +'/'+propertyPhotoId, {}, httpOptions);
  }

  deletePhoto(propertyId: number, propertyPhotoId: string) {
    const httpOptions = {
        headers: new HttpHeaders({
            Authorization: 'Bearer '+ localStorage.getItem('token')
        })
    };
    return this.http.delete(this.baseUrl + '/property/delete-photo/'
        +String(propertyId)+'/'+propertyPhotoId, httpOptions);
}

}
