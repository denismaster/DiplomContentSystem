import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { User } from '../models/user';
import { CustomValidators } from '../../shared/custom-validators';
import { OperationResult } from '../../shared/operation-result';
import { SelectListItem } from '../../shared/select-list-item';

@Component({
    selector: 'users-add',
    templateUrl: './add.component.html'
})
export class UsersAddComponent implements OnInit {
    private form: FormGroup;
    private positionOptions:SelectListItem[];
    private departmentOptions:SelectListItem[];
    private errors: string[] = [];

    constructor(private service: UserService, private router: Router, private formBuilder: FormBuilder) {
        this.form = this.formBuilder.group({
            "login": [undefined, Validators.compose([Validators.required, CustomValidators.notEmpty()])],
            "password": [undefined,[Validators.required]],
        });
    }
    
    ngOnInit()
    {
        this.service.getPositions().subscribe(r=>this.positionOptions = r);
        this.service.getDepartments().subscribe(r=>this.departmentOptions = r);
    }

    private submit(value: any): void {
        event.preventDefault();

        const user = new User();
        user.login = value.login;
        user.password = value.password;
        
        this.service.add(user).subscribe(result=>this.checkResult(result));
    }

    public goBack(): void {
        this.router.navigate(['/users']);
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
