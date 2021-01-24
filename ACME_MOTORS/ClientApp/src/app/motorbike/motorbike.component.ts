import { Component, OnInit } from '@angular/core';
import { OnlineService } from '../services/online.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-motorbike',
  templateUrl: './motorbike.component.html',
  styleUrls: ['./motorbike.component.css']
})
export class MotorbikeComponent implements OnInit {

  public form: FormGroup;
  motorBike;
  Manufacturer;
  engine;
  TableRow;
  id
  clicked = false
  constructor(private route: ActivatedRoute,private service: OnlineService,private toastr: ToastrService) { }

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
      hasWindVisor: new FormControl("", [
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
    this.service.getMoto(this.id).subscribe(data => {
      this.motorBike = data
      this.TableRow = Object.assign({}, data);
      this.clicked = true
      console.log(data)
    })}
  }
  onSubmit() {
    console.log(this.form.value)
    this.service.addMoto(this.form.value).subscribe(data => {
      this.toastr.success('Add successfully', 'Update');
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
    this.service.updateMoto(this.TableRow).subscribe(data => {
      this.toastr.success('Updated successfully', 'Update');
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
