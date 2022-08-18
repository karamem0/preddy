module.exports = {
  globals: {
    'ts-jest': {
      isolatedModules: 'disabled'
    }
  },
  reporters: [
    'default'
  ],
  testEnvironment: 'jsdom',
  testMatch: [
    '**/*.test.ts',
    '**/*.test.tsx'
  ]
};
