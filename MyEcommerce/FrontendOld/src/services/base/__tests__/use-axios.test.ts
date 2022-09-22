import { useAxios } from '../use-axios'

describe('useAxios', () => {
  test('should return without headers', () => {
    const baseURL = 'localhost.com'

    const returned = useAxios(baseURL)

    expect(returned.getUri()).toBe(baseURL)
  })

  test('should return with headers', () => {
    const baseURL = 'localhost.com'
    const headers = {
      authorization: 'token',
    }

    const returned = useAxios(baseURL, headers)

    expect(returned.getUri()).toBe(baseURL)
    expect(returned.defaults.headers.get).toBe('token')
  })
})
