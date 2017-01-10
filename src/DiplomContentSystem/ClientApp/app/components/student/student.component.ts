import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'students',
    templateUrl: './student.component.html'
})
export class StudentComponent {
    public teachers: Teacher[];

    constructor(http: Http) {
        http.get('/api/teachers').subscribe(result => {
            let teachers = result.json() as Teacher[];
            this.teachers = teachers;
        });
    }
}

interface Teacher {
    id: number;
    fio: string;
    position: string;
    maxWorkCount: string;
}
