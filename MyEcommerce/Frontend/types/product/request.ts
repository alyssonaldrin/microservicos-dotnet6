export interface RegisterProductResquest {
  name: string
  price: number
  description: string
  categoryName: string
  imageURL: string
}

export interface EditProductResquest {
  id: string
  name: string
  price: number
  description: string
  categoryName: string
  imageURL: string
}
