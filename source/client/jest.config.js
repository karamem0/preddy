module.exports = {
  globals: {
    'ts-jest': {
      isolatedModules: 'disabled'
    }
  },
  reporters: [
    'default'
  ],
  testMatch: [
    '**/*.test.ts',
    '**/*.test.tsx'
  ],
  transform: {
    '^.+\\.(ts|tsx)$': 'ts-jest'
  }
};
