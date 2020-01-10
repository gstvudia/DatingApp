import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.css']
})
export class HomeComponent implements OnInit {
  RegisterMode = false;
  values: any;
 
  constructor(private http: HttpClient) { }

  ngOnInit() {

  }

  registerToggle() {
    this.RegisterMode = !this.RegisterMode;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.RegisterMode = registerMode;
  }
}
