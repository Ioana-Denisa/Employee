import { defineConfig } from '@playwright/test';

export default defineConfig({
    testDir: './tests',
    retries: 1, 
    timeout: 30 * 1000, 
    use: {
        browserName: 'chrome', 
        headless: true, 
        screenshot: 'only-on-failure', 
        video: 'on', 
    },
});
