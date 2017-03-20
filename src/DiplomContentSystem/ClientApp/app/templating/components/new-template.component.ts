import { Component } from '@angular/core';

@Component({
    selector: 'new-template',
    templateUrl: './new-template.component.html',
    styles:[require("./new-template.component.css")]
})
export class NewTemplateComponent {
    public currentCount = 0;
    public templateText:string;

    public incrementCounter() {
        this.currentCount++;
    }
}