import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public subscribers: Subscriber[];

    constructor(http: Http) {
        http.get('/home/getsubscribers').subscribe(result => {
            this.subscribers = result.json() as Subscriber[];
        });
    }
}

interface Subscriber {
    id: number;
    email: string;
    name: string;
}
