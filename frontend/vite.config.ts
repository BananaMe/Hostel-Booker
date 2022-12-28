import { defineConfig } from 'vite';
import solidPlugin from 'vite-plugin-solid';

export default defineConfig({
  plugins: [solidPlugin()],
  server: {
    port: 3000,
    proxy: {
      "/api/": {
        changeOrigin: true,
        target : "http://localhost:5018/"
      },
    },
  },
  build: {
    target: 'esnext',
  },
});
