import { Component, Inject } from '@angular/core';
import { baseUrl } from '@core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    @Inject(baseUrl) public b: string
  ) {
    alert(b);
  }
}
