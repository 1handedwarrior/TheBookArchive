import { BookProps } from "./BookProps";

export interface PurchaseProps {
  id: number
  total: number
  books: BookProps[] 
  purchasedOn: string
}