import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'subscriber',
    templateUrl: './subscriber.component.html'
})
export class SubscriberComponent {
    submitted = false;
    subscriber = {
        email: '',
        name: ''
    };

    onSubmit () { 
        alert('hello');
        this.submitted = true; 
    }

    public submit() {
        this
            .http
            .post('http://localhost:5000/home/insertsubscriber', this.subscriber)
        .subscribe(result => console.log(result))
    }

    constructor(private http: Http) {}
}
