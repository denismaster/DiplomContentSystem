import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'teachers',
    templateUrl: './teacher.component.html'
})
export class TeachersComponent {
    public teachers: Teacher[];

    constructor(http: Http) {
        http.get('/api/teachers').subscribe(result => {
            let teachers = result.json() as Teacher[];
            console.log(teachers);
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
