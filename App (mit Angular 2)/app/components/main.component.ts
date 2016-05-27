import {Component} from 'angular2/core';

import {LoginComponent} from './login.component';
import {UserAreaComponent} from './user area/userArea.component';

import {Session} from '../view model/session';

@Component({
    selector: 'app',
    directives: [LoginComponent, UserAreaComponent],
    providers: [],
    template: `
        <login *ngIf="!isLoggedIn()"></login>
        <user-area *ngIf="isLoggedIn()"></user-area>
    `
})

export class MainComponent
{
  constructor()
  {

  }

  isLoggedIn()
  {
    return Session.isLoggedIn;
  }
}
