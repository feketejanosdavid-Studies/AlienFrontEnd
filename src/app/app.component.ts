import { Component } from '@angular/core';
import { BaseService } from './base.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AlieFrontend';
  aliens:any

  constructor(private base:BaseService) {
    base.getAliens().subscribe(
      (res) => this.aliens = res
    )
  }
}
