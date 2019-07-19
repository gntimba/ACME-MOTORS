import { Component, OnInit } from '@angular/core';
import { OnlineService } from '../services/online.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-truck',
  templateUrl: './truck.component.html',
  styleUrls: ['./truck.component.css']
})
export class TruckComponent implements OnInit {

  public form: FormGroup;
  Truck;
  Manufacturer;
  engine;
  TableRow;
  id
  clicked = false
  constructor(private service: OnlineService,private route: ActivatedRoute) { }

  ngOnInit() {

    this.get()
    this.getBoxes()
    this.form = new FormGroup({
      model: new FormControl("", [
        Validators.required,
        Validators.minLength(2)
      ]),
      year: new FormControl("", [
        Validators.required,
        Validators.min(1700),
        Validators.max(2019)
      ]),
      color: new FormControl("", [
        Validators.required
      ]),
      numberOfWheels: new FormControl("", [
        Validators.required
      ]),
      maximumLoad: new FormControl("", [
        Validators.required
      ]),
      quantityInStock: new FormControl("", [
        Validators.required,
        Validators.minLength(1)
      ]),
      manufacturerId: new FormControl("", [
        Validators.required
      ]),
      engineId: new FormControl("", [
        Validators.required
      ])
    })

  }
  get() {
    if(this.route.snapshot.paramMap.get("id")!=="#"){
    this.id=this.route.snapshot.paramMap.get("id")
    this.service.getTruck(this.id).subscribe(data => {
      this.Truck = data
      this.TableRow = Object.assign({}, data);
      this.clicked = true
      console.log(data)
    })}
  }
  onSubmit() {

    console.log(this.form.value)
    this.service.addTruck(this.form.value).subscribe(data => {
      this.get()
    })

  }
  getBoxes(){
    this.service.getManufacture().subscribe(data=>{
      this.Manufacturer=data
    })
    this.service.getEngine().subscribe(data=>{
      this.engine=data
    })

  }
  update() {
    this.service.updateTruck(this.TableRow).subscribe(data => {
      console.log(data)
      this.get()
    })

  }
  // getrow(row) {
  //   this.TableRow = Object.assign({},row);
  //   // tslint:disable-next-line: semicolon
  //   this.clicked = true
  // }
}
