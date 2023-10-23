import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';
import { Property } from 'src/app/model/property';
import { PropertyType } from 'src/app/model/PropertyType';
import { FurnishingType } from 'src/app/model/FurnishingType';

@Component({
  selector: 'app-edit-property',
  templateUrl: './edit-property.component.html',
  styleUrls: ['./edit-property.component.css']
})
export class EditPropertyComponent implements OnInit {
  editPropertyForm: FormGroup;
  property: Property;
  propertyTypes: PropertyType;
  furnishingTypes: FurnishingType;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    // Récupérer l'ID de la propriété depuis l'URL
    const propertyId = +this.route.snapshot.params['id'];

    // Appeler le service pour récupérer les données de la propriété
    this.housingService.getProperty(propertyId).subscribe(data => {
      this.property = data;
      console.log("prperty", this.property )
      this.initForm();
    });
  }

  initForm() {
    
    // Initialiser le formulaire avec les données de la propriété
    this.editPropertyForm = this.fb.group({
      sellRent: [this.property.sellRent, Validators.required],
      name: [this.property.name, Validators.required],
      price: [this.property.price, Validators.required],
      bhk: [this.property.bhk, Validators.required],
      builtArea: [this.property.builtArea, Validators.required],
       readyToMove: [this.property.readyToMove, Validators.required],
    });
  }

  onUpdate() {
    if (this.editPropertyForm.valid) {
      // Obtenir les données modifiées du formulaire
      const updatedData = this.editPropertyForm.value;
      updatedData.id = this.property.id;
      // Appeler le service pour mettre à jour la propriété
      this.housingService.updateProperty(updatedData).subscribe(() => {
        // Rediriger vers la liste des propriétés après la mise à jour réussie
        this.router.navigate(['/property-list']);
      }, error => {
        // Gérer les erreurs de mise à jour
        console.error(error);
        // Afficher un message d'erreur à l'utilisateur
      });
    } else {
      // Gérer les erreurs de validation du formulaire
      alert('Veuillez vérifier le formulaire pour des erreurs.');
    }
  }

  onCancel() {
    // Annuler la modification et revenir à la liste des propriétés
    this.router.navigate(['/property-list']);
  }
}
