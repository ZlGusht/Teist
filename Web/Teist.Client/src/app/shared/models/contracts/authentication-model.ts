import { Role } from '../../enums/role';

export class AuthenticationModel {
    token: string;
    uniqueName: string;
    roles: Role[];
    expirationTime: number;
}
