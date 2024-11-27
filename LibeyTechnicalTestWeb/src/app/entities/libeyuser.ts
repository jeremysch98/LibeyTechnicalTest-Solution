export interface LibeyUser {
    documentNumber: string;
    documentTypeId: number;
    documentTypeDescription?: string;
    name: string;
    fathersLastName: string;
    mothersLastName: string;
    address: string;
    regionCode?: string;
    regionDescription?: string;
    provinceCode?: string;
    provinceDescription?: string;
    ubigeoCode: string;
    ubigeoDescription?: string;
    phone: string;
    email: string;
    password: string;
    active?: boolean;
}