import { ProductService, useProductApi } from '../use-product-api'
import axios from 'axios'
import { renderHook } from '@testing-library/react-hooks'
import { EditProductResquest, RegisterProductResquest } from 'types/product/request'

let productApi: ProductService
jest.mock('axios')

describe('useHttp', () => {
  beforeAll(() => {
    const { result } = renderHook(() => useProductApi())
    productApi = result.current
  })

  test('should call axios get when listAllProducts is called', () => {
    const spy = jest.spyOn(axios, 'get').mockImplementation(() => Promise.resolve({ data: {} }))

    productApi.listAllProducts()

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith('/Product')
  })

  test('should call axios get when getProductById is called', () => {
    const spy = jest.spyOn(axios, 'get').mockImplementation(() => Promise.resolve({ data: {} }))
    const id: string = '06ba3654-0644-4642-9985-428236495c09'

    productApi.getProductById(id)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(`/Product/${id}`)
  })

  test('should call axios post when registerProduct is called', () => {
    const spy = jest.spyOn(axios, 'post').mockImplementation(() => Promise.resolve({ data: {} }))
    const data: RegisterProductResquest = {
      name: 'Moletom Com Capuz Cobra Kai',
      price: 159.9,
      description:
        "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
      categoryName: 'Sweatshirt',
      imageURL: 'https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true',
    }

    productApi.registerProduct(data)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith('/Product', data)
  })

  test('should call axios delete when deleteProduct is called', () => {
    const spy = jest.spyOn(axios, 'delete').mockImplementation(() => Promise.resolve({ data: {} }))
    const id: string = '06ba3654-0644-4642-9985-428236495c09'

    productApi.deleteProduct(id)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(`/Product/${id}`)
  })

  test('should call axios put when editProduct is called', () => {
    const spy = jest.spyOn(axios, 'put').mockImplementation(() => Promise.resolve({ data: {} }))
    const data: EditProductResquest = {
      id: '06ba3654-0644-4642-9985-428236495c09',
      name: 'Moletom Com Capuz Cobra Kai',
      price: 159.9,
      description:
        "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
      categoryName: 'Sweatshirt',
      imageURL: 'https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true',
    }

    productApi.editProduct(data)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith('/Product', data)
  })
})
