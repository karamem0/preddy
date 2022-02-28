import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import env from 'vite-plugin-env-compatible';

export default defineConfig({
  server: {
    open: false
  },
  build: {
    outDir: 'build'
  },
  plugins: [
    react(),
    env({
      prefix: 'REACT_APP'
    })
  ]
});
