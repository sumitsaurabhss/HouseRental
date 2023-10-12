export interface HouseModel {
    id: string;
    type: string;
    address: string;
    rentalCostPerMonth: number;
    isAvailable: boolean;
}

export interface HouseCreate {
    type: string,
    address: string,
    rentalCostPerMonth: number
}