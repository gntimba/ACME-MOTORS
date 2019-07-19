import { Component, OnInit } from '@angular/core';
import { OnlineService } from '../services/online.service';
import { Manufacture } from '../model/manufacture.model';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-manufacture',
  templateUrl: './manufacture.component.html',
  styleUrls: ['./manufacture.component.css']
})
export class ManufactureComponent implements OnInit {
  public form: FormGroup;
  manufacture: Manufacture;
  ManufacturerName;
  TableRow: Manufacture;
  clicked = false
  constructor(private service: OnlineService) { }

  ngOnInit() {

    this.get()
    this.form = new FormGroup({
      Name: new FormControl("", [
        Validators.required,
        Validators.minLength(2)
      ])
    })

  }
  get() {
    this.service.getManufacture().subscribe(data => {
      this.manufacture = data as Manufacture;
      console.log(data)
    })
  }
  onSubmit() {
    console.log(this.form.value)
    this.service.addManufacture(this.form.value).subscribe(data => {
      this.get()
    })

  }
  update() {
  this.service.updateManufacture(this.TableRow).subscribe(data=>{
    console.log(data)
    this.get()
  })

  }
  getrow(row) {
    this.TableRow = Object.assign({},row);
    // tslint:disable-next-line: semicolon
    this.clicked = true
  }

}
