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

}

