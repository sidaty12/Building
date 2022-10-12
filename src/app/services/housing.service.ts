import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';
import { PropertListComponent } from '../property/propert-list/propert-list.component';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

constructor(private http:HttpClient) { }

public getAllProperties(){
  return this.http.get('data/propreties.json')
}

}
/*
: Observable<PropertListComponent["properties"][]>{
  return this.http.get<PropertListComponent["properties"][]>('data/propreties.json')

}
*/
