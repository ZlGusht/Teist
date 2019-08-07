import { BaseEntity } from './contracts/base-entity.interface';

export class User implements BaseEntity{
    id: string;
    email: string;
    password: string;
}