import {Component} from 'angular2/core';

import {Session} from '../../view model/session';

@Component({
    selector: 'tab-navigation',
    directives: [],
    providers: [],
    template: `
    <div class="col s12">
      <ul class="tabs">
      <!--class="active"-->
        <li class="tab col s4 light-blue"><a href="#live" (click)="liveTabClicked()" [ngClass]="(selectedTab == 'live') ? 'active' : 'none'">Live</a></li>
        <li class="tab col s4 light-blue"><a href="#actual" (click)="actualTabClicked()" [ngClass]="(selectedTab == 'actual') ? 'active' : 'none'">Aktuelle</a></li>
        <li class="tab col s4 light-blue"><a href="#MVList" (click)="modelViewListTabClicked()" [ngClass]="(selectedTab == 'modelViewList') ? 'active' : 'none'">Gespeicherte</a></li>
      </ul>
    </div>
    `
})

export class TabNavigationComponent
{
  selectedTab : string = 'live';

  constructor()
  {

  }

  liveTabClicked()
  {
    this.selectedTab = 'live';
  }

  actualTabClicked()
  {
    this.selectedTab = 'actual';
  }

  modelViewListTabClicked()
  {
    this.selectedTab = 'modelViewList';
  }
}
