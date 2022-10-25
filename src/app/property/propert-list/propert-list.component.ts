import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { Observable } from "rxjs";
import { ActivatedRoute } from '@angular/router';
import { IpropertyBase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-propert-list',
  templateUrl: './propert-list.component.html',
  styleUrls: ['./propert-list.component.css']
})
export class PropertListComponent implements OnInit {
  // give a type array to properties because data a same type
SellRent = 1;
//properties: any;

 properties: IpropertyBase[];

  //injectd variabel to get the list of building
  constructor(private route: ActivatedRoute, private housingService: HousingService) { }

  ngOnInit() : void {
   if ( this.route.snapshot.url.toString()){
       this.SellRent = 2; // Means we are on reng-property URL else we are on base url
   }
     this.housingService.getAllProperties(this.SellRent).subscribe(
      data => {
         this.properties=data;
          console.log("data", data);
          console.log("SellRent", this.SellRent);

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
