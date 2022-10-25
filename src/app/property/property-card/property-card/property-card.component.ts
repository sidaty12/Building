import { Component, Input, OnInit } from '@angular/core';
import { Iproperty } from '../../IProperty.interface';
@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.css']
})
export class PropertyCardComponent implements OnInit {
@Input() property : Iproperty;

  constructor() { }

  ngOnInit() {
  }

}
