import { BaseEntity } from './contracts/base-entity.interface';

export class User implements BaseEntity {
    name: string;
    id: string;
    email: string;
    password: string;
}
