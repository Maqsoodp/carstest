import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { CarsService } from '../services/cars.service';

@Component({
  selector: 'cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  carsObservable: Observable<any[]>;
  listype: string = "list"

  constructor(private carService: CarsService) { }

  ngOnInit() {
    this.getCarList();
  }

  private getCarList(){
    this.carsObservable = this.carService.getCarsList();
  }

  showCars(event, type) {
    this.listype = type;
    this.getCarList();
  }

  showCarsGrouped(event, type) {
    this.listype = type;
    this.carsObservable = this.carService.getCarsGroupedList();
  }

}
