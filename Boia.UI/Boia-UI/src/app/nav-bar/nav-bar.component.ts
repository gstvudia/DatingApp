import { Component, OnInit } from '@angular/core';
import { AuthService} from '../_services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(
      next => {
        console.log('success!');
      }, error => {
        console.log(error);
      }
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {

    localStorage.removeItem('token');
    console.log('logout');
  }
}
