import {Component} from 'angular2/core';

import {Session} from '../view model/session';

@Component({
    selector: 'login',
    directives: [],
    providers: [],
    template: `
    <div class="row">
      <form class="col s12">
        <div class="row">
        <center><h2 class="oswlad">PROTOTYP APP</h2></center>
          <div class="input-field col s12">
            <input [(ngModel)]="userName"
              [ngClass]="(userName.length > 0) ? (validateUserName() ? 'success' : 'failed') : 'none'"
              type="text" class="validate">
            <label for="username">Username</label>
          </div>
          <div class="input-field col s12 ">
            <input [(ngModel)]="networkCode"
              [ngClass]="(networkCode.length > 0) ? (validateNetworkCode() ? 'success' : 'failed') : 'none'"
              type="text" class="validate">
            <label for="code">Code</label>
          </div>
          <div class="input-field col s12">
            <a class="waves-effect waves-light btn light-blue fullwidth" (click)="login()">connect</a>
          </div>
        </div>
      </form>
    </div>
    `
})

export class LoginComponent
{
  userName : string = "";
  networkCode : string = "";

  userNameValid : boolean = false;
  networkCodeValid : boolean = false;

  constructor()
  {

  }

  login()
  {
    if(this.isValid())
    {
      console.log("Hallo " + this.userName);
      Session.isLoggedIn = true;
      Session.username = this.userName;
    }
    else
    {
      console.log("Eingaben sind nicht valide");
    }
  }

  isValid()
  {
    return (this.validateUserName() && this.validateNetworkCode());
  }

  validateUserName()
  {
    if(this.userName.length >= 3)
    {
      this.userNameValid = true;
      return true;
    }
    else
    {
      this.userNameValid = false;
      return false;
    }
  }

  validateNetworkCode()
  {
    return (this.networkCode.length == 8);
  }
}
