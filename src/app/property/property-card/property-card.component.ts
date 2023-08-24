import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IProperty } from 'src/app/model/iproperty';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { HousingService } from 'src/app/services/housing.service';
import { AuthService } from 'src/app/services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-property-card',
  // template: `<h1>I am a card</h1>`,
  templateUrl: 'property-card.component.html',
  // styles: ['h1 {font-weight: normal;}']
  styleUrls: ['property-card.component.css']
}

)
export class PropertyCardComponent implements OnInit {
 

@Input() property: IPropertyBase;
@Input() hideIcons: boolean;
@Output() propertyDeleted = new EventEmitter<void>();


constructor(private housingService : HousingService, private authService: AuthService, 
  private alertify : AlertifyService){}
  ngOnInit(): void {
  }

deleteProperty(propertyId: number) {
  this.housingService.deleteProperty(propertyId).subscribe(
    (data) => {
      this.alertify.success("Property deleted successfully!");
      this.propertyDeleted.emit();
      console.log(data);
     },
    
    error => {
      console.log(error);
    this.alertify.error("Ops You are not authorized to delete this property");
    });
}

isLoggedIn() : boolean {
  return this.authService.isLoggedIn();
}

}
