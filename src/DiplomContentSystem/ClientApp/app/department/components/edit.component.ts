import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Router,ActivatedRoute } from '@angular/router';
import { Department } from '../models/department';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';
import { DepartmentService } from '../department.service';

@Component({
    selector: 'department-edit',
    templateUrl: './edit.component.html'
})
export class DepartmentEditComponent {
    private form: FormGroup;
    private errors: string[] = [];

    private id:number;
    private department: Department;
    private isLoading:boolean=true;

    constructor(private service: DepartmentService, private router: Router, private activatedRoute:ActivatedRoute, private formBuilder: FormBuilder) {
        this.id = activatedRoute.snapshot.params['id'];
        if(!this.id){
            router.navigateByUrl("['/404']");
        }
        this.service.getOne(this.id)
            .subscribe(result=>{
                this.isLoading=false;
                this.form = this.formBuilder.group({
                    "name": [result.name, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                    "shortName": [result.shortName, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
                });        
            })
    }

    ngOnInit()
    {
        this.form = this.formBuilder.group({
                    "name": [undefined],
                    "shortName": [undefined]
                });   
    }

    private submit(value: any): void {
        event.preventDefault();

        const department = new Department();
        department.id = this.id;
        department.name = value.name;
        department.name = value.name;
        this.service.update(department).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/departments']);
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
