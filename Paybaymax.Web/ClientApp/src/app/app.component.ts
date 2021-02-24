import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'pay-root',
  template: `<div id="app__container">
    <pay-banner></pay-banner>
    <div id="app__page-container">
      <router-outlet></router-outlet>
    </div>
  </div>`,
  styles: [
    '#app__container{background-color:white}#app__page-container{margin-top:20px}',
  ],
})
export class AppComponent {
  constructor(translate: TranslateService) {
    translate.setDefaultLang('en');
    translate.use('en');
  }
}
