import { Injectable } from '@angular/core';
import { DatePipe } from '@angular/common';

@Injectable({
    providedIn: 'root'
  })

export class DateHelper {

  constructor( private datePipe: DatePipe) {}

    extractDateFromString(date: string) {
      let year = parseInt(date.split('-')[0]);
      let month = parseInt(date.split('-')[1]);
      let day = parseInt(date.split('-')[2].slice(0,2));
      let deadline = new Date(year, month-1, day);
      return this.datePipe.transform(deadline, 'yyyy-MM-dd');
    }
}