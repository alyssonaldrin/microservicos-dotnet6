import axios, { AxiosRequestHeaders } from 'axios'

export function useAxios(baseURL: string, headers?: AxiosRequestHeaders) {
  return axios.create({
    baseURL,
    headers,
  })
}
