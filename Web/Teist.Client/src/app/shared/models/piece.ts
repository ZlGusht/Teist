import { BaseEntity } from './contracts/base-entity.interface';

export class Piece implements BaseEntity {
    id: number;
    name: string;
    genre: string;
    pieceType: string;
    performer: string;

    constructor(piece: any, performer) {
        this.name = piece.name;
        this.genre = piece.genre;
        this.pieceType = piece.pieceType;
        this.performer = performer;

    }
}