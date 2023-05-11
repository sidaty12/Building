export interface  IPropertyBase {

  id: number;
  sellRent: string;
  name: string;
  propertyType: string;
  furnishingType: string;
  price: number;
  bhk: number;
  builtArea: number;
  city : string;
  readyToMove: Boolean;
  photo?: string;
  estPossessionOn?: string;


}
