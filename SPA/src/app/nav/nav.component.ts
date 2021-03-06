import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  values:any;
  constructor(public authService: AuthService, private alertify: AlertifyService, 
    private router: Router) { }

  ngOnInit() {
  }
  login(){
    this.authService.login(this.model).subscribe(next =>{
      this.alertify.success('Logged in succesfully');      
    }, error => {
      this.alertify.error(error);
    },() =>{
      this.router.navigate(['/members']);
    });
  }

  loggedIn(){
    return this.authService.loggedIn();
    /*const token = localStorage.getItem('token');
    return !!token;*/
  }

  logout(){
    localStorage.removeItem('token');
    this.alertify.message('logged out'); 
    this.router.navigate(['/home']);
  }
  Roulettes(){
    this.authService.GetRoulettes().subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
    };
}

