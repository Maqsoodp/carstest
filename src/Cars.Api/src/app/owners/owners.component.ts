import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { OwnersService } from '../services/owners.service';
// import "rxjs/core/operator/of";

@Component({
  selector: 'owners',
  templateUrl: './owners.component.html',
  styleUrls: ['./owners.component.css']
})
export class OwnersComponent implements OnInit {
  ownersObservable: Observable<any[]>;

  constructor(private ownersService: OwnersService) { }

  ngOnInit() {
    this.getExternalList();
  }

  private getExternalList(){
    this.ownersObservable = this.ownersService.getOwnersList("external");
  }

  showExternal(event) {
    this.getExternalList();
  }

  showInternal(event) {
    this.ownersObservable = this.ownersService.getOwnersList("internal");
  }

}
