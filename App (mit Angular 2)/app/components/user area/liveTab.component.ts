import {Component} from 'angular2/core';

import {Session} from '../../view model/session';

@Component({
    selector: 'live-tab',
    directives: [],
    providers: [],
    template: `
      <div class="row">
        <div id="measurementSeries" class="col s12 btn btn-large disabled">
          Wiederholungsgenauigkeit Messung
        </div>
      </div>

      <div class="">EVTL LOGO</div>

      <div class="liveBottom">
          <a class=" tab waves-effect waves-light btn light-blue fullwidth trigger">Start</a>
      </div>        
    `
})

export class LiveTabComponent
{
  constructor()
  {

  }
}
