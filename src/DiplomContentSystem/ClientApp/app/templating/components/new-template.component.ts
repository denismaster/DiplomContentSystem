import { Component, AfterViewInit } from '@angular/core';
import * as _codeMirror from "codemirror";
import  "codemirror/mode/stex/stex"

@Component({
    selector: 'new-template',
    templateUrl: './new-template.component.html',
    styles: [require("./new-template.component.css")]
})
export class NewTemplateComponent implements AfterViewInit {
    public currentCount = 0;
    public templateText:string;

    public incrementCounter() {
        this.currentCount++;
    }

    ngAfterViewInit() {
        const textArea = document.querySelector("#code-area") as HTMLTextAreaElement;
        _codeMirror.fromTextArea(textArea,{
            lineNumbers: true,
            mode: "stex",
            theme: 'default'
        });
    }
}