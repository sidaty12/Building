import { Component, Input, OnInit } from '@angular/core';
import { Property } from 'src/app/model/property';

@Component({
  selector: 'app-PhotoEditor',
  templateUrl: './PhotoEditor.component.html',
  styleUrls: ['./PhotoEditor.component.css']
})
export class PhotoEditorComponent implements OnInit {
  @Input() property: Property;

  constructor() { }

  ngOnInit() {

  }

}
