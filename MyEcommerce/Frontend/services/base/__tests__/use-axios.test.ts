import { useAxios } from '../use-axios'
import { renderHook } from '@testing-library/react-hooks'
import axios from 'axios'

jest.mock('axios')

let spy
const baseURL = 'https://localhost:5001'

describe('useAxios', () => {
  beforeAll(() => {
    spy = jest.spyOn(axios, 'create')
  })

  test('should return without headers', () => {
    renderHook(() => useAxios(baseURL))

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith({ baseURL, headers: undefined })
  })

  test('should return with headers', () => {
    const headers = { authorization: 'token' }

    renderHook(() => useAxios(baseURL, headers))

    expect(spy).toHaveBeenCalled()
    expect(spy).toHaveBeenCalledWith({ baseURL, headers })
  })
})
