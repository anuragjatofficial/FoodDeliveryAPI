/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      animation: {
        'curve-decelerate-mid': 'cubic-bezier(0, 0, 0, 1)',
      }
    },
  },
  plugins: [],
}

