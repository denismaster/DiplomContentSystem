import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import { CustomValidators } from '../../shared/custom-validators';

@Component({
    selector: 'teachers-edit',
    templateUrl: './teacher-edit.component.html'
})
export class TeachersEditComponent implements OnInit {
    private form: FormGroup;
    private id:number;
    private teacher: Teacher;
    private isLoading:boolean=true;

    constructor(private service: TeacherService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "fio": [result.fio, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "maxWorkCount": [result.maxWorkCount, Validators.compose([Validators.required,CustomValidators.minValue(1)])],
                    "position": [result.position]
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "fio": [undefined],
                    "maxWorkCount": [undefined],
                    "position": [undefined]
                });   
    }

    private submit(value: any): void {
        event.preventDefault();

        const teacher = new Teacher();
        teacher.id = this.id;
        teacher.fio = value.fio;
        teacher.position = value.position;
        teacher.maxWorkCount = value.maxWorkCount;
        
        this.service.update(teacher).subscribe(result=>this.goBack());
    }

    public goBack(): void {
        this.router.navigate(['/teachers']);
    }
}
