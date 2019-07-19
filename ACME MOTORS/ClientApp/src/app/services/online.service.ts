import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Manufacture } from '../model/manufacture.model';

@Injectable({
  providedIn: 'root'
})
export class OnlineService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  // Manufacture
  ManuUrl = 'api/Manufacturer/';
  EngineUrl = 'api/Engine/';
   CarUrl = 'api/Car/';
   TruckUrl = 'api/Truck/';
   MotoUrl = 'api/Motorbike/';
  getManufacture() {
    return this.http.get(this.baseUrl + this.ManuUrl)
  }
  addManufacture(data) {
    return this.http.post(this.baseUrl + this.ManuUrl, data)
  }
  updateManufacture(data) {
    return this.http.put(this.baseUrl + this.ManuUrl + data.id, data)
  }

  // Engine

  getEngine() {
    return this.http.get(this.baseUrl + this.EngineUrl)
  }
  addEngine(data) {
    return this.http.post(this.baseUrl + this.EngineUrl, data)
  }
  updateEngine(data) {
    return this.http.put(this.baseUrl + this.EngineUrl + data.id, data)
  }

    // Car

    getCar(id) {
      return this.http.get(this.baseUrl + this.CarUrl+id)
    }
    addCar(data) {
      return this.http.post(this.baseUrl + this.CarUrl, data)
    }
    updateCar(data) {
      return this.http.put(this.baseUrl + this.CarUrl + data.id, data)
    }

      // Truck

  getTruck(id) {
    return this.http.get(this.baseUrl + this.TruckUrl+id)
  }
  addTruck(data) {
    return this.http.post(this.baseUrl + this.TruckUrl, data)
  }
  updateTruck(data) {
    return this.http.put(this.baseUrl + this.TruckUrl + data.id, data)
  }
    // Motorbike

    getMoto(id) {
      return this.http.get(this.baseUrl + this.MotoUrl+id)
    }
    addMoto(data) {
      return this.http.post(this.baseUrl + this.MotoUrl, data)
    }
    updateMoto(data) {
      return this.http.put(this.baseUrl + this.MotoUrl + data.id, data)
    }

}

