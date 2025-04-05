export interface User {
    id?     : number
    username: string
    password: string
    email   : string
    token   : string | null
}

export interface AuthContextProps {
    user    : User | null
    login   : (username: string, password: string) => Promise<void>
    register: (username: string, password: string, email: string) => Promise<void>
    logout  : () => void
}

export interface AuthContextProviderProps {
    children: React.ReactNode
}

export interface LoginProps {
    username: string
    password: string
}

export interface RegisterProps {
    username: string
    password: string
    email   : string
}