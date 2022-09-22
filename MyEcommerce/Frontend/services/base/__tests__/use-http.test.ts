import { HttpInstance, useHttp } from '../use-http'
import axios from 'axios'
import { renderHook } from '@testing-library/react-hooks'

const baseURL = 'https://localhost:5001'
let httpInstance: HttpInstance
jest.mock('axios')
const url = 'context'

describe('useHttp', () => {
  beforeAll(() => {
    const { result } = renderHook(() => useHttp(baseURL))
    httpInstance = result.current
  })

  test('should call axios get', () => {
    const spy = jest.spyOn(axios, 'get').mockImplementation(() => Promise.resolve({ data: {} }))

    httpInstance.get(url)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(url)
  })

  test('should call axios post', () => {
    const spy = jest.spyOn(axios, 'post').mockImplementation(() => Promise.resolve({ data: {} }))
    const data = { id: 1 }

    httpInstance.post(url, data)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(url, data)
  })

  test('should call axios delete', () => {
    const spy = jest.spyOn(axios, 'delete').mockImplementation(() => Promise.resolve({ data: {} }))

    httpInstance.deleteHttp(url)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(url)
  })

  test('should call axios put', () => {
    const spy = jest.spyOn(axios, 'put').mockImplementation(() => Promise.resolve({ data: {} }))
    const data = { id: 1 }

    httpInstance.put(url, data)

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith(url, data)
  })
})
