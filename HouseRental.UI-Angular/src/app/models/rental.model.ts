export interface RentalAgreement {
    houseId: string;
    type: string;
    address: string;
    rentalCostPerMonth: number;
    rentalDurationInMonths: number;
    totalRentalCost: number;
    isReturned: boolean;
    userId: string;
}

export interface RentalDetails {
    id: string;
    type: string;
    address: string;
    rentalStartDate: Date;
    rentalEndDate: Date;
    totalRentalCost: number;
    isReturned: boolean;
    userId: string;
    userName: string;
}


export interface RentalCreate {
    houseId: string;
    userId: string;
    totalRentalCost: number;
    durationInMonths: number;
}