export interface Estate {
    id?: string;
    userId: string;
    name: string;
    description: string;
    price: number;
    address: string;
    size: number;
    type: string;
    status: string;
    listingDate: Date;
}