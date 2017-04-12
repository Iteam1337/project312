import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    public currentCount = 0;

    public incrementCounter() {
        this
            .http
            .post('http://localhost:5000/home/insertsubscriber', {
                email: 'ram@iteam.se',
                name: 'RAM'
            })
        .subscribe(result => console.log(result))
        this.currentCount++;
    }

    constructor(private http: Http) {}
}
