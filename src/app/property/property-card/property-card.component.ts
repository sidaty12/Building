import { Component, Input, OnInit } from '@angular/core';
import { IProperty } from 'src/app/model/iproperty';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { HousingService } from 'src/app/services/housing.service';


@Component({
  selector: 'app-property-card',
  // template: `<h1>I am a card</h1>`,
  templateUrl: 'property-card.component.html',
  // styles: ['h1 {font-weight: normal;}']
  styleUrls: ['property-card.component.css']
}

)
export class PropertyCardComponent implements OnInit {
  properties: IProperty[];

@Input() property: IPropertyBase;
@Input() hideIcons: boolean;

constructor(private housingService : HousingService){}
  ngOnInit(): void {
  }

deleteProperty(propertyId: number) {
  this.housingService.deleteProperty(propertyId).subscribe(
    data => {
      console.log(data);
      // Mettre à jour la liste des propriétés ici si nécessaire
    },
    error => console.log(error)
  );
}

isLoggedIn(): boolean {
  return !!localStorage.getItem('userName');
}
}
