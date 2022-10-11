import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-propert-list',
  templateUrl: './propert-list.component.html',
  styleUrls: ['./propert-list.component.css']
})
export class PropertListComponent implements OnInit {
  properties: Array<any> = [
    {
    "Id": 1,
    "Name":"Birla House",
    "Type":"House",
    "Price":12000
    },
    {
      "Id": 2,
      "Name":"Erose Villa",
      "Type":"House",
      "Price":15000
      },
      {
        "Id": 3,
        "Name":"Pearl White House",
        "Type":"House",
        "Price":18000
        },
        {
        "Id": 3,
        "Name":"Pearl White House",
        "Type":"House",
        "Price":18000
        },
        {
          "Id": 3,
          "Name":"Pearl White House",
          "Type":"House",
          "Price":18000
          },
          {
            "Id": 3,
            "Name":"Pearl White House",
            "Type":"House",
            "Price":18000
            }
]
  constructor() { }

  ngOnInit() {
  }

}
