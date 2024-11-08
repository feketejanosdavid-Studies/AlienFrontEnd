import { Component, OnDestroy, OnInit } from '@angular/core';
import { BaseService } from './base.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'AlieFrontend';
  oszlopok = [
    {key:"name", text:"Name", type:"text"},
    {key:"attitude", text:"Attitude", type:"text"},
    {key:"population", text:"Population", type:"number"}
  ]
  aliens:any
  newAlien:any={}
  error=false
  errorText=""
  feliratkozas !: Subscription


  constructor(private base:BaseService) {}
  
  ngOnInit(): void {
    this.getAliens()
}

  ngOnDestroy(): void {
    if (this.feliratkozas) this.feliratkozas.unsubscribe()
}

  getAliens() {
    this.feliratkozas=this.base.getAliens().subscribe(
      {
        next:(res)=>{
          this.aliens=res
          this.error=false
        },
        error:(err)=> {
          console.log(err)
          this.error=true
          this.errorText=err
        }
      }
    )
  }

  postAliens() {
    this.base.postAlien(this.newAlien).subscribe(
      ()=> {this.getAliens()
        this.newAlien={}
      }

    )
  }

  updateAlien(alien:any) {
    this.base.updateAlien(alien).subscribe(
      ()=> this.getAliens()
    )
  }

  

  deleteAlien(alien:any) {
    this.base.deleteteAlien(alien).subscribe(
      ()=> this.getAliens()
    )
  }
}
