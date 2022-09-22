const axiosMock = {
  get: jest.fn(),
  post: jest.fn(),
  put: jest.fn(),
  delete: jest.fn(),
  interceptors: {
    request: {
      use: jest.fn(),
    },
    response: {
      use: jest.fn(),
    },
  },
  defaults: {
    headers: {},
  },
}

axiosMock.create = jest.fn().mockImplementation(() => axiosMock)

module.exports = { axiosMock }
