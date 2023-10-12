export interface UserProfile {
    id: string;
    email: string;
    name: string;
    isAdmin: boolean;
}

export interface UserCredentials {
    email: string;
    password: string;
}

export interface UserRegistration {
    name: string;
    email: string;
    password: string;
}