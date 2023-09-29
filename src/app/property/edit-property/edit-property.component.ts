import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TabsetComponent } from 'ngx-bootstrap/tabs/public_api';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { DatePipe } from '@angular/common';
import { Ikeyvaluepaire } from 'src/app/model/ikeyvaluepaire';

@Component({
  selector: 'app-edit-property',
  templateUrl: './edit-property.component.html',
  styleUrls: ['./edit-property.component.css']
})
export class EditPropertyComponent implements OnInit {
  @ViewChild('formTabs') formTabs: TabsetComponent;
  editPropertyForm: FormGroup;
  property: Property;

  propertyTypes: Ikeyvaluepaire[];
  furnishTypes: Ikeyvaluepaire[];
  CityList : any[];

  constructor(
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private fb: FormBuilder,
    private router: Router,
    private housingService: HousingService,
    private alertify: AlertifyService
  ) { }

  ngOnInit() {
    const propertyId = +this.route.snapshot.params['id'];

    this.housingService.getProperty(propertyId).subscribe(data => {
      this.property = data;
      this.initForm();
    });

    this.housingService.getAllCities().subscribe(data => {
      this.CityList = data;
    });

    this.housingService.getPropertyTypes().subscribe(data => {
      this.propertyTypes = data;
    });

    this.housingService.getFurnishingTypes().subscribe(data => {
      this.furnishTypes = data;
    });
  }

  initForm() {
    this.editPropertyForm = this.fb.group({
      BasicInfo: this.fb.group({
        SellRent: [this.property.sellRent, Validators.required],
        BHK: [this.property.bhk, Validators.required],
        PType: [this.property.propertyTypeId, Validators.required],
        FType: [this.property.furnishingTypeId, Validators.required],
        Name: [this.property.name, Validators.required],
        City: [this.property.CityId, Validators.required]
      }),
      PriceInfo: this.fb.group({
        Price: [this.property.price, Validators.required],
        BuiltArea: [this.property.builtArea, Validators.required],
        CarpetArea: [this.property.carpetArea],
        Security: [this.property.security],
        Maintenance: [this.property.maintenance]
      }),
      AddressInfo: this.fb.group({
        FloorNo: [this.property.floorNo],
        TotalFloor: [this.property.totalFloors],
        Address: [this.property.address, Validators.required],
        LandMark: [this.property.address2]
      }),
      OtherInfo: this.fb.group({
        RTM: [this.property.readyToMove, Validators.required],
        PossessionOn: [this.datePipe.transform(this.property.estPossessionOn, 'MM/dd/yyyy'), Validators.required],
      //  AOP: [this.property.aop],
        Gated: [this.property.gated],
        MainEntrance: [this.property.mainEntrance],
        Description: [this.property.description]
      })
    });
  }

  onUpdate() {
    if (this.editPropertyForm.valid) {
      this.property = Object.assign(this.property, this.editPropertyForm.value);
      this.housingService.updateProperty(this.property).subscribe(() => {
        this.alertify.success('La propriété a été mise à jour avec succès.');
        this.router.navigate(['/property-list']);
      }, error => {
        this.alertify.error('Une erreur s\'est produite lors de la mise à jour de la propriété.');
      });
    } else {
      this.alertify.error('Veuillez vérifier le formulaire pour des erreurs.');
    }
  }

  onCancel() {
    this.router.navigate(['/property-list']);
  }
}
