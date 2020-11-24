import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Angular Demo App';
  userForm : FormGroup;
  submitted = false;
  userData: any = [];
  constructor(private fb: FormBuilder, private userService: UserService){

  }
ngOnInit(){
  this.userForm = this.fb.group({
    firstName: ['',Validators.required],
    lastName: ['',Validators.required],
    city: ['',Validators.required],
    phoneNumber: ['',Validators.required]
  });
  this.userService.getUsers().then(result=>{
    this.userData = result;
  })
  .catch(error=>{
    console.log(error);
  });
}

submitUserData(){
  this.submitted = true;
  if(this.userForm.valid){
    let userObject = {
      'firstName': this.userForm.controls['firstName'].value,
      'lastName': this.userForm.controls['lastName'].value,
      'city': this.userForm.controls['city'].value,
      'phoneNumber': this.userForm.controls['phoneNumber'].value
    }
    this.userService.setUsers(userObject).then(result=>{
      this.userService.getUsers().then(result=>{
        this.userData = result;
      });
    })
    .catch(error=>{
      console.log(error);
    })
    console.log(this.userData);
  }
}

get f(){ return this.userForm.controls}
}
