export interface BookProps {
    id?: number
    title : string
    author : string
    summary : string
    isbn : string
    image?: string
    publishedOn : string
}

export interface AddBookPageProps {
    onBookAdded: (book: BookProps) => void
}