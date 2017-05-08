import { Role } from '../../shared/roles/roles';
export class User {
    id: number;
    login: string;
    password:string;
    roles: Role[];
}
