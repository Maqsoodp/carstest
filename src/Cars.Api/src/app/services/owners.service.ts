import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import AppSettings from '../appSettings'

@Injectable()
export class OwnersService {

    constructor() {
    }

    getOwnersList = (type: string): Observable<any[]> => {

        return new Observable((observer: any) => {

            const myRequest = new Request(`${AppSettings.API_ENDPOINT}/owners/${type}`);
            fetch(myRequest)
                .then(response => {
                    if (response && response.status === 200) {
                        return response.json();
                    } else {
                        throw new Error('Something went wrong on api server!');
                    }
                }).then(response => {
                    let ownersInfo = (<any>response);
                    if (ownersInfo) {
                        observer.next(ownersInfo);
                    }
                }).catch(error => {
                    console.error(error);
                });
        });

    }


}