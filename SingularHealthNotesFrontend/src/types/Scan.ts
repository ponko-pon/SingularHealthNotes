export interface Note {
  title: string
  content: string
}

export interface Scan {
  id: string
  name: string
  date: Date
  notes: Note[]
  imageUrl: string
}
