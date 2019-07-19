import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OnlineService } from '../services/online.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  public form: FormGroup;
  car;
  Manufacturer;
  engine;
  TableRow;
  id
  clicked = false
  constructor(private route: ActivatedRoute,private service: OnlineService) { }

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
      hasRustDamage: new FormControl("", [
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
    this.service.getCar(this.id).subscribe(data => {
      this.car = data
      this.TableRow = Object.assign({}, data);
      this.clicked = true
      console.log(data)
    })
  }
  }
  onSubmit() {
    console.log(this.form.value)
    this.service.addCar(this.form.value).subscribe(data => {
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
    this.service.updateCar(this.TableRow).subscribe(data => {
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
