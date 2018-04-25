import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import AppSettings from '../appSettings'

@Injectable()
export class CarsService {

    constructor() {
    }

    getCarsList = (): Observable<any[]> => {

        return new Observable((observer: any) => {

            const myRequest = new Request(`${AppSettings.API_ENDPOINT}/cars`);
            fetch(myRequest)
                .then(response => {
                    if (response && response.status === 200) {
                        return response.json();
                    } else {
                        throw new Error('Something went wrong on api server!');
                    }
                }).then(response => {
                    let carsInfo = (<any>response);
                    if (carsInfo) {
                        observer.next(carsInfo);
                    }
                }).catch(error => {
                    console.error(error);
                });
        });

    }

    getCarsGroupedList = (): Observable<any[]> => {

        return new Observable((observer: any) => {

            const myRequest = new Request(`${AppSettings.API_ENDPOINT}/cars/GetOwnersGroupByCarsOrderedByColorAsync`);
            fetch(myRequest)
                .then(response => {
                    if (response && response.status === 200) {
                        return response.json();
                    } else {
                        throw new Error('Something went wrong on api server!');
                    }
                }).then(response => {
                    let carsGrouped = (<any>response);
                    if (carsGrouped) {
                        observer.next(carsGrouped);
                    }
                }).catch(error => {
                    console.error(error);
                });
        });

    }

}