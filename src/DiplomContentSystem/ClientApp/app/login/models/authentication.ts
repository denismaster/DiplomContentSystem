export class Authentication
{
    login: string;
    password: string;
    remember: boolean;

    constructor(login: string,
        password: string,
        remember: boolean)
    {
        this.login = login;
        this.password = password;
        this.remember = remember;
    }
}