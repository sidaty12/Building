import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { Observable } from "rxjs";
import { Iproperty } from '../IProperty.interface';

@Component({
  selector: 'app-propert-list',
  templateUrl: './propert-list.component.html',
  styleUrls: ['./propert-list.component.css']
})
export class PropertListComponent implements OnInit {
  // give a type array to properties because data a same type
 properties: Array<Iproperty>;

  //injectd variabel to get the list of building
  constructor(private housingService: HousingService) { }

  ngOnInit() : void{

     this.housingService.getAllProperties().subscribe(
      data => {
         this.properties=data;
          console.log("data", data);
      }, error => {
        console.log(error);
      }
     )
     // data => {
       // this.properties=data;
          //console.log("data", data)
       // }
  //  )
  /*   data => {
      this.properties=data;
        console.log("data", data)
      }
    )
  }*/

  }

}
