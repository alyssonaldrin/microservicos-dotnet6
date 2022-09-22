const { axiosMock } = require('./test/axios')

jest.setMock('axios', axiosMock)
