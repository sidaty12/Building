import { IPropertyBase } from './ipropertybase';
import { Photo } from './Photo';

export class Property implements IPropertyBase {
  id: number;
  sellRent: number;
  name: string;
  propertyTypeId: number;
  propertyType: string;
  bhk: number;
  furnishingTypeId: number;
  furnishingType: string;
  price: number;
  builtArea: number;
  carpetArea?: number;
  address: string;
  address2?: string;
  CityId: number;
  city: string;
  floorNo?: string;
  totalFloors?: string;
  readyToMove: Boolean;
  age?: string;
  mainEntrance?: string;
  security?: number;
  gated?: boolean;
  maintenance?: number;
  estPossessionOn?: string;
  image?: string;
  description?: string;
  photos?: Photo[];
}
