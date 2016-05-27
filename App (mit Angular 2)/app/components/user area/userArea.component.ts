
import {Component} from 'angular2/core';

import {LiveTabComponent} from './liveTab.component';
import {TabNavigationComponent} from './tabNavigation.component';

import {Session} from '../../view model/session';

@Component({
    selector: 'user-area',
    directives: [LiveTabComponent, TabNavigationComponent],
    providers: [],
    template: `
    <div>
      <tab-navigation [selectedTab]="selectedTab"></tab-navigation>
      <div>
        <live-tab *ngIf="selectedTab == 'live'"></live-tab>

        <div class="fixedBottom">
          <a class="btn light-blue fullwidth statusBar disabled"><i class="material-icons left">visibility</i> {{username}}</a>
        </div>
      </div>
    </div>
    `
})

export class UserAreaComponent
{
  username : string;
  selectedTab : string = 'live';

  constructor()
  {
    this.username = Session.username;
  }
}
