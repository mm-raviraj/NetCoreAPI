import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers(){
    var headers_object = new HttpHeaders(
      {'Content-Type': 'application/json'
      ,'Access-Control-Allow-Methods': 'GET, POST, OPTIONS'
      ,'Access-Control-Allow-Origin': '*'
      }
    );

    const httpOptions = {
      headers: headers_object
    };
    return new Promise((resolve, reject) => {
          this.http.get(environment.URLS.API+"/"+environment.URLS.USER, httpOptions).subscribe((res: any) => {
           
            console.log(res);
             resolve(res);
           
          },
            (err) => {
              if (err.status == 401) {
                console.log("error", err);
                reject(err);
              } else if (err.status == 400 || err.status == 500 || err.status == 0) {
                    reject(err);
                    console.log("error", err);
              } else if (err.status == 404) {
                        console.log("error", err);
                        resolve(err);
              } else {
                        resolve(err);
                      }
                    }
                  );
                });
          }

  setUsers(user){
    var headers_object = new HttpHeaders(
      {'Content-Type': 'application/json'
      ,'Access-Control-Allow-Methods': 'GET, POST, OPTIONS'
      ,'Access-Control-Allow-Origin': '*'
      }
    );
    const httpOptions = {
      headers: headers_object
    };
      return new Promise((resolve, reject) => {
          this.http.post(environment.URLS.API+"/"+environment.URLS.SET_USER,user,httpOptions).subscribe((res: any) => {
            resolve(res);
            console.log(res);
          },
            (err) => {
              if (err.status == 401) {
                console.log("error", err);
                reject(err);
              } else if (err.status == 400 || err.status == 500 || err.status == 0) {
                    reject(err);
                    console.log("error", err);
              } else if (err.status == 404) {
                      console.log("error", err);
                      resolve(err);
              } else {
                      resolve(err);
                      }
                    }
                  );
                });
          }
              
  }
              
