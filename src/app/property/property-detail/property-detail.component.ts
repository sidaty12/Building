import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})
export class PropertDetailComponent implements OnInit {

  public propertyId: number;
  constructor(private route: ActivatedRoute, private router: Router) { }

  // we want to change the id so we'll schoud use subscribe

  ngOnInit() {
    this.propertyId = +this.route.snapshot.params['id'];

    this.route.params.subscribe(
      (params) => {
        this.propertyId = +params['id'];
      }
    )
  }
  onSelectNext(){

    this.propertyId +=1;
    this.router.navigate(['propert-detail', this.propertyId] );

  }
}
