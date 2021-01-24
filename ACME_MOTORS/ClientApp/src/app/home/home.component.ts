import { Component, OnInit } from '@angular/core';
import { OnlineService } from './../services/online.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  vehicles;

  constructor(private service:OnlineService)
  {}

  ngOnInit() {
    this.service.getVehicles().subscribe(data=>{
      this.vehicles=data
    })
  }

}
