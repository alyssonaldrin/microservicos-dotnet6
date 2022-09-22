import { useCallback, useMemo } from 'react'
import { ProductResponse } from 'types/product/reponse'
import { EditProductResquest, RegisterProductResquest } from 'types/product/request'
import { useHttp } from '../base/use-http'

export interface ProductService {
  listAllProducts: () => ProductResponse[]
  getProductById: (id: string) => ProductResponse
  registerProduct: (registerProductResquest: RegisterProductResquest) => {}
  editProduct: (editProductRequest: EditProductResquest) => {}
  deleteProduct: (id: string) => {}
}

export function useProductApi(): ProductService {
  const baseURL = 'http://localhost:5176/api'
  const httpInstance = useHttp(baseURL)

  const listAllProducts = useCallback(() => httpInstance.get('/Product'), [httpInstance])

  const getProductById = useCallback((id: string) => httpInstance.get(`/Product/${id}`), [httpInstance])

  const registerProduct = useCallback(
    (registerProductResquest: RegisterProductResquest) => httpInstance.post('/Product', registerProductResquest),
    [httpInstance]
  )

  const editProduct = useCallback((editrProductResquest: EditProductResquest) => httpInstance.put('/Product', editrProductResquest), [httpInstance])

  const deleteProduct = useCallback((id: string) => httpInstance.deleteHttp(`/Product/${id}`), [httpInstance])

  return useMemo(
    () => ({ listAllProducts, getProductById, registerProduct, editProduct, deleteProduct }),
    [deleteProduct, editProduct, getProductById, listAllProducts, registerProduct]
  )
}
