import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token } from '@angular/compiler/src/ml_parser/lexer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Roulette Online';
  jwtHelper = new JwtHelperService();
  constructor(private authService: AuthService){}

  ngOnInit(){
    const token = localStorage.getItem('token');
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    } 
  }
  //registerMode = false;
  //@Input() VistaMod:any;
    //this.registerMode = this.VistaMod;
  
}
