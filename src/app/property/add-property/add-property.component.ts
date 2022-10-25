import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Iproperty } from '../IProperty.interface';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
@ViewChild('Form') addPropertyForm: NgForm;
//@ViewChild('staticTabs', { static: false}) staticTabs: TabsetComponent;
@ViewChild('formTabs') formTabs : TabsetComponent;

SellRent ='1';
// Will come from masters
propertyType : Array<string> = ['House', 'Appartement', 'Duplex']
furnishType : Array<string> = ['Fully', 'Semi', 'Unfurnished']

propertyView : Iproperty={
  Id: null,
  Name:'',
  Price:null,
  SellRent : null,
  Type: null
};

  constructor(private router:Router) { }

  ngOnInit() {
    //this.addPropertyForm.controls['Name'].setValue('Default Value')
  }

  onBack()
  {
    this.router.navigate(['/']);
  }



  onSubmit(Form : NgForm){
    console.log('congrats, from submit');
    console.log(Form);
    console.log(this.addPropertyForm);

  }

  selectTab(tabId: number){
    this.formTabs.tabs[tabId].active = true;
  }
}
