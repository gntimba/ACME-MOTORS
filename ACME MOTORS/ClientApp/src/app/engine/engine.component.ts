import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OnlineService } from '../services/online.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-engine',
  templateUrl: './engine.component.html',
  styleUrls: ['./engine.component.css']
})
export class EngineComponent implements OnInit {
  public form: FormGroup;
  Engine;
  ManufacturerName;
  TableRow;
  clicked = false
  constructor(private service: OnlineService,private toastr: ToastrService) { }

  ngOnInit() {
    this.getEngine()
    this.getManufacture()
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
      fuelType: new FormControl("", [
        Validators.required
      ]),
      size: new FormControl("", [
        Validators.required,
        Validators.minLength(1)
      ]),
      mileage: new FormControl("", [
        Validators.required,
        Validators.minLength(1)
      ]),
      manufacturerId: new FormControl("", [
        Validators.required
      ])


    })

  }
  getManufacture() {
    this.service.getManufacture().subscribe(data => {
      this.ManufacturerName = data;
      console.log(data)
    })
  }
  getEngine() {
    this.service.getEngine().subscribe(data => {
      this.Engine = data;
      console.log(data)
    })
  }
  onSubmit() {
    console.log(this.form.value)
    this.service.addEngine(this.form.value).subscribe(data => {
      this.toastr.success('Add successfully', 'Update');
      this.getEngine()
    })

  }
  update() {
  this.service.updateEngine(this.TableRow).subscribe(data=>{
    this.toastr.success('Updated successfully', 'Update');
    console.log(data)
    this.getEngine()
  })

  }
  getrow(row) {
    this.TableRow = Object.assign({},row);
    // tslint:disable-next-line: semicolon
    this.clicked = true
  }

}
