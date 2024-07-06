import { Component } from '@angular/core';
import {SimService} from "../../services/sim.service";

@Component({
  selector: 'app-sim',
  templateUrl: './sim.component.html',
  styleUrl: './sim.component.css'
})
export class SimComponent {

  counter! : number;

  constructor(private simService: SimService) {
  }

  ngOnInit(): void {
    this.simService.startConnection().subscribe(() =>{
      console.log('hub');
      this.simService.receiveMessage().subscribe((message:number) => {
        this.counter=message;
        console.log(message);
        console.log(this.counter);
      });
    });
  }

}
