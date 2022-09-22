import { AxiosRequestHeaders } from 'axios'
import { useCallback, useMemo } from 'react'
import { useAxios } from './use-axios'

export interface HttpInstance {
  get: (url: string) => any
  post: (url: string, data: any) => any
  deleteHttp: (url: string) => any
  put: (url: string, data: any) => any
}

export function useHttp(baseURL: string, headers?: AxiosRequestHeaders): HttpInstance {
  const axiosInstance = useAxios(baseURL, headers)

  const get = useCallback(
    async (url: string) => {
      const response = await axiosInstance.get(url)

      return response.data
    },
    [axiosInstance]
  )

  const post = useCallback(
    async (url: string, data: any) => {
      const response = await axiosInstance.post(url, data)

      return response.data
    },
    [axiosInstance]
  )

  const deleteHttp = useCallback(
    async (url: string) => {
      const response = await axiosInstance.delete(url)

      return response.data
    },
    [axiosInstance]
  )

  const put = useCallback(
    async (url: string, data: any) => {
      const response = await axiosInstance.put(url, data)

      return response.data
    },
    [axiosInstance]
  )

  return useMemo(
    () => ({
      get,
      post,
      deleteHttp,
      put,
    }),
    [get, post, deleteHttp, put]
  )
}
