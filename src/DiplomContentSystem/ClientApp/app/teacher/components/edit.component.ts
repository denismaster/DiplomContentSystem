import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { TeacherService } from '../teacher.service';
import { Teacher } from '../models/teacher';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'teachers-edit',
    templateUrl: './edit.component.html'
})
export class TeachersEditComponent implements OnInit {
    private form: FormGroup;
    private errors: string[] = [];

    private positionOptions:SelectListItem[];
    private departmentOptions:SelectListItem[];
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
                    "position": [result.position.id, Validators.required],
                    "department":[result.departmentId, Validators.required]
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "fio": [undefined],
                    "maxWorkCount": [undefined],
                    "position": [undefined],
                    "department":[undefined]
                });   
        this.service.getPositions().subscribe(r=>this.positionOptions = r);
        this.service.getDepartments().subscribe(r=>this.departmentOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const teacher = new Teacher();
        teacher.id = this.id;
        teacher.fio = value.fio;
        teacher.positionId = value.position;
        teacher.maxWorkCount = value.maxWorkCount;
        teacher.departmentId = value.department;
        
        this.service.update(teacher).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/teachers']);
    }

    public checkResult(result:OperationResult):void{
        if(!result.hasErrors)
        {
            this.goBack();
        }
        else
        {
            this.errors = result.errors;
        }
    }
}
