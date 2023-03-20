import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public demos: Demo[] = []

  //public demo: Demo = new Demo(name)
  //public demo: Demo = ""

  public pageName: string = "Bitch ass mtfkr"

  //constructor(http: HttpClient, @Inject('Base_URL') baseUrl: string) {
  //  http.get<Demo>(baseUrl + 'demo').subscribe(result => {
  //    this.demo = result;
  //  }, error => console.error(error));
  //}

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Demo[]>(baseUrl + 'Demo').subscribe(result => {
      this.demos = result;
    }, error => console.error(error));
  }
}

interface Demo {
  name: string;
}
