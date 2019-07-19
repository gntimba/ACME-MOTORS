import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OnlineService {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }
  // Manufacture

}
