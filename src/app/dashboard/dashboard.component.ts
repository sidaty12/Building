import { Component, OnInit } from '@angular/core';
import { Property } from '../model/property';
import { HousingService } from '../services/housing.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  
  properties: Property[] = []; 

  constructor(private housingService : HousingService) {}

  ngOnInit(): void {
    this.loadUserProperties();
  }

  loadUserProperties(): void {
    this.housingService.getUserProperties().subscribe(data => {
      this.properties = data;
    });
  }
}
