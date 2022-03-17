import react from '@vitejs/plugin-react';
import { defineConfig } from 'vite';
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
