import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';
import { PropertListComponent } from '../property/propert-list/propert-list.component';
import { map } from 'rxjs/operators';
import { Iproperty } from '../property/IProperty.interface';

@Injectable({
  providedIn: 'root'
})
export class HousingService {

constructor(private http:HttpClient) { }
// pipe and map are used to add un empty array which we
// will able to push item
getAllProperties(SellRent: number) : Observable<Iproperty[]> {
  return this.http.get('data/propreties.json').pipe(
    map(data => {
      const propertiesArray: Array<Iproperty> = [];

      for (const id in data) {
        if(data.hasOwnProperty(id) && data[id].SellRent === SellRent ) {
          propertiesArray.push(data[id]);
        }
      }
      return propertiesArray;
    } )
  );
}

}
/*
: Observable<PropertListComponent["properties"][]>{
  return this.http.get<PropertListComponent["properties"][]>('data/propreties.json')

}
*/
