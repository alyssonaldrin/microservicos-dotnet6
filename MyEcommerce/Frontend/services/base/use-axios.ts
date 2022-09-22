import axios, { AxiosInstance, AxiosRequestHeaders } from 'axios'
import { useMemo } from 'react'

export function useAxios(baseURL: string, headers?: AxiosRequestHeaders): AxiosInstance {
  return useMemo(
    () =>
      axios.create({
        baseURL,
        headers,
      }),
    [baseURL, headers]
  )
}
