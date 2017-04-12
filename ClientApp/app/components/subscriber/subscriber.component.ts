import { Component } from '@angular/core'
import { Http } from '@angular/http'
import { Router } from '@angular/router'

@Component({
    selector: 'subscriber',
    templateUrl: './subscriber.component.html'
})
export class SubscriberComponent {
    submitted = false;
    subscriber = {
        email: '',
        name: ''
    }

    public submit() {
        this
            .http
            .post('/home/insertsubscriber', this.subscriber)
            .subscribe(result => this.router.navigate(['fetch-data']))
    }

    constructor(
        private http: Http,
        private router: Router
    ) { }
}
