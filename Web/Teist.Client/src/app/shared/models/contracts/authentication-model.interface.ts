import { Role } from '../../enums/role';

export interface AuthenticationModel {
    token: string;
    uniqueName: string;
    roles: Role[];
    expirationTime: number;
}
