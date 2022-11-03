import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  transform(value: Array<string>, args: any[]): any {
     const sortField = args[0];
     const sortDirection =args[1];
     let multipier = 1;

     if (sortDirection === 'desc'){
       multipier = -1;
     }

     if (value){
      value?.sort((a:any, b:any) => {
        if (a[sortField] < b[sortField]){
          return -1 * multipier;
        } else if (a[sortField] > b[sortField]) {
          return 1 * multipier;
        } else {
          return 0;
        }
       });
       return value;
     }

  }

};
