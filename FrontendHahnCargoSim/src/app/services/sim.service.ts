import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable} from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class SimService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiUrl+"/Sim")
      .build();
  }

  startConnection(): Observable<void> {
    return new Observable<void>((observer) => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('Connection established with SignalR hub');
          observer.next();
          observer.complete();
        })
        .catch((error) => {
          console.error('Error connecting to SignalR hub:', error);
          observer.error(error);
        });
    });
  }

  receiveMessage(): Observable<number> {
    return new Observable<number>((observer) => {
      this.hubConnection.on('ReceiveCounter', (message: number) => {
        observer.next(message);
      });
    });
  }

}
