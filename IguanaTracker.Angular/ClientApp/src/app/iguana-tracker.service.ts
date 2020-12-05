import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Iguana } from './iguana';

@Injectable({
  providedIn: 'root'
})
export class IguanaTrackerService {

  baseurl = "api/Home";

  private iguana: Iguana;

  constructor(private http: HttpClient) { }

  getIguanas(): void {

  }
}
