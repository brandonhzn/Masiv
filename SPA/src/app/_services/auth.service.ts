import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from "rxjs/operators";
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient) { }
baseUrl = 'http://localhost:5000/api/auth/';
RoulettesUrl = 'http://localhost:5000/api/roulette/';
jwtHelper = new JwtHelperService();
decodedToken : any;

login(model:any){
  
  return this.http.post(this.baseUrl+'login',model).pipe(
    map((response: any)=>{
    const user = response;
    if(user){
      localStorage.setItem('token',user.token);
      this.decodedToken = this.jwtHelper.decodeToken(user.token);
      console.log(this.decodedToken);
    }
  })
  );
}
register(model:any){
  return this.http.post(this.baseUrl+ "register", model).pipe(
    map((response: any)=>{
      const resp = response;
    })
  );
  }

  GetRoulettes(){
    return this.http.get(this.RoulettesUrl);
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}

