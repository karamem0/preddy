import react from '@vitejs/plugin-react';
import { defineConfig } from 'vite';
import env from 'vite-plugin-env-compatible';

export default defineConfig({
  build: {
    outDir: 'dist'
  },
  plugins: [
    react({
      babel: {
        plugins: [
          'react-intl-auto'
        ]
      }
    }),
    env({
      prefix: 'APP'
    })
  ],
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        secure: false
      }
    }
  }
});
